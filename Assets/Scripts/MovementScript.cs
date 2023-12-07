using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{
    public Rigidbody body;
    public Vector3 pPos;
    public int pPosX;
    public int pPosY;
    public float pPosHight;
    public float pSpeed;
    public float timer;
    public CreateGrid pGrid;

    public bool[] lockInput = new bool[4];

    void Start()
    {
        transform.position = new Vector3(pGrid.grid[0, 0].x, pPosHight, pGrid.grid[0, 0].z);
        body= gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.anyKey && timer==0)
        {
            Move();
        }
        if (transform.position != pGrid.grid[(int)pPos.x, (int)pPos.z])
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(pGrid.grid[(int)pPos.x, (int)pPos.z].x, pPosHight, pGrid.grid[(int)pPos.x, (int)pPos.z].z), pSpeed * Time.deltaTime);
        }
        if (timer != 0)
        { timer -= 1; }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pPos += body.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pPos -= body.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pPos += body.transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pPos -= body.transform.right;
        }

        pPos.x = Math.Clamp(pPos.x, -0.1f, pGrid.gridLength - 0.9f);
        pPos.z = Math.Clamp(pPos.z, -0.1f, pGrid.gridWidth - 0.9f);
    }
}
