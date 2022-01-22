using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = Camera.main.transform;
        RaycastHit HitInfo;
        //Debug.Log(GameObject.FindGameObjectWithTag("Destination").transform.position);
        //Physics.SphereCast(cameraTransform.position, cameraTransform.position.x / 2, transform.forward, out HitInfo, 10);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 2.0f))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 2.0f, Color.red);

            if (HitInfo.transform.gameObject.GetComponent<_Picture>() != null)
            {
                if (Input.GetButtonDown("Fire1") && !GameManager.isLooking)
                {

                    var picture = HitInfo.transform.gameObject.GetComponent<_Picture>();
                    picture.rotateObject(GameObject.FindGameObjectWithTag("Destination").transform.position, 0);


                }
                else if(Input.GetButtonDown("Fire1") && GameManager.isLooking)
                {
                    
                    var picture = HitInfo.transform.gameObject.GetComponent<_Picture>();
                    picture.rotateObject(GameObject.FindGameObjectWithTag("Destination").transform.position, 1);
                }

            }
        }
    }
}
