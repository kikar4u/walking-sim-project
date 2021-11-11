using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enigme : MonoBehaviour
{
    [SerializeField]
    Vector3 rotationToHave;
    [SerializeField] int id;
    [SerializeField] DOOR door;
    // Start is called before the first frame update
    void Start()
    {
        id = door.id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = true;
            other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = door;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = null;
        other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = false;
    }
}
