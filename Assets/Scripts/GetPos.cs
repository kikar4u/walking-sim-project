using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPos : MonoBehaviour
{
    [HideInInspector]
    public Vector3 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = gameObject.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "OOB")
        {
            gameObject.transform.position = firstPos;
            gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
