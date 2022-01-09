using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

//    // Update is called once per frame
    void Update()
    {
        //Quaternion.LookRotation(transform.position - player.transform.position);
        transform.LookAt(player.transform);
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }
}
