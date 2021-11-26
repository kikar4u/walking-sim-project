using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR : MonoBehaviour
{
    
    public int id;
    

    private void Awake()
    {
        
    }
    public void OpenDoor()
    {
        gameObject.TryGetComponent<Animator>(out Animator Component);
        Component.Play("open");
    }
}
