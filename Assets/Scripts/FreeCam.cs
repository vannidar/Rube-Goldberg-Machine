using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    [SerializeField]
    private float RotationX;
    [SerializeField]
    private float RotationY;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            RotationX += Input.GetAxis("Mouse X") * Time.deltaTime * 850;
            RotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * 900;
            RotationY = Mathf.Clamp(RotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(RotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(RotationY, Vector3.left);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * 10;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * (Time.deltaTime * 10);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * (Time.deltaTime * 10);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * 10);
        }
        
    }
}
