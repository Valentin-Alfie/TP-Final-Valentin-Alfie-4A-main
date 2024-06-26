using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigo : MonoBehaviour
{
    public GameObject[] Objetos;
    public int minX;
    public int maxX;
    int cantidad;
    int tipo;
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
        spawnPosicion = Objetos[tipo].transform.position;
        spawnRotacion = Objetos[tipo].transform.rotation;
        InvokeRepeating("SpawnObjeto", 0, 1);
    }

    // Update is called once per frame
    public void SpawnObjeto()
    {
        if (cantidad > 0)
        {
            Instantiate(Objetos[tipo], spawnPosicion, spawnRotacion);
            cantidad--;
        }
        else
        {
            CancelInvoke("SpawnObjeto");
        }
    }
}
