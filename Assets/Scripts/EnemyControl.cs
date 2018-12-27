using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour //Script para el Movimiento del Enemigo
{
    GameObject scoreUITextGo;//referencia a el text ui game object
    GameObject kcounterUITextGo;//referencia a el text ui game object
    //GameObject EnemyGo;

    public GameObject ExplosionGo; //este es nuestro Explosion prefab
    public float speed;

    //declaraciones para la vida del enemigo
    private int health;
    public int Health { get { return Health; } }
    // Use this for initialization
    void Start() {
        health = 3; //vida del enemigo
        speed = 2f;//marcar la velocidad
        //consigue el score text UI
        scoreUITextGo = GameObject.FindGameObjectWithTag("ScoreTextTag");
        //consigue el kill counter text UI
        kcounterUITextGo = GameObject.FindGameObjectWithTag("KillCounterTextTag");
        //EnemyGo = GameObject.FindGameObjectWithTag("EnemyShipTag");

    }

    // Update is called once per frame
    void Update() {
        //indica la posicion actual del enemigo
        Vector2 position = transform.position;

        //nueva posicion del enemigo
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //actualiza la posicion del enemigo
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla

        //si el enemigo quiere salir fuera de la pantalla, desaparecerlo
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detecta colisiones de la nave enemiga con la del jugador o de su projectil
        if (col.tag == "PlayerShipTag") //|| (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            //añade 100 puntos al marcador (score)
            scoreUITextGo.GetComponent<GameScore>().Score += 100;
            //añade 1 kill
            kcounterUITextGo.GetComponent<KillCounter>().Kcounter += 1;

            Destroy(gameObject); //Destruye la nave enemiga
        }
        //si se topa con la bala y tiene vida igual a 0
        if (col.tag == "PlayerBulletTag" && health <= 0)
        {
            PlayExplosion();

            //añade 100 puntos al marcador (score)
            scoreUITextGo.GetComponent<GameScore>().Score += 100;
            //añade 1 kill
            kcounterUITextGo.GetComponent<KillCounter>().Kcounter += 1;
            Destroy(gameObject); 
        }
        //si se topa con una shooter bala y tiene vida igual a 0
        if (col.tag == "ShooterPlayerBulletTag" && health <= 0)
        {
            PlayExplosion();

            //añade 100 puntos al marcador (score)
            scoreUITextGo.GetComponent<GameScore>().Score += 100;
            //añade 1 kill
            kcounterUITextGo.GetComponent<KillCounter>().Kcounter += 1;
            Destroy(gameObject);
        }
    }
    //metodo de instancia para una explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);

        //marcar la posicion de la explosion
        explosion.transform.position = transform.position;
    }
    //metodo para restar vida
    public void Hit(int damage)
    {
        health -= damage;
    }

    //metodo para eliminar a los enemigos en pantalla
    public void KillAll ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyShipTag");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }
}
