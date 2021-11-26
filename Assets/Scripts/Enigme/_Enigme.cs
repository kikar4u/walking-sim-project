using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enigme : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] DOOR door;
    [SerializeField] bool movableObject = false;
    [SerializeField] List<MovableObject> arrMovObj = new List<MovableObject>();
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        if(door != null)
        {
            id = door.id;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (MovableObject item in arrMovObj)
        {
            if (!item.isOnPlace)
            {
                movableObject = false;
                break;
            }
            else
            {
                movableObject = true;
            }
           
        }
        if(other.tag == "Player" && arrMovObj.Count == 0)
        {
            other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = true;
            other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = door;
        }
        else if(other.tag == "Player" && movableObject == true)
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
