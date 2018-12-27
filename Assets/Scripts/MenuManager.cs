using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

   // GameObject AfterSelectPlayButton;

	public void selectScene()
    {
        switch (this.gameObject.name)
        {
            //inicia la escena level selector
            case "PlayButton":
                SceneManager.LoadScene("LevelSelector"); //Level01/Game Engine si quieres hacer test
                break;
            //inicia la escena score
            case "ScoreButton":
                SceneManager.LoadScene("Score");
                break;
            //inicia la escena credits
            case "CreditsButton":
                SceneManager.LoadScene("Credits");
                break;
            //salir del juego
            case "ExitButton":
                QuitGame();
                break;
            //iniciar sesion o registrarse
            case "LoginButton":
                //Aqui agregaremos lo de la ventana emergente y vincularemos con la base de datos
                break;
            //reiniciar el nivel
            case "TryAgainButton":
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameEngine"))
                {
                    SceneManager.LoadScene("GameEngine");
                }
                //si la escenea es Level01
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level01"))
                {
                    SceneManager.LoadScene("Level01");
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level02"))
                {
                    SceneManager.LoadScene("Level02");
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level03"))
                {
                    SceneManager.LoadScene("Level03");
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level04"))
                {
                    SceneManager.LoadScene("Level04");
                }
                else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level05"))
                {
                    SceneManager.LoadScene("Level05");
                }
                break;
            //volver al menu principal
            case "BackToMainMenuButton":
                //Aqui hay que agregar su version sin log
                //regresa al menu principal
                SceneManager.LoadScene("MenuSinLog");
                break;
            //iniciar el nivel en level selector
            case "AfterSelectPlayButton":
                PlayLevel();
                break;
        }
        }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void PlayLevel()
    {
        if (LevelSelectorControl.select2 == 0)
        {
            SceneManager.LoadScene("Level01");
            //reiniciamos los chose para que la siguiente vez este desactivado el boton de play
            LevelSelectorControl.chose1 = 0;
            ShipSelectorControl.chose2 = 0;
        }
        else if (LevelSelectorControl.select2 == 1)
        {
            SceneManager.LoadScene("Level02");
            //reiniciamos los chose para que la siguiente vez este desactivado el boton de play
            LevelSelectorControl.chose1 = 0;
            ShipSelectorControl.chose2 = 0;
        }
        else if (LevelSelectorControl.select2 == 2)
        {
            SceneManager.LoadScene("Level03");
            //reiniciamos los chose para que la siguiente vez este desactivado el boton de play
            LevelSelectorControl.chose1 = 0;
            ShipSelectorControl.chose2 = 0;
        }
        else if (LevelSelectorControl.select2 == 3)
        {
            SceneManager.LoadScene("Level04");
            //reiniciamos los chose para que la siguiente vez este desactivado el boton de play
            LevelSelectorControl.chose1 = 0;
            ShipSelectorControl.chose2 = 0;
        }
        else if (LevelSelectorControl.select2 == 4)
        {
            SceneManager.LoadScene("Level05");
            //reiniciamos los chose para que la siguiente vez este desactivado el boton de play
            LevelSelectorControl.chose1 = 0;
            ShipSelectorControl.chose2 = 0;
        }
    }

    // Use this for initialization
	void Start ()
    {
       // AfterSelectPlayButton = GameObject.FindGameObjectWithTag("AfterSelectPlayButtonTag");

    }

    // Update is called once per frame
    void Update ()
    {
        /*if (LevelSelectorControl.chose1 == 1 && ShipSelectorControl.chose2 == 1)
        {
            AfterSelectPlayButton.SetActive(true);
        }*/
    }
}
