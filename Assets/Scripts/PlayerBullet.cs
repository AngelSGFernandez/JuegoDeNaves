using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 8f;
	}

    // Update is called once per frame
    void Update()
    {
        //conseguir la poscion actual de la bala
        Vector2 position = transform.position;

        //calcular la nueva posicion de la bala
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //actualiza la poscion de la bala
        transform.position = position;

        //esta es la esquina superior derecha de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //si la bala sale de la pantalla hay que destruirla
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //detecta contacto de la bala del jugador con un enemigo
        if(col.tag == "EnemyShipTag")
        {
            col.gameObject.GetComponent<EnemyControl>().Hit(1);
            //destruye la bala
            Destroy(gameObject);
        }
    }
}
