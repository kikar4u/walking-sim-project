using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<_Enigme> enigmeList;
    // Start is called before the first frame update
    void Start()
    {
        enigmeList = new List<_Enigme>();
        GameObject[] arrG = GameObject.FindGameObjectsWithTag("enigmeTri");
        foreach (GameObject item in arrG)
        {
            enigmeList.Add(item.GetComponent<_Enigme>());

            
        }
        enigmeList = enigmeList.OrderBy(w => w.id).ToList();

    }
    // faire une fonction pour v�rifier que l'�nigme pr�c�dente � bien �t� faites ici, fonction qu'on appellera 
    // dans le reste enigme.cs
    // Update is called once per frame
    void Update()
    {
        
    }
    // no longer used
    public bool CheckEnigma(_Enigme enigma)
    {
        _Enigme a = enigmeList.Find((x) => x == enigma);
        //Debug.Log(a);
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
        // v�rifier le n-1 du tableau pour avoir si la porte pr�c�dente � �t� bien trigger
    }
   
}
