using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text timeUI; //referencia al texto que cuenta el tiempo

    float startTime;//el tiempo cuando el jugador empieza a jugar (clicks on play)
    float ellapsedTime;//el lapso de tiempo despues de que el jugador empieza a jugar
    bool startCounter;

    int minutes;
    int seconds;

	// Use this for initialization
	void Start ()
    {
        startCounter = false;

        //consigue el componente del Text UI desde este gameObject
        timeUI = GetComponent<Text>();
	}
	
    //metodo para empezar el contador de tiempo
    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    //metodo para parar el contador de tiempo
    public void StopTimeCounter()
    {
        startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCounter)
        {
            //calcula el tiempo transcurrido
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;//consigue los minutos
            seconds = (int)ellapsedTime % 60;//consigue los segundos

            //actualiza el contador de tiempo (text UI)
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
