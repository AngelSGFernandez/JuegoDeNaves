using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorControl : MonoBehaviour
{
    public GameObject AfterSelectPlayButton;

    //objetos cambiantes 
    public GameObject SelectTriangle1Go;
    public GameObject SelectTriangle2Go;
    public GameObject SelectTriangle3Go;
    public GameObject SelectTriangle4Go;
    public GameObject SelectTriangle5Go;
    public GameObject InfoMarteUI;
    public GameObject InfoEuropaUI;
    public GameObject InfoSaturnoUI;
    public GameObject InfoEnceladoUI;
    public GameObject InfoTitanUI;
    public GameObject LevelTitle1Go;
    public GameObject LevelTitle2Go;
    public GameObject LevelTitle3Go;
    public GameObject LevelTitle4Go;
    public GameObject LevelTitle5Go;
    //Metodo delegate para nuestro buttonlist
    public delegate void ButtonAction();
    //arreglo de botones
    public MyButton[] buttonList;
    //index para saber que boton esta seleccionado
    public int selectedButton = 0;

    public static int select2 = 0;
    public static int chose1 = 0;

    void Start()
    {
        //AfterSelectPlayButton = GameObject.FindGameObjectWithTag("AfterSelectPlayButtonTag");

        // instanciar la cantidad de botones que estaremos usando
        buttonList = new MyButton[5];
        // Primer boton (marte). hay que set el expected onClick method, y trigger el color seleccionado 
        buttonList[0].image = GameObject.Find("MarteButton").GetComponent<Image>();
        buttonList[0].image.color = Color.yellow;
        buttonList[0].action = MarteButtonAction;

        // segundo boton (europa).
        buttonList[1].image = GameObject.Find("EuropaButton").GetComponent<Image>();
        buttonList[1].image.color = Color.white;
        buttonList[1].action = EuropaButtonAction;

        // tercer boton (saturno).
        buttonList[2].image = GameObject.Find("SaturnoButton").GetComponent<Image>();
        buttonList[2].image.color = Color.white;
        buttonList[2].action = SaturnoButtonAction;

        //cuarto boton (encelado).
        buttonList[3].image = GameObject.Find("EnceladoButton").GetComponent<Image>();
        buttonList[3].image.color = Color.white;
        buttonList[3].action = EnceladoButtonAction;

        //quinto boton (titan).
        buttonList[4].image = GameObject.Find("TitanButton").GetComponent<Image>();
        buttonList[4].image.color = Color.white;
        buttonList[4].action = TitanButtonAction;
    }

    void Update()
    {
        //si oprimes la tecla de la derecha entonces mover al siguiente boton
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToNextButton();
        }

        //sino si oprimes la tecla de la izquierda entonces mover al boton anterior
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToPreviousButton();
        }

        //si oprimes el boton de espacio hace una accion (trabajar luego)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttonList[selectedButton].action();
            chose1 = 1;
        }

        if (LevelSelectorControl.chose1 == 1 && ShipSelectorControl.chose2 == 1)
        {
            AfterSelectPlayButton.SetActive(true);
        }

        //si el boton seleccionado es el mismo valor que el señalado, aparecer o desaparecer GameObjects dependiendo
        if (selectedButton == 0)
        {
            SelectTriangle1Go.SetActive(true);
            SelectTriangle2Go.SetActive(false);
            SelectTriangle3Go.SetActive(false);
            SelectTriangle4Go.SetActive(false);
            SelectTriangle5Go.SetActive(false);
            InfoMarteUI.SetActive(true);
            InfoEuropaUI.SetActive(false);
            InfoSaturnoUI.SetActive(false);
            InfoEnceladoUI.SetActive(false);
            InfoTitanUI.SetActive(false);
            LevelTitle1Go.SetActive(true);
            LevelTitle2Go.SetActive(false);
            LevelTitle3Go.SetActive(false);
            LevelTitle4Go.SetActive(false);
            LevelTitle5Go.SetActive(false);
        }
       else if (selectedButton == 1)
        {
            SelectTriangle1Go.SetActive(false);
            SelectTriangle2Go.SetActive(true);
            SelectTriangle3Go.SetActive(false);
            SelectTriangle4Go.SetActive(false);
            SelectTriangle5Go.SetActive(false);
            InfoMarteUI.SetActive(false);
            InfoEuropaUI.SetActive(true);
            InfoSaturnoUI.SetActive(false);
            InfoEnceladoUI.SetActive(false);
            InfoTitanUI.SetActive(false);
            LevelTitle1Go.SetActive(false);
            LevelTitle2Go.SetActive(true);
            LevelTitle3Go.SetActive(false);
            LevelTitle4Go.SetActive(false);
            LevelTitle5Go.SetActive(false);
        }
        else if (selectedButton == 2)
        {
            SelectTriangle1Go.SetActive(false);
            SelectTriangle2Go.SetActive(false);
            SelectTriangle3Go.SetActive(true);
            SelectTriangle4Go.SetActive(false);
            SelectTriangle5Go.SetActive(false);
            InfoMarteUI.SetActive(false);
            InfoEuropaUI.SetActive(false);
            InfoSaturnoUI.SetActive(true);
            InfoEnceladoUI.SetActive(false);
            InfoTitanUI.SetActive(false);
            LevelTitle1Go.SetActive(false);
            LevelTitle2Go.SetActive(false);
            LevelTitle3Go.SetActive(true);
            LevelTitle4Go.SetActive(false);
            LevelTitle5Go.SetActive(false);
        }
       else if (selectedButton == 3)
        {
            SelectTriangle1Go.SetActive(false);
            SelectTriangle2Go.SetActive(false);
            SelectTriangle3Go.SetActive(false);
            SelectTriangle4Go.SetActive(true);
            SelectTriangle5Go.SetActive(false);
            InfoMarteUI.SetActive(false);
            InfoEuropaUI.SetActive(false);
            InfoSaturnoUI.SetActive(false);
            InfoEnceladoUI.SetActive(true);
            InfoTitanUI.SetActive(false);
            LevelTitle1Go.SetActive(false);
            LevelTitle2Go.SetActive(false);
            LevelTitle3Go.SetActive(false);
            LevelTitle4Go.SetActive(true);
            LevelTitle5Go.SetActive(false);
        }
        else if (selectedButton == 4)
        {
            SelectTriangle1Go.SetActive(false);
            SelectTriangle2Go.SetActive(false);
            SelectTriangle3Go.SetActive(false);
            SelectTriangle4Go.SetActive(false);
            SelectTriangle5Go.SetActive(true);
            InfoMarteUI.SetActive(false);
            InfoEuropaUI.SetActive(false);
            InfoSaturnoUI.SetActive(false);
            InfoEnceladoUI.SetActive(false);
            InfoTitanUI.SetActive(true);
            LevelTitle1Go.SetActive(false);
            LevelTitle2Go.SetActive(false);
            LevelTitle3Go.SetActive(false);
            LevelTitle4Go.SetActive(false);
            LevelTitle5Go.SetActive(true);
        }
    }

    //metodo para mover al siguiente boton
    void MoveToNextButton()
    {
        // reiniciar el actual color del boton seleccionado
        buttonList[selectedButton].image.color = Color.white;

        // incrementar el index por 1
        selectedButton++;

        // revisar que el index no se salga del arreglo
        if (selectedButton >= buttonList.Length)
        {
            // reiniciar el index
            selectedButton = 0;         
        }
        // marcar el color del boton actual seleccionado
        buttonList[selectedButton].image.color = Color.yellow;
    }

    //metodo para mover al boton anterior
    void MoveToPreviousButton()
    {
        // reiniciar el color actual del boton seleccionado
        buttonList[selectedButton].image.color = Color.white;

        // restar el index por 1 
        selectedButton--;
        if (selectedButton < 0)
        {
            selectedButton = (buttonList.Length - 1);
        }
        buttonList[selectedButton].image.color = Color.yellow;
    }

    //este es un metodo que se activa si lo llaman y dice "Play"
    void MarteButtonAction()
    {
        select2 = 0;
        //GetComponent<MenuManager>().PlayLevel();
        Debug.Log("Marte");
    }

    //este es un metodo que se activa si lo llaman y dice "Options"
    void EuropaButtonAction()
    {
        select2 = 1;
        //GetComponent<MenuManager>().PlayLevel();
        Debug.Log("Europa");
    }

    //este es un metodo que se activa si lo llaman y dice "Play"
    void SaturnoButtonAction()
    {
        select2 = 2;
        //GetComponent<MenuManager>().PlayLevel();
        Debug.Log("Saturno");
    }

    //este es un metodo que se activa si lo llaman y dice "Options"
    void EnceladoButtonAction()
    {
        select2 = 3;
        //GetComponent<MenuManager>().PlayLevel();
        Debug.Log("Encelado");
    }

    //este es un metodo que se activa si lo llaman y dice "Options"
    void TitanButtonAction()
    {
        select2 = 4;
        //GetComponent<MenuManager>().PlayLevel();
        Debug.Log("Titan");
    }

    //representa los botones individuales
    [System.Serializable]
    public struct MyButton
    {
        //hace referencia a la imagen del boton
        public Image image;
        //hace referencia a la accion del boton
        public ButtonAction action;
    }
}
