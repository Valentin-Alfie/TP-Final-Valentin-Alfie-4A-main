using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Codigo : MonoBehaviour
{
    public GameObject[] Objetos;
    public int minX;
    public int maxX;
    int cantidad;
    int SpawnsRestantes;
    int tipo;
    string resultado;
    int resultadoInt;
    public GameObject panelRespuesta;
    public GameObject panelError;
    public GameObject panelNotificaciones;
    public InputField inputResultado;
    public Text textoNotificaciones;
    public Text textoJugarOtraVez;

    Vector3 spawnPosicion;
    Quaternion spawnRotacion;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Objetos.Length; i++)
        {
            Objetos[i].SetActive(false);
        }
        tipo = Random.Range(0, 26);
        cantidad = Random.Range(minX, maxX);
        SpawnsRestantes = cantidad;
        spawnPosicion = Objetos[tipo].transform.position;
        spawnRotacion = Objetos[tipo].transform.rotation;
        InvokeRepeating("SpawnObjeto", 0, 1);
        panelRespuesta.SetActive(true);
        panelError.SetActive(false);
        panelNotificaciones.SetActive(false);
    }

    // Update is called once per frame
    public void SpawnObjeto()
    {
        if (SpawnsRestantes > 0)
        {
            GameObject objetoInstanciado = Instantiate(Objetos[tipo], new Vector3(Random.Range(-10,10), 0 , Random.Range(-10, 10)), new Quaternion(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360), 0));
            objetoInstanciado.SetActive(true);
            SpawnsRestantes--;
        }
        else
        {
            CancelInvoke("SpawnObjeto");
        }
    }

    public void Respuesta()
    {
        resultado = inputResultado.text;
        if (resultado == "")
        {
            panelError.SetActive(true);
            panelRespuesta.SetActive(false);
        }
        else
        {
            resultadoInt = int.Parse(resultado);
            if (resultadoInt == cantidad)
            {
                panelNotificaciones.SetActive(true);
                panelRespuesta.SetActive(false);
                textoNotificaciones.text = "LA RESPUESTA ES CORRECTA!";
                textoJugarOtraVez.text = "REINICIAR DESAFIO";

            }
            else
            {
                panelNotificaciones.SetActive(true);
                panelRespuesta.SetActive(false);
                textoNotificaciones.text = "LA RESPUESTA ES INCORRECTA!";
                textoJugarOtraVez.text = "VOLVER A INTENTARLO";
            }
        }
    }

    public void BotonError()
    {
        panelError.SetActive(false);
        panelRespuesta.SetActive(true);
    }

    public void BotonJugarOtraVez()
    {
        if (resultadoInt == cantidad) {
            SceneManager.LoadScene("Cuantos hay");
        }
        else
        {
            panelNotificaciones.SetActive(false);
            panelRespuesta.SetActive(true);
        }
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("SeleccionarJuegos");
    }
}