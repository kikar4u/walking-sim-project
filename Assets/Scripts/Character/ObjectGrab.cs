using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    [SerializeField]
    private Transform Destination;
    
    
    private void OnMouseDown()
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var objectPosition = this.transform.position;
        
        if (objectPosition.x - playerPosition.x <= 3 && objectPosition.x - playerPosition.x >= -3
            && objectPosition.z - playerPosition.z <= 3 && objectPosition.z - playerPosition.z >= -3)
        {
            Destination = GameObject.FindGameObjectWithTag("Destination").transform;
            GetComponent<MeshCollider>().isTrigger = true;
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = GameObject.Find("Destination").transform;
            this.transform.position = Destination.position;
        }

        
    }
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<MeshCollider>().isTrigger = false;

    }
}
