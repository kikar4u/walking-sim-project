using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    [SerializeField]
    public Transform Destination;

    private void OnMouseDown()
    {
        GetComponent<MeshCollider>().isTrigger = true;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<MeshCollider>().isTrigger = false;

    }
}
