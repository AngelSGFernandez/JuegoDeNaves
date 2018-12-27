using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour {

    Text kcounterTextUI;

    public GameObject GameManagerGo;
    public GameObject PlayerGo;
    public GameObject ShooterPlayerGo;
    public GameObject EnemyGo;

    int kcounter;

    public int Kcounter
    {
        get
        {
            return this.kcounter;
        }
        set
        {
            this.kcounter = value;
            UpdateKillCounterTextUI();
        }
    }

    // Use this for initialization
    void Start()
    {
        //cosnsigue el component text ui de este game object
        kcounterTextUI = GetComponent<Text>();
    }

    void Update()
    {

    }

    //metodo para actualizar el contador de muertes text ui
    void UpdateKillCounterTextUI()
    {
        string kcounterStr = string.Format("{0:00}", kcounter);
        kcounterTextUI.text = kcounterStr;
        int kcounterInt = 0;
            //converimos el valor string a un valor int para poder comparar la cantidad de kills
            bool isSuccess = int.TryParse(kcounterStr, out kcounterInt);
        if (isSuccess)
        {
            //si la escena es GameEngine
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameEngine"))
            {
                {
                    if (kcounterInt >= 35)
                    {
                        kcounterStr = "35";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            //si la escenea es Level01
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level01"))
            {
                {
                    if (kcounterInt >= 35)
                    {
                        kcounterStr = "35";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            //si la escena es level02
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level02"))
            {
                {
                    if (kcounterInt >= 50)
                    {
                        kcounterStr = "50";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level03"))
            {
                {
                    if (kcounterInt >= 65)
                    {
                        kcounterStr = "65";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level04"))
            {
                {
                    if (kcounterInt >= 80)
                    {
                        kcounterStr = "80";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level05"))
            {
                {
                    if (kcounterInt >= 99)
                    {
                        kcounterStr = "99";
                        kcounterTextUI.text = kcounterStr;
                        GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                        //PlayerGo.gameObject.SetActive(false);
                        //ShooterPlayerGo.gameObject.SetActive(false);
                        EnemyGo.GetComponent<EnemyControl>().KillAll();
                    }
                }
            }
            /*
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "GameEngine")
            {
                if (kcounterInt >= 35)
                {
                    GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                    //PlayerGo.gameObject.SetActive(false);
                    //ShooterPlayerGo.gameObject.SetActive(false);
                    EnemyGo.GetComponent<EnemyControl>().KillAll();
                }
            } else if (sceneName == "Level01")
            {
                if (kcounterInt >= 40)
                {
                    GameManagerGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Victory);
                    //PlayerGo.gameObject.SetActive(false);
                    //ShooterPlayerGo.gameObject.SetActive(false);
                    EnemyGo.GetComponent<EnemyControl>().KillAll();
                }
            }*/
        }
    }
}
