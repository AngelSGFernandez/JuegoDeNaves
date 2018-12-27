using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour //Script para la generacion de los power ups
{
    public GameObject StarShooterGo; //este es nuestro prefab star shooter
    public GameObject MoonShieldGo; //estes es nuestro prefab moon shield

    float maxSpawnRateInSeconds = 40f;

    void Update()
    {

    }
    //metodo para generar un power up
    void Spawn1PowerUp()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Esquina superior derecha de la pantalla

        //instanciar los power ups
        GameObject anPowerUp = (GameObject)Instantiate(StarShooterGo);
        
        anPowerUp.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //registro de la generacion del siguiente enemigo
        ScheduleNext1PowerUpSpawn();
    }

    void Spawn2PowerUp()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Esquina inferior izquierda de la pantalla
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Esquina superior derecha de la pantalla

        //instanciar los power ups
        GameObject twoPowerUp = (GameObject)Instantiate(MoonShieldGo);

        twoPowerUp.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //registro de la generacion del siguiente enemigo
        ScheduleNext2PowerUpSpawn();
    }

    //metodo para generar el siguiente enemigo
    void ScheduleNext1PowerUpSpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 45f)
        {
            //escoge un numero entre 1 y la variable maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 60f;

        Invoke("Spawn1PowerUp", spawnInNSeconds);
    }
    void ScheduleNext2PowerUpSpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 40f)
        {
            //escoge un numero entre 1 y la variable maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 55f;

        Invoke("Spawn2PowerUp", spawnInNSeconds);
    }

    //metodo para iniciar la generacion de powerups
    public void SchedulePowerUpSpawner()
    {
        //reiniciar el ratio de generacion de powerups
        maxSpawnRateInSeconds = 40f;

        Invoke("Spawn1PowerUp", maxSpawnRateInSeconds);
        Invoke("Spawn2PowerUp", maxSpawnRateInSeconds);
    }

    //metodo para detener la generacion de powerups
    public void UnschedulePowerUpSpawner()
    {
        CancelInvoke("Spawn1PowerUp");
        CancelInvoke("Spawn2PowerUp");
    }
}