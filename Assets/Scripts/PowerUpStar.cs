using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStar : MonoBehaviour
{
    public float speed;

    // Use this for initialization
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //indica la posicion actual del power up
        Vector2 position = transform.position;

        //nueva posicion del power up
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //actualiza la posicion del power up
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla

        //si el power up quiere salir fuera de la pantalla, desaparecerlo
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detecta colisiones del power up con el jugador
        if (col.tag == "PlayerShipTag")
        {
            Physics2D.IgnoreLayerCollision(0, 0, false);
            //PlayerControl.lives = 3;
            //GameObject.Find("PlayerGo").GetComponent<PlayerControl>().LivesUIText.text = PlayerControl.lives.ToString();
            col.GetComponent<PlayerControl>().StarShooterEffect();
            //GameObject.Find("ShooterPlayerGo").GetComponent<PlayerControl>().LivesUIText.text = PlayerControl.lives.ToString();
            Destroy(gameObject);
        }
    }
}