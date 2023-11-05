using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEspanol : MonoBehaviour
{
    public static Transform[] TargetTransforms;

    public GameObject EspanolPrefab;
    public int NumEspanol;
    public Vector2 Bounds;
    public Transform spawnPoint; // Objeto vac�o que sirve como punto de aparici�n

    public void Start()
    {
        Random.InitState(123);

        for (int i = 0; i < NumEspanol; i++)
        {
            GameObject go = GameObject.Instantiate(EspanolPrefab);
            Espanol espanol = go.GetComponent<Espanol>();
            Vector2 dir = Random.insideUnitCircle;
            espanol.Direction = new Vector3(dir.x, 0, dir.y);

            // Utiliza la posici�n del objeto vac�o como punto de aparici�n
            go.transform.position = spawnPoint.position + new Vector3(
                Random.Range(-Bounds.x, Bounds.x), 0, Random.Range(-Bounds.y, Bounds.y));
        }
    }
}

