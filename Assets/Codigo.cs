using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigo : MonoBehaviour
{
    public GameObject[] Objetos;
    public int elemento;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < Objetos.Length; i++)
        {
            Objetos[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
            {
            elemento++;
            if (27 <= elemento)
                {
                    elemento = 26;
                }
            Objetos[elemento].SetActive(true);
            Objetos[elemento-1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            elemento--;
            if (elemento < 0)
            {
                elemento = 0;
            }
            Objetos[elemento].SetActive(true);
            Objetos[elemento + 1].SetActive(false);
        } 
    }


}
