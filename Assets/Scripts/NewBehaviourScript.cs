using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public int timer = 0;

    public void Start()
    {
        Time.timeScale = 1.0f;
        two.SetActive(false);
        StartCoroutine(time());
    }
    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }
    void timeCount()
    {

        timer++;
        Debug.Log(timer);
    }
    private void Update()
    {
        if(timer == 7)
        {
            one.SetActive(false);
            two.SetActive(true);
        }
        if(timer == 14)
        {
            SceneManager.LoadScene(2);
        }
    }

} 
