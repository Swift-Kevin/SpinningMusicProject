using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class VertexManipulation : MonoBehaviour
{
    struct VComp
    {
        public Vector3 origin, normal, altered, destination;
        public bool atPoint;
    }

    [SerializeField] float minMove;
    [SerializeField] float maxMove;

    VComp[] comps;
    Vector3[] baseVerticies;
    private Mesh mesh;
    private Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        comps = new VComp[mesh.vertices.Length];

        for (int i = 0; i < mesh.vertexCount; i++)
        {
            comps[i].normal = mesh.normals[i];
            comps[i].origin = mesh.vertices[i];
            comps[i].altered = mesh.vertices[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < comps.Length; ++i)
        {
            SetNewPoint(comps[i]);
            comps[i].altered = Vector3.Lerp(comps[i].origin, comps[i].destination, 5f);
            // Debug.Log(comps[i].origin + comps[i].altered + comps[i].destination);
        }
    }


    private bool IsAtPoint(VComp v)
    {
        v.atPoint = v.altered == v.destination ? true : false;
        return v.atPoint;
    }

    private float tX, tY, tZ;

    private void SetNewPoint(VComp v)
    {
        if (v.altered == v.destination)
        {
            v.atPoint = false;
            tX = Random.Range(v.origin.x, v.origin.x + (v.origin.x * 5000f));
            tY = Random.Range(v.origin.y, v.origin.y + (v.origin.y * 5000f));
            tZ = Random.Range(v.origin.z, v.origin.z + (v.origin.z * 5000f));
            v.destination = new Vector3(tX, tY, tZ);
        }
    }
}
