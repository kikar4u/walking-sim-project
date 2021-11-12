using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosObject : MonoBehaviour
{
    [SerializeField]
    public int idObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MovableObject" )
        {
            other.GetComponent<MovableObject>().isOnPlace = true;
            Debug.Log("LE DEMON MDR");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovableObject")
        {
            other.GetComponent<MovableObject>().isOnPlace = false;
            Debug.Log("LE DEMON plus la");
        }
    }
}
