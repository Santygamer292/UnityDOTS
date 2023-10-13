using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadrotacion = 5f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0, vertical);
        movimiento.Normalize();
        transform.position = transform.position + movimiento * velocidad * Time.deltaTime;

        if (movimiento != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimiento), velocidadrotacion * Time.deltaTime);
    }
}
