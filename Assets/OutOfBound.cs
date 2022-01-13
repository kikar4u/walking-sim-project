using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private Vector3 lastPos;
    private void Start()
    {
        lastPos = gameObject.transform.position;   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enigmeTri")
        {
            lastPos = gameObject.transform.position;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "OOB")
        {
            gameObject.transform.position = lastPos;
        }

    }

}
