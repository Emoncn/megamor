using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class centroidUpdate : MonoBehaviour
{
    public Transform[] sphereList;

    // Start is called before the first frame update
    void Start()
    {
        GameObject blob = GameObject.Find("Blob");
        sphereList = blob.GetComponentsInChildren<Transform>().Where(t => t != blob).ToArray();

        foreach (Transform t in sphereList)
        {
            print(t.name);
        }
    }

    Vector3 getCentroid()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        var numPoints = sphereList.Length;
        foreach (Transform trans in sphereList)
        {
            centroid += trans.position;
        }

        centroid /= numPoints;

        return centroid;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = getCentroid();
    }
}
