using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Menu()
    {
        
        SceneManager.LoadScene(0);
    }
    public void StartNewGame()
    {
        Debug.Log("StartNewGame");
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();

    }
}
