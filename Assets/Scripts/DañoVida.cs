using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoVida : MonoBehaviour
{
    VidaPlayer playervida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        playervida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;

            if (currentDamageTime < damageTime)
            {
                playervida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


