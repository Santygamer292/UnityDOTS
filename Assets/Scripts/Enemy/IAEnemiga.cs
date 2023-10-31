using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemiga : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capajugador;
    public Transform jugador;
    public float velocidad;
    bool estarAlerta;

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capajugador);

        if (estarAlerta == true)
        {
            //transform.LookAt(jugador);
            Vector3 posjugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posjugador);
            transform.position = Vector3.MoveTowards(transform.position, posjugador, velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }

}
