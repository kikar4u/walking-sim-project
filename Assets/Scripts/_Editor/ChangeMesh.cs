using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class ChangeMesh : MonoBehaviour
{
    public Color32 color = new Color32(255, 255, 255, 255);
    private Mesh mesh;
    public Mesh org = null;
    private MeshFilter mf;
    private MeshCollider mc;
    private bool isenabled = false;
    void OnEnable()
    {
        if (org != null)
        {
            load();
        }
    }
    void load()
    {
        mf = transform.GetComponent<MeshFilter>();
        mc = transform.GetComponent<MeshCollider>();
        mesh = Mesh.Instantiate(org) as Mesh;
        mf.sharedMesh = mesh;
        mc.sharedMesh = mesh;
        updatecolor();
        isenabled = true;
    }

    void OnValidate()
    {
        updatecolor();
    }

    void updatecolor()
    {
        if (isenabled)
        {
            Color32[] newColors = new Color32[mesh.vertices.Length];
            for (int i = 0; i < newColors.Length; i++)
            {
                newColors[i] = color;
            }
            mesh.colors32 = newColors;
        }
        else if (mesh == null)
        {
            load();
        }
    }

    void OnDisable()
    {
        if (isenabled)
        {
            mf.sharedMesh = org;
            mf.name = org.name;
        }
    }
}