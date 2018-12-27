using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour //Script para la generacion del Enemigo
{
    public GameObject EnemyGo; //este es nuestro prefab enemy

    float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	/*void Start () {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //aumentar la probabilidad de generacion cada 30 segundos
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}*/ //abajo (ScheduleEnemySpawner) se vuelve aescribir esta funcion por el game manager
	
	// Update is called once per frame
	void Update () {
		
	}
    //metodo para generar un enemigo
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Esquina superior derecha de la pantalla

        //instalar un enemigo
        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
        anEnemy.transform.position = new Vector2(Random.Range (min.x, max.x), max.y);

        //registro de la generacion del siguiente enemigo
        ScheduleNextEnemySpawn();
    }

    //metodo para generar el siguiente enemigo
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            //escoge un numero entre 1 y la variable maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;

        Invoke ("SpawnEnemy", spawnInNSeconds);
    }
    
    //metodo para aumentar la dificultad del juego (aumentar la cant. de enemigos)
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }

    //metodo para iniciar la generacion de enemigos
    public void ScheduleEnemySpawner()
    {
        //reiniciar el ratio de generacion de enemigos
        maxSpawnRateInSeconds = 5f;

        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //aumentar la probabilidad de generacion cada 30 segundos
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    //metodo para detener la generacion de enemigos
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
