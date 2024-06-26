using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigo : MonoBehaviour
{
    public GameObject[] Objetos;
    public int minX;
    public int maxX;
    int cantidad;
    int SpawnsRestantes;
    int tipo;
    public GameObject panelRespuesta;
    public GameObject panelError;
    public GameObject panelNotificaciones;
    public InputField inputResultado;
    public Text textoNotificaciones;

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
        Objetos[tipo].SetActive(true);
        cantidad = Random.Range(minX, maxX);
        SpawnsRestantes = cantidad;
        spawnPosicion = Objetos[tipo].transform.position;
        spawnRotacion = Objetos[tipo].transform.rotation;
        InvokeRepeating("SpawnObjeto", 1, 1);
        panelRespuesta.SetActive(true);
        panelError.SetActive(false);
        panelNotificaciones.SetActive(false);
    }

    // Update is called once per frame
    public void SpawnObjeto()
    {
        if (SpawnsRestantes > 0)
        {
            Instantiate(Objetos[tipo], spawnPosicion, spawnRotacion);
            SpawnsRestantes--;
        }
        else
        {
            CancelInvoke("SpawnObjeto");
        }
    }

    public void Respuesta()
    {
        string resultado = inputResultado.text;
        if (resultado == "")
        {
            panelError.SetActive(true);
            panelRespuesta.SetActive(false);
        }
        else
        {
            int resultadoInt = int.Parse(resultado);
            if (resultadoInt == cantidad + 1)
            {
                panelNotificaciones.SetActive(true);
                panelRespuesta.SetActive(false);
                textoNotificaciones.text = "LA RESPUESTA ES CORRECTA!";
            }
            else
            {
                panelNotificaciones.SetActive(true);
                panelRespuesta.SetActive(false);
                textoNotificaciones.text = "LA RESPUESTA ES INCORRECTA!";
            }
        }
    }

    public void BotonError()
    {
        panelError.SetActive(false);
        panelRespuesta.SetActive(true);
    }

    public void BotonNotificaciones()
    {
        panelNotificaciones.SetActive(false);
        panelRespuesta.SetActive(true);
    }
}