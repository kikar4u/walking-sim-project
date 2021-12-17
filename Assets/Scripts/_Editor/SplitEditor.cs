using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class SplitEditor : MonoBehaviour
{
    public int MaxWinDistance;

    public List<GameObject> splitObject;
    private GameObject targetObject;
    public List<Vector3> cellsPosition;
    public List<float> cellsScale;
    public GameObject empty;
    private void OnEnable()
    {   

        targetObject = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;
        splitObject.Clear();
        cellsPosition.Clear();
        cellsScale.Clear();
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            //Debug.Log(gameObject.transform.childCount);
            splitObject.Add(gameObject.transform.GetChild(i).gameObject);

            cellsPosition.Add(gameObject.transform.GetChild(i).localPosition);
            
            cellsScale.Add(gameObject.transform.GetChild(i).lossyScale.x);
            //
        }
        //targetObject = Instantiate(new GameObject("targetPosition"), gameObject.transform);
        

    }
    [ContextMenu("Randomize")]
    private void Randomizer()
    {
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            splitObject[i].transform.localPosition = new Vector3(Random.Range(0, 50), splitObject[i].transform.localPosition.y, splitObject[i].transform.localPosition.z);
        }
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
        //Vector3 relativePosition;
        /*        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
                {
                    splitObject[i].transform.LookAt(empty.transform, Vector3.up);
                }*/
        // returns the position of followGO relative to the steeringwheel
        // but in the local transform space of the steering wheel itself
        //relativePosition = transform.InverseTransformDirection(empty.transform.localPosition);
        // you want to eliminate the local difference in Y direction
        //relativePosition.y = 0;
        if(empty != null)
        {
            transform.LookAt(empty.transform, Vector3.up);
        }
        // since you are right and LookAt expects a world position after eliminating the local Y difference 
        // we convert it back to world space
        // var targetPosition = transform.TransformPoint(relativePosition);
        //transform.rotation = Quaternion.identity;

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90.0f, transform.eulerAngles.z);






    }
}
