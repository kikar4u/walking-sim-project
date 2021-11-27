using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class _RayCastEnigma : MonoBehaviour
{
    [SerializeField]
    public bool isOnSpot = false;
    public float counter = 0.0f;
    private bool isRunning = false;
    public _Enigme enigmeTrigger;
    public VisualEffect feedBackParticle;
    public AnimationCurve curve;
    private VisualEffect Vfx;
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
                    curve.keys[1].time = 5.0f;
                    StartCoroutine(StartCountdown(enigmeTrigger, 5));
                    Vfx = GameObject.Instantiate(feedBackParticle);
                    Vfx.transform.position = HitInfo.point;
                    Vfx.transform.rotation = HitInfo.transform.rotation * new Quaternion(-90,0,0,0);
                    //Vfx.SetVector3("Position", HitInfo.transform.position);
                    Vfx.SendEvent("OnPlay");
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
            
            //Debug.Log(counter);
            yield return new WaitForSeconds(1.0f);
            counter--;
            Vfx.SetFloat("Radius", counter);
            Debug.Log(Vfx.GetFloat("Radius") + "Radius");
            Vfx.SetFloat("Y", countdownValue);
            Vfx.SetAnimationCurve("Curve", curve);
        }
        if(counter == 0)
        {
            
            Debug.Log("énigme trouvée, all good !");
            enigma.isActivated = true;
            doorToOpen.OpenDoor();
            Vfx.SendEvent("OnStop");
            
            
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
