using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 0.06f;
    float zoom = 10.0f;
    float rotateSpeed = 0.1f;

    float maxHigh = 40f;
    float minHigh =4f;

    Vector2 p1;
    Vector2 p2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            float speed = 0.06f;
            float zoom = 20.0f;
        }
        else 
        {
            float speed = 0.035f;
            float zoom = 10.0f;
        }
        float hsp = transform.position.y *speed * Input.GetAxis("Horizontal");
        float vsp = transform.position.y *speed * Input.GetAxis("Vertical");
        float scrollsp = Mathf.Log(transform.position.y)* -zoom * Input.GetAxis("Mouse ScrollWheel");

        if((transform.position.y >= maxHigh) && (scrollsp > 0)) 
        {
            scrollsp = 0;
        }else if((transform.position.y <= minHigh) && (scrollsp < 0)) 
        {
            scrollsp = 0;
        } if(transform.position.y + scrollsp> maxHigh) 
        {
            scrollsp = maxHigh - transform.position.y;
        }else if (transform.position.y + scrollsp < minHigh) 
        {
            scrollsp = minHigh - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollsp, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 fowardMove = transform.forward;
        fowardMove.y = 0;
        fowardMove.Normalize();
        fowardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + fowardMove;

        transform.position += move;
        getCameraRotation();
    }
    private void getCameraRotation() 
    {
        if (Input.GetMouseButtonDown(2)) 
        {
            p1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(2)) 
        {
            p2 = Input.mousePosition;

            float dx = (p1 - p2).x * rotateSpeed;
            float dy = (p2 - p2).y * rotateSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0)); //Rotacion en Y

        }
    }
}
