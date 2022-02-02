using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enigme : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] DOOR door;
    private List<DOOR> listDoor;
    [SerializeField] bool movableObject = false;
    [SerializeField] List<MovableObject> arrMovObj = new List<MovableObject>();
    [SerializeField] public LightsFeedBackEnigma[] feedBackLights;
    [SerializeField] public List<ActiveLight> mustActiveLights;
    public bool isActivated;
    private bool lightsAreOn;
    // Start is called before the first frame update
    void Start()
    {
        lightsAreOn = false;
        isActivated = false;
        if(door != null)
        {
            id = door.id;
        }
        
    }
    private void OnTriggerStay(Collider other)
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
        if(other.CompareTag("Player") && arrMovObj.Count == 0 && mustActiveLights.Count == 0  && !isActivated)
        {
            other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = true;
            other.gameObject.GetComponent<_RayCastEnigma>().currentID = id;
            other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = door;
        }
        else if (other.CompareTag("Player") && (mustActiveLights.Count > 0  || movableObject == true) && !isActivated)
        {
            if (other.CompareTag("Player") && movableObject == true && !isActivated)
            {

                other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = true;
                other.gameObject.GetComponent<_RayCastEnigma>().currentID = id;
                other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = door;

            }
            else
            {
                int i = 0;
                while (i < mustActiveLights.Count)
                {
                    if (mustActiveLights[i].isActive)
                    {
                        Debug.Log("lights are true");
                        lightsAreOn = true;
                    }
                    else
                    {
                        lightsAreOn = false;
                    }
                    i++;
                }
                if (lightsAreOn)
                {
                    other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = true;
                    other.gameObject.GetComponent<_RayCastEnigma>().currentID = id;
                    other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = door;
                    
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<_RayCastEnigma>().currentID = 600;
            other.gameObject.GetComponent<_RayCastEnigma>().doorToOpen = null;
            other.gameObject.GetComponent<_RayCastEnigma>().isOnSpot = false;
        }

    }
    private void Update()
    {
        if (isActivated && feedBackLights != null && feedBackLights.Length != 0)
        {
            for (int i = 0; i < feedBackLights.Length; i++)
            {
                feedBackLights[i].isEnigma = true;
            }

        }
    }
}
