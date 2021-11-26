using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR : MonoBehaviour
{
    
    public int id;
    [HideInInspector]
    public List<_Enigme> enigmeList;

    private void Awake()
    {
        
    }
    private void Start()
    {
        enigmeList = new List<_Enigme>();
        GameObject[] arrG = GameObject.FindGameObjectsWithTag("enigmeTri");
        foreach (GameObject item in arrG)
        {
            if(item.GetComponent<_Enigme>().id == id)
            {
                enigmeList.Add(item.GetComponent<_Enigme>());
            }
        }
    }
    public void OpenDoor()
    {
        if (enigmeList.Find((x) => x.isActivated == false))
        {
            Debug.Log("Pas toutes les énigmes");
        }
        else
        {
            
            gameObject.TryGetComponent<Animator>(out Animator Component);
            Component.Play("open");
        }

    }
}
