using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
public class _Picture : MonoBehaviour
{
    public Transform firstPosition;
    public float sensitivity = 2;
    public float speed = 1f;
    private Vector3 start;
    private Vector3 des;
    private float fraction = 0;
    private bool isActive = false;
    private Coroutine a;
    private Transform pPosition;
    Volume volume;
    DepthOfField dofComponent;
    float varDOFBefore = 1.0f;
    float varApertureBefore = 16f;
    // Start is called before the first frame update
    void Start()
    {
        volume = GameObject.Find("PostProcess").GetComponent<Volume>();
        DepthOfField tmp;
        if (volume.profile.TryGet<DepthOfField>(out tmp))
        {
            dofComponent = tmp;
            varDOFBefore = dofComponent.focusDistance.value;
            varApertureBefore = Camera.main.GetComponent<HDAdditionalCameraData>().physicalParameters.aperture;
        }
    }
    public void rotateObject(Vector3 playerPosition, int reverse = 0)
    {
        isActive = false;
        if (!isActive)
        {
            if (reverse == 0)
            {
                GameManager.isLooking = true;
                a = StartCoroutine(goToObject(playerPosition));
                GameManager.currentLookingObject = gameObject.transform;
                isActive = true;
            }
            if (reverse == 1)
            {
                GameManager.isLooking = false;
                a = StartCoroutine(goToObject(playerPosition, 1));
                //GameManager.currentLookingObject = gameObject.transform;
                isActive = true;
            }
        }
        else
        {
            isActive = false;
            StopCoroutine(a);
        }
    }
    private void Update()
    {
        DepthOfField tmp;
        if (volume.profile.TryGet<DepthOfField>(out tmp))
        {

            dofComponent = tmp;
            Debug.Log(dofComponent.focusDistance);
        }
    }
    public IEnumerator backToPos(Vector3 playerPosition, float timer = 2.0f)
    {
        float time = 0.0f;
        fraction = 1;
        var starte = gameObject.transform.position;
        des = start;
        Debug.Log("bStart: " + start + " bdesti : " + des);
        while (time < timer)
        {
            fraction += Time.deltaTime * speed;
            var t = fraction * fraction * (3f - 2f * fraction);
            transform.position = Vector3.MoveTowards(start, des, fraction);
            time += Time.deltaTime;
            yield return null;
        }
        isActive = false;
    }
    public IEnumerator goToObject(Vector3 playerPosition, int reverse = 0, float timer = 2.0f)
    {
        if(reverse == 0)
        {
            float time = 0.0f;
            fraction = 0;
            start = gameObject.transform.position;
            des = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            changeCamera(0);
            while (time < timer)
            {
                fraction += Time.deltaTime * speed;
                var t = fraction * fraction * (3f - 2f * fraction);
                //transform.position = Vector3.Lerp(start, des, fraction);
                transform.position = Vector3.Lerp(start, des, fraction);
                time += Time.deltaTime;
                yield return null;
            }


            isActive = false;

        }
        else
        {
            float time = 0.0f;
            fraction = 1;
            var starte = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            des = start;
            changeCamera(1);
            while (time < timer)
            {
                fraction += Time.deltaTime * speed;
                //var t = fraction * fraction * (3f - 2f * fraction); to lerp ease & out

                transform.position = Vector3.Lerp(start, des, fraction);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, fraction);
                time += Time.deltaTime;
                yield return null;
            }

            isActive = false;
        }
        

        //yield return null; //maybenot



    }
    public void changeCamera(int reverse)
    {

        if (reverse == 0)
        {
            DepthOfField tmp;
            if (volume.profile.TryGet<DepthOfField>(out tmp))
            {

                dofComponent = tmp;
                dofComponent.focusDistance.SetValue(new MinFloatParameter(0.6f, 0f, true));
                Camera.main.GetComponent<HDAdditionalCameraData>().physicalParameters.aperture = 0.2f;
            }
        }
        else
        {
            DepthOfField tmp;
            if (volume.profile.TryGet<DepthOfField>(out tmp))
            {

                dofComponent = tmp;
                dofComponent.focusDistance.SetValue(new MinFloatParameter(varDOFBefore, 0f, true));
                Camera.main.GetComponent<HDAdditionalCameraData>().physicalParameters.aperture = varApertureBefore;
            }
        }

    }
}
