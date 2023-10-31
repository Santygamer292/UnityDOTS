using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    private Quaternion originlLocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originlLocalRotation = transform.localRotation;
    }
    // Update is called once per frame
    void Update()
    {
        updateSway();
    }
    private void updateSway() 
    {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");
        //Calcular la rotación del arma
        Quaternion t_xAngleAdjusment = Quaternion.AngleAxis(-t_xLookInput * 1.45f , Vector3.up);
        Quaternion t_yAngleAdjusment = Quaternion.AngleAxis(t_yLookInput * 1.45f , Vector3.right);
        Quaternion t_targetRotation = originlLocalRotation * t_xAngleAdjusment * t_yAngleAdjusment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targetRotation, Time.deltaTime * 10f);
    }
}
