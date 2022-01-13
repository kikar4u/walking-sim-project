using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUI : MonoBehaviour
{
    public GameObject UI;
    GameObject instance;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            instance = Instantiate(UI, gameObject.transform.position + new Vector3(0,1,0), Quaternion.identity);
            instance.transform.SetParent(null, false);
            //instance.transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(instance);
        }
    }
}
