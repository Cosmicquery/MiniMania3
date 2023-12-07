using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public int collisionindex;

    public void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<MovementScript>().lockInput[collisionindex] = true;
    }
    public void OnTriggerExit(Collider other)
    {
        GetComponentInParent<MovementScript>().lockInput[collisionindex] = false;
    }
}
