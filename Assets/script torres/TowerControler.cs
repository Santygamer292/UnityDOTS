using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerControler : MonoBehaviour
{
    public int vidatorre;
    public Slider barravidatorre;
    public GameObject torrePrefab1;
    public GameObject torrePrefab2;
    public GameObject torrePrefab3;
    public GameObject torrePrefab4;

    void Update()
    {
        dañotorre();
    }

    void InstanciarNuevaTorre(GameObject torrePrefab)
    {
        Instantiate(torrePrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
     public void dañotorre() 
    {
        barravidatorre.value = vidatorre;
        vidatorre = vidatorre - 10;

        switch (vidatorre)
        {
            case 50:
                InstanciarNuevaTorre(torrePrefab1);
                break;
            case 30:
                InstanciarNuevaTorre(torrePrefab2);
                break;
            case 20:
                InstanciarNuevaTorre(torrePrefab3);
                break;
            case 10:
                InstanciarNuevaTorre(torrePrefab4);
                break;
        }
    } 
}

