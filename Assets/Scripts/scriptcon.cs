using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptcon : MonoBehaviour
{
    public Animation clip;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("start");
        gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
