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
            if (IsAtPoint(comps[i]))
            {
                SetNewPoint(comps[i]);
            }
            else
            {
                comps[i].altered = Vector3.Lerp(comps[i].altered, comps[i].destination, Time.deltaTime * 60f);
            }
        }
    }

    private Vector3 RandRangeVals()
    {
        temp.x = Random.Range(minMove, maxMove);
        temp.y = Random.Range(minMove, maxMove);
        temp.z = Random.Range(minMove, maxMove);
        return temp;
    }

    private bool IsAtPoint(VComp v)
    {
        v.atPoint = v.altered == v.destination ? true : false;
        return v.atPoint;
    }

    private void SetNewPoint(VComp v)
    {
        v.atPoint = false;
        v.destination = v.origin * Random.Range(minMove, maxMove);
    }
}
