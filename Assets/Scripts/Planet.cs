using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float speed;//la velocidad del planeta
    public bool isMoving;//para hacer que el planeta se mueva hacia abajo

    Vector2 min;//este es el punto inferior izquierdo de la pantalla
    Vector2 max;//este es el punto superior derecho de la pantalla

    void Awake()
    {
        isMoving = false;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //añadir la mitad del tamaño del sprite para max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        //sustraer la mitad del tamaño del sprite para min y
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMoving)
            return;

        //consigue la posicion actual del planeta
        Vector2 position = transform.position;

        //calcula la nueva posicion del planeta
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //actualiza la posicion del planeta
        transform.position = position;

        //si el planeta consigue estar en la minima posicion de y, entonces parar su movimiento
        if(transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    //metodo para reiniciar la posicion del planeta
    public void ResetPosition()
    {
        //reinicia la posicion del planeta a random x, y a max y
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
