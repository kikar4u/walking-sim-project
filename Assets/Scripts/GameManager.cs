using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<_Enigme> enigmeList;
    public static bool isPaused = false;
    public static bool isLooking = false;
    public static Transform currentLookingObject;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        isLooking = false;
        enigmeList = new List<_Enigme>();
        GameObject[] arrG = GameObject.FindGameObjectsWithTag("enigmeTri");
        foreach (GameObject item in arrG)
        {
            enigmeList.Add(item.GetComponent<_Enigme>());   
        }
        enigmeList = enigmeList.OrderBy(w => w.id).ToList();

    }
    private void Update()
    {
        //Debug.Log("is looking : "+ isLooking);
        if (isLooking)
        {
           // Cursor.lockState = CursorLockMode.Confined;
        }
    }
    // faire une fonction pour vérifier que l'énigme précédente à bien été faites ici, fonction qu'on appellera 
    // dans le reste enigme.cs
    // Update is called once per frame
    // no longer used
    public bool CheckEnigma(_Enigme enigma)
    {
        _Enigme a = enigmeList.Find((x) => x == enigma);
        
        if (a.id == 0)
        {
            return true;
        }
        if (enigmeList[a.id - 1])
        {
            return true;
        }
        else
        {
            return false;
        }
        // vérifier le n-1 du tableau pour avoir si la porte précédente à été bien trigger
    }
   
}
