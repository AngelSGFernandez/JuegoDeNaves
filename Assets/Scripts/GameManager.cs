using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //referiencias para nuestros game objects
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject playerShooterShip;
    public GameObject enemySpawner; //referencia a nuestro enemy spawner
    public GameObject GameOverGo; //referenca a la imagen de game over
    public GameObject scoreUITextGo; //referencia a el score text ui game object
  //public GameObject livesUITextGo; //referencia a las vidas text ui game object ***
    public GameObject GameTitleGo; //referencia a la image del game title
    public GameObject TimeCounterGo; // referencia al contador de tiempo
    public GameObject kcounterUITextGo;//referencia a el contador de muertes text ui game object
    public GameObject powerUpSpawnerGo;//referencia al power up spawner
    public GameObject YouWonGo; //reerencia a la imagen de you won
    public GameObject TryAgainButtonGo; //referencia al boton try again
    public GameObject BackToMainMenuButtonGo; //referencia al boton back to main menu
    public GameObject ShipSelectedGo; //referencia al ship selected
    public GameObject UpdateScoreGo; //referencia al boton que se encarga de actualizar el score
    //public GameObject GesionBD;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        Victory,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }
    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
        Screen.SetResolution(1366, 768, true);//1136, 640, false     Para que esto se pueda aplicar bien cambia canvas a 1136 y 640, cambia los valores de este script, en player settings vuelve a  1136 y 640, cambia la camara a 3.2, y por si acaso vuelve a free aspect
        transform.localScale += new Vector3(1.0F, 0, 0);
    }

    //metodo para actualizar el estado del game manager
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                //ocultar you won
                YouWonGo.SetActive(false);

                //ocultar game over
                GameOverGo.SetActive(false);

                //muestra el game title
                GameTitleGo.SetActive(true);

                //hace visible el boton de play (active)
                playButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                //reinicia la cantidad de kills
                kcounterUITextGo.GetComponent<KillCounter>().Kcounter = 0;

                //reinicia el score
                scoreUITextGo.GetComponent<GameScore>().Score = 0;

                //oculta el boton de play sobre el estado game play
                playButton.SetActive(false);

                //oculta el game title
                GameTitleGo.SetActive(false);

                //vuelve al jugador visible (active)
                //playerShip.GetComponent<PlayerControl>().Init();
                //inicia el power up aunque aparezca 

                //inicia las vidas
                //playerShip.GetComponent<PlayerControl>().InitLives();

                ShipSelectedGo.GetComponent<ShipSelected>().PlayShip();

                //inicia el enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                //inicia el powerup spawner
                powerUpSpawnerGo.GetComponent<PowerUpSpawner>().SchedulePowerUpSpawner();

                //inicia el contador de tiempo
                TimeCounterGo.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:

                //detiene el contador de tiempo
                TimeCounterGo.GetComponent<TimeCounter>().StopTimeCounter();

                playerShooterShip.GetComponent<PlayerControl>().HideShip();

                //detiene el enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //detiene el powerup spawner
                powerUpSpawnerGo.GetComponent<PowerUpSpawner>().UnschedulePowerUpSpawner();

                //muestra game over
                GameOverGo.SetActive(true);

                //GetComponent<GameScore>().ScoreStr;

                //scoreUITextGo.GetComponent<GameScore>().Score = GesionBD.GetComponent<GestionBD>().n;

                //activa los botones
                Invoke("Wait4Seconds", 4f);
                break;

            case GameManagerState.Victory:

                //detiene el contador de tiempo
                TimeCounterGo.GetComponent<TimeCounter>().StopTimeCounter();

                playerShooterShip.GetComponent<PlayerControl>().HideShip();

                //detiene el enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //detiene el powerup spawner
                powerUpSpawnerGo.GetComponent<PowerUpSpawner>().UnschedulePowerUpSpawner();

                //muestra you won
                YouWonGo.SetActive(true);

                UpdateScoreGo.GetComponent<HSController>().SubmitScoreSinLoad();

                //cambia el estado de game manager al estado opening despues de 8 segundos
                Invoke("ChangeToOpeningState", 8f);
                break;


            case GameManagerState.Level1:

                break;

            case GameManagerState.Level2:

                break;

            case GameManagerState.Level3:

                break;

            case GameManagerState.Level4:

                break;

            case GameManagerState.Level5:

                break;
        }
    }

    //metodo para marcar el estado de game manager
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //nuestro boton de Play llamara a este metodo
    //cuando el usuario omprime el boton:
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //metodo para cambiar el estado de game manager al estado opening
    public void ChangeToOpeningState()
    {
        //(GameManagerState.Opening);
        SceneManager.LoadScene("LevelSelector"); //la nave al hacer respawn no se genera donde murio
    }

    public void Wait4Seconds()
    {
        //muestra el boton try again
        TryAgainButtonGo.SetActive(true);

        //muestra el boton para regresar al menu principal
        BackToMainMenuButtonGo.SetActive(true);
    }
}

