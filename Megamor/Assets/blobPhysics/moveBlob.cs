using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static NewBehaviourScript;

public class moveBlob : MonoBehaviour
{
    public Vector3 centroidPoint;
    public Transform[] spheres;
    private Vector3 fromCentroid;

    // Start is called before the first frame update
    void Start()
    {
        spheres = transform.GetComponent<NewBehaviourScript>().sphereList;
        // sphereList = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        centroidPoint = GameObject.Find("BlobCentroid").transform.position;

        foreach (Transform t in spheres)
        {
            fromCentroid = centroidPoint - t.position;

            Vector3 momentum = new Vector3(4, 0, 0);

            momentum.x = Mathf.Max(0, momentum.x - fromCentroid.x*2);
            momentum.y = fromCentroid.x > 0 ? 5 : 0;

            // print("Sphere position: " + t.position);
            // print("From Centroid: " + fromCentroid);
            // print("Sphere momentum: " + momentum);

            t.GetComponent<Rigidbody>().AddRelativeForce(momentum);
        }
    }
}
