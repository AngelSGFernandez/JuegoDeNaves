using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatesManager : MonoBehaviour {

    //game objects de las naves y su estado
    public GameObject PlayerGo;
    public GameObject ShooterPlayerGo;
    
    //variable para reconocer el estado del jugador
    public int whichStateIsOn = 1;

    // Use this for initialization
    void Start () {
        
    }

    //metodo para cambiar el estado del jugador
    public void PlayerGoStates()
    {
        //detecta el estado del jugador
        switch (whichStateIsOn)
        {
            //si el primer estado esta activo
            case 1:

                //entonces activamos el segundo
                whichStateIsOn = 2;

                //desactivamos el primero y activamos el segundo
                PlayerGo.gameObject.SetActive(false);
                ShooterPlayerGo.gameObject.SetActive(true);
                break;

            // si el segundo estado esta activo
            case 2:

                // entocnes activamos el primero
                whichStateIsOn = 1;

                //desactivamos el segundo y activamos el primero
                PlayerGo.gameObject.SetActive(true);
                ShooterPlayerGo.gameObject.SetActive(false);
                break;
        }
    }
	
    public void PlayerGoNormalState()
    {
        // entocnes activamos el primero
        whichStateIsOn = 1;
        
        StartCoroutine("DoPlayerGoNormalState");
        //desactivamos el segundo y activamos el primero
        //PlayerGo.gameObject.SetActive(true); //PlayerGo.GetComponent<Renderer>().enabled = true;
        //ShooterPlayerGo.gameObject.SetActive(false); //ShooterPlayerGo.GetComponent<Renderer>().enabled = false;
    }

    public void PlayerGoShooterState()
    {
        //entonces activamos el segundo
        whichStateIsOn = 2;

        StartCoroutine("DoPlayerGoShooterState");
        //desactivamos el primero y activamos el segundo
        //PlayerGo.gameObject.SetActive(false); //PlayerGo.GetComponent<Renderer>().enabled = false;
        //ShooterPlayerGo.gameObject.SetActive(true); //ShooterPlayerGo.GetComponent<Renderer>().enabled = true;
    }

	// Update is called once per frame
	void Update () {
        //el estado de PlayerGo siempre sera el mismo que el de Shooter
		if(PlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn == 1)
        {
            ShooterPlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn = 1;
        } else if (PlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn == 2)
            {
            ShooterPlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn = 2;
        }
        if (ShooterPlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn == 1)
        {
            PlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn = 1;
        }
        else if (ShooterPlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn == 2)
        {
            PlayerGo.GetComponent<PlayerStatesManager>().whichStateIsOn = 2;
        }

    }

    IEnumerator DoPlayerGoNormalState()//metodo para dejar de ser invisible
    {
        yield return new WaitForSeconds(0f);
        Physics2D.IgnoreLayerCollision(0, 0, false);
        GetComponent<PlayerControl>().c.a = 1f;
        GetComponent<PlayerControl>().rend.material.color = GetComponent<PlayerControl>().c;
        //desactivamos el segundo y activamos el primero
        PlayerGo.gameObject.SetActive(true);
        ShooterPlayerGo.gameObject.SetActive(false);
    }

    IEnumerator DoPlayerGoShooterState()//metodo para dejar de ser invisible
    {
        yield return new WaitForSeconds(0f); 
        Physics2D.IgnoreLayerCollision(0, 0, false);
        GetComponent<PlayerControl>().c.a = 1f;
        //desactivamos el segundo y activamos el segundo
        GetComponent<PlayerControl>().rend.material.color = GetComponent<PlayerControl>().c;
        PlayerGo.gameObject.SetActive(false);
        ShooterPlayerGo.gameObject.SetActive(true);
    }
}
