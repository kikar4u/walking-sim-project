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
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<MeshCollider>().isTrigger = false;

    }
}
