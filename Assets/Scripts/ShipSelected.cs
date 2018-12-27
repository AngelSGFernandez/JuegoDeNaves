using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelected : MonoBehaviour {

    public GameObject PlayerGo;
    public GameObject Player2Go;
    public GameObject Player3Go;
    public GameObject Player4Go;

    public void PlayShip()
    {
       // Select();
        //si la nave seleccionada es igual a 0 (Centella)
        if (ShipSelectorControl.select == 0)
        {
            PlayerGo.GetComponent<PlayerControl>().Init();
            PlayerGo.GetComponent<PlayerControl>().InitLives();
        }
        //si la nave seleccionada es igual a 1 (Zinnia)
        else if (ShipSelectorControl.select == 1)
        {
            Player2Go.GetComponent<PlayerControl>().Init();
            Player2Go.GetComponent<PlayerControl>().InitLives();
        }
        //si la nave seleccionada es igual a 2 (AlliumUrsinum)
        else if (ShipSelectorControl.select == 2)
        {
            Player3Go.GetComponent<PlayerControl>().Init();
            Player3Go.GetComponent<PlayerControl>().InitLives();
        }
        //si la nave seleccionada es igual a 3 (TitanArum)
        else if (ShipSelectorControl.select == 3)
        {
            Player4Go.GetComponent<PlayerControl>().Init();
            Player4Go.GetComponent<PlayerControl>().InitLives();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
