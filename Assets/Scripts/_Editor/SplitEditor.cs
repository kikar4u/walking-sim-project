using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class SplitEditor : MonoBehaviour
{
    public int MaxWinDistance;
    public Vector3 targetPosition;
    public List<GameObject> splitObject;
    private GameObject targetObject;
    public List<Vector3> cellsPosition;
    public List<float> cellsScale;

    private void OnEnable()
    {   

        targetObject = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        splitObject.Clear();
        cellsPosition.Clear();
        cellsScale.Clear();
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            Debug.Log(gameObject.transform.childCount);
            splitObject.Add(gameObject.transform.GetChild(i).gameObject);
            cellsPosition.Add(gameObject.transform.GetChild(i).localPosition);
            cellsScale.Add(gameObject.transform.GetChild(i).lossyScale.x);
        }
        targetObject.transform.position = targetPosition;

    }
    private void OnValidate()
    {
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            Transform oldParent = transform.parent;
            transform.parent = null;
            splitObject[i].transform.localScale = new Vector3(cellsScale[i], cellsScale[i], cellsScale[i]);
            transform.parent = oldParent;
            splitObject[i].transform.localPosition = cellsPosition[i];
            
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}
