using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;//un arreglo de los prefabs de PlanetGo

    //cola para controlar los planetas
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

	// Use this for initialization
	void Start () {

        //añadir los planetas a la cola (encolarlos)
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        //llama al metodo MovePlanetDown cada 20 segundos
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //metodo para desencolar un planeta, y establecer su isMoving a true
    //entonces que el planeta empiece a moverse hacia abajo
    void MovePlanetDown()
    {
        EnqueuePlanets();

        //si la cola esta vacia, entonces regresar
        if (availablePlanets.Count == 0)
            return;

        //conseguir un planeta desde la cola
        GameObject aPlanet = availablePlanets.Dequeue();

        //establecer el planeta isMoving a true
        aPlanet.GetComponent<Planet>().isMoving = true;
    }
        //metodo para encolar planetas que estan abajo de la pantalla y no se mueven
        void EnqueuePlanets()
        {
            foreach(GameObject aPlanet in Planets)
            {
            //si el planeta esta abajo de la pantalla, y el planeta no se mueve
             if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                //reiniciar la posicion del planeta
                aPlanet.GetComponent<Planet>().ResetPosition();

                //encolar el planeta
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
       
}
