using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HSController : MonoBehaviour
{
    public Text textusuario;
    public Text textScore;
    public static bool NameSet = false;
    public static string uss;

    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://localhost/unity_test/addscore.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://localhost/unity_test/display.php";

    void Start()
    {
        //StartCoroutine(GetScores());
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    public void SubmitName()
    {
        uss = textusuario.text;
        NameSet = true;
        //GetComponent<GestionBD>().iniciarSesion();
    }

    public void SubmitScore() {
        //string uss = textusuario.text;
        int score;
        int.TryParse(textScore.text, out score);
        if(NameSet == true)
        {
            StartCoroutine(PostScores(uss, score));
        }
        SceneManager.LoadScene("MenuConLog");
    }

    public void SubmitScoreSinLoad()
    {
        //string uss = textusuario.text;
        int score;
        int.TryParse(textScore.text, out score);
        if (NameSet == true)
        {
            StartCoroutine(PostScores(uss, score));
        }
    }

    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string uss, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = Md5Sum(uss + score + secretKey);

        string post_url = addScoreURL + "uss=" + WWW.EscapeURL(uss) + "&nScore=" + score + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    public void ShowScores()
    {
        StartCoroutine(GetScores());

    }

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        gameObject.GetComponentInChildren<Text>().text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = hs_get.text; // this is a GUIText that will display the scores in game.

        }
    }
}
