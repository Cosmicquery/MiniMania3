using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public float mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X")!=0 || Input.GetAxis("Mouse Y") != 0)
        {
            float newMouseXV = transform.localEulerAngles.y + Input.GetAxis("Mouse X")* mouseSensitivity;
            float newMouseYV = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.localEulerAngles=new Vector3 (newMouseYV,newMouseXV, 0);
        }


    }
}
