using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionBD : MonoBehaviour
{
    public InputField txtUsuario;
    public InputField txtContrasena;
    public string nombreUsuario;
    public int scoreUsuario;
    public int idUsuario;
    public bool sesionIniciada = false;
    public static GestionBD singleton;

    /// Respuestas WEB
    /// 400 -   No pudo establecer conexion
    /// 401 -   No encontro datos
    /// 402 -   El usuario ya existe
    /// 200 -   Datos se han encontrado
    /// 201 -   Usuario registrado
    /// 202 -   Score actualizado
    public void Awake()///Se ejecuta antes de que inicie el start
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        //    DontDestroyOnLoad(this.gameObject);
    }

    public void iniciarSesion()
    {
        StartCoroutine(login());

    }

    public void RegistrarUsuario()
    {
        StartCoroutine(Registrar());
    }
    public void EliminararUsuario()
    {
        StartCoroutine(Eliminar());
    }

    public void Score_Actualizar(int nScore)
    {
        StartCoroutine(ActualizarScore(nScore));
    }
    IEnumerator login()
    {
        GetComponent<HSController>().SubmitName();
        WWW coneccion = new WWW("http://localhost/test/login.php?uss=" + txtUsuario.text + "&pss=" + txtContrasena.text);
        yield return (coneccion);
        if (coneccion.text == "200")
        {
            print("El usuario exite");
            StartCoroutine(datos());
        }
        else if(coneccion.text == "401")
        {
            print("Usuario o contrasena incorrectos");
        }else 
        {
            print("Error en la conexion de la base de datos");
        }
    }
    IEnumerator datos()
    {
        WWW coneccion = new WWW("http://localhost/test/datos.php?uss=" + txtUsuario.text);
        yield return (coneccion);
        if  (coneccion.text == "401")
        {
            print("Usuario incorrecto");
        }
        else
        {
            string[] nDatos = coneccion.text.Split('|');
            if (nDatos.Length != 3)
            {
                print("Error en la conexion");
            }
            else
            {
                nombreUsuario = nDatos[0];
                scoreUsuario = int.Parse(nDatos[1]);
                idUsuario = int.Parse(nDatos[2]);
                sesionIniciada = true;
                SceneManager.LoadScene("LevelSelector");
            }
        }
    }

    IEnumerator Registrar()
    {
        WWW coneccion = new WWW("http://localhost/test/registro.php?uss=" + txtUsuario.text + "&pss=" + txtContrasena.text);
        yield return (coneccion);
        if (coneccion.text == "402")
        {
            Debug.LogError("Usuario ya existe");
        }
        else if(coneccion.text == "201")
        {
                nombreUsuario = txtUsuario.text;
                scoreUsuario = 0;
                sesionIniciada = true;
            Debug.Log("Usuario registrado");
            }
        else
        {
            print(coneccion.text);
            Debug.LogError("Error en la conexion de la base de datos");
        }
    }
    IEnumerator Eliminar()
    {
        WWW coneccion = new WWW("http://localhost/test/Eliminar.php?uss=" + txtUsuario.text + "&pss=" + txtContrasena.text);
        yield return (coneccion);
        if (coneccion.text == "400")
        {
            Debug.LogError("No pudo establecer conexion");
        }
        else if (coneccion.text == "201")
        {
            Debug.LogError("Usuario borrado");
        }
        
    }

    IEnumerator ActualizarScore(int nScore)
    {
        nScore = GameScore.scoreInt;
        WWW coneccion = new WWW("http://localhost/test/score.php?uss=" + txtUsuario.text + "&nScore=" + nScore.ToString());
        yield return (coneccion);
        if (coneccion.text == "401")
        {
            Debug.LogError("Usuario no existe");
        }
        else if (coneccion.text == "202")
        {
            print("Datos actualizados correctamente");
            scoreUsuario = nScore;
        }
        else
        {
            print(coneccion.text);
            Debug.LogError("Error en la conexion de la base de datos");
        }
    }
}

