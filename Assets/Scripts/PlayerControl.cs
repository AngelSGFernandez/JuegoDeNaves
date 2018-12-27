using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour //Script para el Movimiento del Jugador
{
    public GameObject GameManagerGo;//referencia a nuestro game manager

    public GameObject PlayerBulletGo; //este es el prefab de nuestro player bullet
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGo; //este es nuestro Explosion prefab
    public GameObject PlayerGo;
    public GameObject ShooterPlayerGo;

    public float speed;

    //referencia para el text ui de las vidas
    public Text LivesUIText;

    //vida del jugador
    private int health;
    public int Health { get { return Health; } }

    const int MaxLives = 3; //cantidad maxima de vidas
    public static int lives; //cantidad actual de vidas
    public Renderer rend; //render pa la invulnerabilidad
    public Color c; //variable color para la invulnerabilidad

    //variable para desactivar una tecla

    public void Init()
    {
        health = 1; //vida del jugador
        //resetea la posicion del jugador tras morir
        transform.position = new Vector2(0, 0);

        //permite al jugador activar el game object
        gameObject.SetActive(true);
        //reiniciar el color y la invencivilidad

        ShowShipNoTransparent();
        StartCoroutine("StopInvisible");
    }

    public void InitLives()
    {
        lives = MaxLives;
        //actualiza las vidas en el text ui
        LivesUIText.text = lives.ToString();
    }

    // Use this for initialization
    void Start()
    {
       
        rend = GetComponent<Renderer>(); //esto es para la invulnerabilidad temporal
        c = rend.material.color;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Declarar que el health usado es el mismo para ambos gameobjects
        PlayerGo.GetComponent<PlayerControl>().health = health;
        ShooterPlayerGo.GetComponent<PlayerControl>().health = health;
        PlayerGo.GetComponent<PlayerControl>().health = ShooterPlayerGo.GetComponent<PlayerControl>().health;
        ShooterPlayerGo.GetComponent<PlayerControl>().health = PlayerGo.GetComponent<PlayerControl>().health;

        if (Input.GetKeyDown("space"))
            {
                //instanciar la primera bala
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGo);
                bullet01.transform.position = bulletPosition01.transform.position; //establece la posicion inicial de la bala

                //instancias la segunda bala
                GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGo);
                bullet02.transform.position = bulletPosition02.transform.position; // establece la posicion inicial de la bala

            }

        float x = Input.GetAxisRaw("Horizontal"); //el valor que puede tomar es -1, 0, o 1 (Izq, sin accion, Der)
        float y = Input.GetAxisRaw("Vertical"); //el valor que puede tomar es -1, 0 o 1 (Abajo, sin accion, Arriba)

        //segun la tecla que ingresemos conseguiremos un vector unitario
        Vector2 direction = new Vector2(x, y).normalized;

        //llamada a la funcion que marca la posicion del jugador
        Move(direction);
    }
    void Move(Vector2 direction)
    {
        //segun los limites de la pantalla se marcan los limites del movimiento del jugador
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Esquina superior derecha de la pantalla

        max.x = max.x - 0.225f; //restamos la mitad de la anchura del sprite del jugador
        min.x = min.x + 0.225f; //añadimos la mitad de la anchura del sprite del jugador

        max.y = max.y - 0.285f; //restamos la mitad del tamaño del sprite del jugador
        min.y = min.y + 0.285f; //añadimos la mitad del tamaño del sprite del jugador

        //indica la posicion actual del jugador
        Vector2 pos = transform.position;

        //calcula la nueva posicion
        pos += direction * speed * Time.deltaTime;

        //asegurarse de que la nueva posicion no este fuera de la pantalla
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //actualiza la posicion del jugador
        transform.position = pos;
        
        //el movimiento del jugador sera el mismo que el del objeto activado aun cuando este desactivado
        PlayerGo.transform.position = pos;
        ShooterPlayerGo.transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Detecta colisiones de el jugador con un obstaculo o projectil
        if (col.tag == "EnemyShipTag") //|| (col.tag == "EnemyBulletTag"))
        {
            //if (health >= 1)
            //{
                Hit(1); //recive 1 de daño
                //health--;
                StartCoroutine("Wait3Seconds");    //llama al metodo Wait3Seconds para cambiar el estado del jugador a normal 
                StartCoroutine("GetInvulnerable"); //llama al metodo GetInvulnerable
                StartCoroutine("StopInvisible"); //llama al metodo para dejar de ser invencible
                if(health == 0)
                {
                StartCoroutine("GetInvulnerable"); //llama al metodo GetInvulnerable
                StartCoroutine("StopInvisible"); //llama al metodo para dejar de ser invencible
                PlayExplosion();
                lives--;//resta una vida
                LivesUIText.text = lives.ToString(); //actualiza el ui text de las vidas
                health = 1;//reiniciamos el health
                }
            //Debug.Log("Tienes: " + health);
            //}
            /*else if (health < 0)
            {
                StartCoroutine("GetInvulnerable"); //llama al metodo GetInvulnerable
                StartCoroutine("StopInvisible");
                PlayExplosion();
                lives--; //resta una vida
                health = 1; //reiniciamos el health
                LivesUIText.text = lives.ToString(); //actualiza el ui text de las vidas
                
            }*/
            if (lives == 0) //si el jugador se queda sin vidas
            {
                //cambiamos el estado del game manager a game over
                GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                //ocultamos la nave del jugador
                gameObject.SetActive(false);

                //reiniciamos para quitar el efecto transparente y la invulnerabilidad
                Physics2D.IgnoreLayerCollision(0, 0, false);
                c.a = 1f;
                rend.material.color = c;
            }
        }

        /*if (col.tag == "StarShooterTag")
        {
            GetComponent<SpriteRenderer>();
        }*/
    }
    //metodo de instancia para una explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);

        //marcar la posicion de la explosion
        explosion.transform.position = transform.position;
    }

    /* public void DecreaseLives()
     {
         lives--; //resta una vida
         LivesUIText.text = lives.ToString(); //actualiza el ui text de las vidas
     }*/

    IEnumerator GetInvulnerable() //metodo para hacer invulnerable
    {
        Physics2D.IgnoreLayerCollision(0, 0, true);
        c.a = 0.5f; //efecto transparente
        rend.material.color = c;
        yield return new WaitForSeconds(3f); //segundos que va a estar invisible
        Physics2D.IgnoreLayerCollision(0, 0, false);
        c.a = 1f;
        rend.material.color = c;
    }

    //metodo si recive daño
    public void Hit(int damage)
    {
        if (health >= 1) {
            health -= damage;
            StartCoroutine("Wait3Seconds");
        }
        /*else if (health == 0)
        {
            health = 1;
        }*/
    }

    //metodo para el efecto del power up moon shield
    public void MoonShieldEffect()
    {
        health++;
        health++;
        //Debug.Log("Hola");
    }

    //metodo para el efecto del power up star shooter
    public void StarShooterEffect()
    {
        health++;
        GetComponent<PlayerStatesManager>().PlayerGoShooterState();
        //Debug.Log("Tomaste una estrella y tienes: " + health);
        
    }

    public void DisablePlayerBullets()
    {
        GameObject.Find("PlayerGo").GetComponent<PlayerStatesManager>().whichStateIsOn = 2;
    }
    //metodo para ocultar el power up ship
    public void HideShip()
    {
        Physics2D.IgnoreLayerCollision(0, 0, false);
        c.a = 1f;
        rend.material.color = c;
        gameObject.SetActive(false);
        transform.position = new Vector2(0, 0);
    }

    public void ShowShipNoTransparent()
    {
        Physics2D.IgnoreLayerCollision(0, 0, false);
        c.a = 1f;
    }

    IEnumerator Wait3Seconds() //metodo que espera 3 segundos y cambia de posicion al jugador
    {
        yield return new WaitForSeconds(3f);
        //si el jugador se encuentra en su forma shooter volverá a su estado original
        GetComponent<PlayerStatesManager>().PlayerGoNormalState();
        //actualizar state
        PlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn = 1;
    }
    IEnumerator StopInvisible()//metodo para dejar de ser invisible
    {
        yield return new WaitForSeconds(3f); //segundos que va a estar invisible
        Physics2D.IgnoreLayerCollision(0, 0, false);
        c.a = 1f;
        rend.material.color = c;
    }
    }
