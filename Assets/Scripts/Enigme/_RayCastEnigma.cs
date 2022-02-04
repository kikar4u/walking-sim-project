using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DigitalRuby.SoundManagerNamespace;

public class _RayCastEnigma : MonoBehaviour
{
    [SerializeField]
    public bool isOnSpot = false;
    public float timeToEnigma = 5.0f;
    private float counter = 0.0f;
    private bool isRunning = false;
    public _Enigme enigmeTrigger;
    public GameObject feedbackEffect;
    public VisualEffect feedBackParticle;
    public AnimationCurve curve;
    private VisualEffect Vfx;
    private GameObject Vfx2;
    private ParticleSystem pSystem;
    [HideInInspector]
    public int currentID;
    public DOOR doorToOpen;
    [HideInInspector]
    public GameManager GM;
    public SoundFXManager SoundM;
    GameObject touchedObject;
    // Start is called before the first frame update
    void Start()
    {
       GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
       SoundM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundFXManager>();

    }
    private void Update()
    {


    }
    private void FixedUpdate()
    {
        Transform cameraTransform = Camera.main.transform;
        RaycastHit hitInfo;
        //Physics.SphereCast(cameraTransform.position, cameraTransform.position.x / 2, transform.forward, out HitInfo, 10);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, 1000.0f))
        {

            if(hitInfo.transform.gameObject.tag == "picture" && !GameManager.isLooking)
            {
                touchedObject = hitInfo.transform.GetChild(0).gameObject;
                touchedObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.white * 0.1f);
            }
            else if(touchedObject != null)
            {
                Debug.Log("HEY OH");
                touchedObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", Color.white * 0);
                touchedObject = null;

            }
            //Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 1000.0f, Color.yellow);
            if (hitInfo.transform.CompareTag("Enigma") && isOnSpot)
            {

                hitInfo.transform.gameObject.TryGetComponent<_Enigme>(out _Enigme component);
               
                if (!isRunning)
                {
                    isRunning = true;
                    curve.keys[1].time = timeToEnigma;
                    pSystem = feedbackEffect.transform.GetChild(1).GetComponent<ParticleSystem>();
                    var main = pSystem.main;
                    main.duration = timeToEnigma;
                    
                    StartCoroutine(StartCountdown(enigmeTrigger, timeToEnigma));
                    Vfx2 = GameObject.Instantiate(feedbackEffect);
                    Vfx2.transform.position = hitInfo.point;
                    Vfx2.transform.rotation = hitInfo.transform.rotation;
                    
                    //Vfx = GameObject.Instantiate(feedBackParticle);
                    //Vfx.transform.position = HitInfo.point;
                    //Vfx.transform.rotation = HitInfo.transform.rotation * new Quaternion(-90,0,0,0);
                    // No use Vfx.SetVector3("Position", HitInfo.transform.position);
                    //Vfx.SendEvent("OnPlay");
                    Debug.Log("je suis dans la box");
                }

            }

        }

        if (!isOnSpot)
        {
            StopAllCoroutines();
            Destroy(Vfx2);
            //Destroy(Vfx);
            isRunning = false;
        }
    }

    public IEnumerator StartCountdown(_Enigme enigma, float countdownValue = 10 )
    {
        counter = countdownValue;

        while (counter > 0)
        {

            //Debug.Log(counter);
            var main = pSystem.shape;
            main.radius = 2.5f;
            

            yield return new WaitForSeconds(1.0f);
            counter--;
            //Vfx.SetFloat("Radius", counter);
            //Debug.Log(Vfx.GetFloat("Radius") + "Radius");
            //Vfx.SetFloat("Y", countdownValue);
            //Vfx.SetAnimationCurve("Curve", curve);
        }
        if(counter == 0)
        {
            
            Debug.Log("énigme trouvée, all good !");
            enigma.isActivated = true;
            GameObject[] a = GameObject.FindGameObjectsWithTag("door");
            
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i].gameObject.GetComponent<DOOR>().id == currentID)
                {
                    SoundM.PlaySound(0);
                    a[i].gameObject.GetComponent<DOOR>().OpenDoor();
                    


                }
            }
            //doorToOpen.OpenDoor();
            //Vfx.SendEvent("OnStop");
            //Destroy(Vfx);
            
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
