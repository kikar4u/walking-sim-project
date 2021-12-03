using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    [SerializeField]
    private Transform Destination;

    
    private void OnMouseDown()
    {
        Destination = GameObject.FindGameObjectWithTag("Destination").transform;
        GetComponent<MeshCollider>().isTrigger = true;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = GameObject.Find("Destination").transform;
        this.transform.position = Destination.position;
        
    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<MeshCollider>().isTrigger = false;

    }
}
