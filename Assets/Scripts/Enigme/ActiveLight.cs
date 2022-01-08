using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLight : MonoBehaviour
{
    private Light lightIntensity;
    public GameObject pointLight;
    public AnimationCurve curveAnim;
    private float curveDeltaTime = 0.0f;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        if (pointLight != null)
        {
            lightIntensity = pointLight.GetComponent<Light>();

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
        Debug.Log("Intensity" + lightIntensity.intensity);
    }
    private void turnOffLights()
    {
        // Get the current position of the sphere
        //StartCoroutine(AnimateLights(1.0f));
        float currentLumen = lightIntensity.intensity;
        currentLumen -= 1 * Time.deltaTime;   // Call evaluate on that time   
        curveDeltaTime -= Time.deltaTime;
        currentLumen = curveAnim.Evaluate(curveDeltaTime);      // Update the current position of the sphere
        lightIntensity.intensity = currentLumen;
        Debug.Log("Intensity" + lightIntensity.intensity);
    }
    public IEnumerator AnimateLights(float speed)
    {

        yield return new WaitForSeconds(1.0f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Interact") && !isActive)
            {
                Debug.Log("Helloworld");
                TurnOnLights();
                isActive = true;
            }
            else if(Input.GetButtonDown("Interact") && isActive)
            {
                turnOffLights();
                isActive = false;
            }
        }
    }
}
