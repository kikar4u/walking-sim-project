using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enigme : MonoBehaviour
{
    public Vector3 rotationToHave;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    private void OnTriggerExit(Collider other)
    {

            other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = false;
    }
}
