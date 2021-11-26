using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RayCastEnigma : MonoBehaviour
{
    [SerializeField]
    public bool isOnSpot = false;
    public float counter = 0.0f;
    private bool isRunning = false;
    public _Enigme enigmeTrigger;

    [HideInInspector]
    public DOOR doorToOpen;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
       GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Transform cameraTransform = Camera.main.transform;
        RaycastHit HitInfo;
        Physics.SphereCast(cameraTransform.position, cameraTransform.position.x / 2, transform.forward, out HitInfo, 10);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out HitInfo, 1000.0f))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 1000.0f, Color.yellow);
            if (HitInfo.transform.gameObject.tag == "Enigma" && isOnSpot)
            {

                HitInfo.transform.gameObject.TryGetComponent<_Enigme>(out _Enigme component);
               
                if (!isRunning)
                {
                    isRunning = true;
                    StartCoroutine(StartCountdown(enigmeTrigger, 5));
                    Debug.Log("je suis dans la box");
                }

            }

        }
        if (!isOnSpot)
        {
            StopAllCoroutines();
            isRunning = false;
        }
    }
    public IEnumerator StartCountdown(_Enigme enigma, float countdownValue = 10 )
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
            enigma.isActivated = true;
            doorToOpen.OpenDoor();

            
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enigmeTri")
        {
            enigmeTrigger = other.gameObject.GetComponent<_Enigme>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enigmeTri")
        {
            enigmeTrigger = null;
        }
    }
}
