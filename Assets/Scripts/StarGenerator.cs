using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    public GameObject StarGo;//este es nuestro StarGo prefab 
    public int MaxStars;//el maximo numero de estrellas

    //arreglo de colores
    Color[] starColors = {
    new Color (0.5f, 0.5f, 1f), //azul
    new Color (0, 1f, 1f), //verde
    new Color (1f, 1f, 0), //amarillo
    new Color (1f, 0, 0), //rojo
    };

	// Use this for initialization
	void Start ()
    {
        //este es el punto inferior izquierdo de la pantalla
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));

        //este es el punto superior derecho de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));

        //loop para crear las estrellas (repeticion)
        for (int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(StarGo);

            //establecer el color de la estrella
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //establecer la posicion de la estrella (random x, random y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //marcar una velocidad random para la estrella
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            //hacer la estrella un hijo de la StarGeneratorGo
            star.transform.parent = transform;
        }
        }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
