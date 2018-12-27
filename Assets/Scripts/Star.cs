using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public float speed;//esta es la velocidad de la estrella

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //consigue la posicion actual de la estrella
        Vector2 position = transform.position;

        //calcula la nueva posicion de la estrella
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //actualiza la posicion de la estrella
        transform.position = position;

        //este es el punto inferior izquierdo de la pantalla
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //este es el punto superior derecho de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //si la estrella se sale de la pantalla por abajo,
        //entonces la posicion de la estrella aparece ariba de la pantalla
        //y aleatoriamente entre la izquierda y la derecha de la pantalla
        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
	}
}
