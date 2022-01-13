using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFeedBackEnigma : MonoBehaviour
{
    public int id;
    public AnimationCurve curveAnim;
    public GameObject leLight;
    private Light lightIntensity;
    private float curveDeltaTime = 0.0f;
    public bool isEnigma = false;
    // Start is called before the first frame update
    private void Start()
    {
        if (leLight != null)
        {
            lightIntensity = leLight.GetComponent<Light>();
            
        }

    }
    
    private void Update()
    {
        if (isEnigma)
        {
            TurnOnLights();
        }
    }
    public void TurnOnLights()
    {
        // Get the current position of the sphere
        //StartCoroutine(AnimateLights(1.0f));
        float currentLumen = lightIntensity.intensity;
        currentLumen += 1 * Time.deltaTime;   // Call evaluate on that time   
        curveDeltaTime += Time.deltaTime;
        currentLumen = curveAnim.Evaluate(curveDeltaTime);      // Update the current position of the sphere
        lightIntensity.intensity = currentLumen;
        //Debug.Log("Intensity" + lightIntensity.intensity);
    }
    public IEnumerator AnimateLights(float speed)
    {

        yield return new WaitForSeconds(1.0f);
    }
}
