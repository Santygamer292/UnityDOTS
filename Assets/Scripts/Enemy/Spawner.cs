using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Transform[] TargetTransforms;

    public GameObject EspanolPrefab;
    public int NumEspanol;
    public Vector2 Bounds;

    public void Start()
    {
        Random.InitState(123);

        for (int i = 0; i < NumEspanol; i++)
        {
            GameObject go = GameObject.Instantiate(EspanolPrefab);
            Espanol espanol = go.GetComponent<Espanol>();
            Vector2 dir = Random.insideUnitCircle;
            espanol.Direction = new Vector3(dir.x, 0, dir.y);
            go.transform.localPosition = new Vector3(
                Random.Range(0, Bounds.x), 0, Random.Range(0, Bounds.y));
        }
    }
}
