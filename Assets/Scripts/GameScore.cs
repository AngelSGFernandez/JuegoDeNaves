using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

	// Use this for initialization
	void Start ()
    {
        //cosnsigue el component text ui de este game object
        scoreTextUI = GetComponent<Text> ();
	}
	
    //metodo para actualizar el score text ui
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format ("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }
}