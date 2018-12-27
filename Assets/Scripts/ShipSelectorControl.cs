using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipSelectorControl : MonoBehaviour {

    //las imagenes de los triangulos (objetos)
    public GameObject SelectTriangle6Go;
    public GameObject SelectTriangle7Go;
    public GameObject SelectTriangle8Go;
    public GameObject SelectTriangle9Go;

    public delegate void ButtonAction();
    //arreglo de botones
    public MyButton[] buttonList;
    //index para saber que boton esta seleccionado
    public int selectedButton = 0;

    //variable estatica que indica el valor del boton seleccionado 
    public static int select = 0;
    public static int chose2 = 0;

    void Start()
    {
        // instanciar la cantidad de botones que estaremos usando
        buttonList = new MyButton[4];
        // Primer boton (centella). hay que set el expected onClick method, y trigger el color seleccionado 
        buttonList[0].image = GameObject.Find("CentellaShipButton").GetComponent<Image>();
        buttonList[0].image.color = Color.yellow;
        buttonList[0].action = CentellaShipButtonAction;

        // segundo boton (zinnia).
        buttonList[1].image = GameObject.Find("ZinniaShipButton").GetComponent<Image>();
        buttonList[1].image.color = Color.white;
        buttonList[1].action = ZinniaShipButtonAction;

        // tercer boton (alliumursinum).
        buttonList[2].image = GameObject.Find("AlliumUrsinumShipButton").GetComponent<Image>();
        buttonList[2].image.color = Color.white;
        buttonList[2].action = AlliumUrsinumButtonAction;

        //cuarto boton (titanarum).
        buttonList[3].image = GameObject.Find("TitanArumShipButton").GetComponent<Image>();
        buttonList[3].image.color = Color.white;
        buttonList[3].action = TitanArumButtonAction;
    }

    void Update()
    {
        //si oprimes la tecla de la derecha entonces mover al siguiente boton
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToNextButton();
        }

        //sino si oprimes la tecla de la izquierda entonces mover al boton anterior
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToPreviousButton();
        }

        //si oprimes el boton de espacio hace una accion (trabajar luego)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonList[selectedButton].action();
            chose2 = 1;
        }
        //si el boton seleccionado es el mismo valor que el señalado, aparecer o desaparecer GameObjects dependiendo
        if (selectedButton == 0)
        {
            SelectTriangle6Go.SetActive(true);
            SelectTriangle7Go.SetActive(false);
            SelectTriangle8Go.SetActive(false);
            SelectTriangle9Go.SetActive(false);
        }
        else if (selectedButton == 1)
        {
            SelectTriangle6Go.SetActive(false);
            SelectTriangle7Go.SetActive(true);
            SelectTriangle8Go.SetActive(false);
            SelectTriangle9Go.SetActive(false);
        }
        else if (selectedButton == 2)
        {
            SelectTriangle6Go.SetActive(false);
            SelectTriangle7Go.SetActive(false);
            SelectTriangle8Go.SetActive(true);
            SelectTriangle9Go.SetActive(false);
        }
        else if (selectedButton == 3)
        {
            SelectTriangle6Go.SetActive(false);
            SelectTriangle7Go.SetActive(false);
            SelectTriangle8Go.SetActive(false);
            SelectTriangle9Go.SetActive(true);
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
    public void CentellaShipButtonAction()
    {
        //selectedButton = 0;
        Debug.Log("Centella!");
        select = 0;
    }

    //este es un metodo que se activa si lo llaman y dice "Options"
    public void ZinniaShipButtonAction()
    {
        //selectedButton = 1;
        Debug.Log("Zinnia!");
        select = 1;
    }

    //este es un metodo que se activa si lo llaman y dice "Play"
    public void AlliumUrsinumButtonAction()
    {
        //selectedButton = 2;
        Debug.Log("Ursinum!");
        select = 2;
    }

    //este es un metodo que se activa si lo llaman y dice "Options"
    public void TitanArumButtonAction()
    {
        //selectedButton = 3;
        Debug.Log("Arum!");
        select = 3;
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