using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] verts;
    public  List<GameObject> joints;
    private float[] distances;
    public GameObject jointPrefab;
    private Transform center;
    void Start()
    {
        center = transform.Find("Center");
        mesh = GetComponent<MeshFilter>().mesh;
        verts = mesh.vertices;


        for (int i = 0; i < verts.Length; i++)
        {
            GameObject j = Instantiate(jointPrefab, verts[i], Quaternion.identity);
            j.transform.SetParent(this.transform);
            
            if (i != 0)
            {
                j.GetComponent<FixedJoint2D>().connectedBody = joints[i - 1].GetComponent<Rigidbody2D>();
            }
            joints.Add(j); 
        }
        joints[0].GetComponent<FixedJoint2D>().connectedBody = joints[joints.Count -1].GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < verts.Length; i++)
        {
            verts[i] = joints[i].transform.localPosition;
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
    }
}
