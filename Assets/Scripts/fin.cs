using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fin : MonoBehaviour
{
    public GameObject one;
    public int timer = 0;

    public void Start()
    {
        Time.timeScale = 1.0f;
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
        if (timer == 8)
        {
            SceneManager.LoadScene(0);
        }
    }
}
