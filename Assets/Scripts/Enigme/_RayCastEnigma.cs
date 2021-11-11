using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RayCastEnigma : MonoBehaviour
{
    
    public bool isOnSpot = false;
    public float counter = 0.0f;
    private bool isRunning = false;
    [HideInInspector]
    public DOOR doorToOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Transform cameraTransform = Camera.main.transform;
        RaycastHit HitInfo;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 1000.0f))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 1000.0f, Color.yellow);
            if (HitInfo.transform.gameObject.tag == "Enigma" && isOnSpot)
            {

                HitInfo.transform.gameObject.TryGetComponent<_Enigme>(out _Enigme component);
               
                if (!isRunning)
                {
                    isRunning = true;
                    StartCoroutine(StartCountdown(10));
                }

            }

        }
        if (!isOnSpot)
        {
            StopAllCoroutines();
            isRunning = false;
        }
    }
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        counter = countdownValue;
        while (counter > 0)
        {
            Debug.Log(counter);
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        if(counter == 0)
        {
            Debug.Log("énigme trouvée, all good !");
            doorToOpen.OpenDoor();
        }
    }
}
