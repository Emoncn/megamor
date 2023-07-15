using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using static UnityEditor.PlayerSettings;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] sphereList;
    public int graphDegree = 8;
    const bool IS_DEBUG = true;
    const int JOINT_UPDATE_FRAMES = 60;
    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        int jointedAmnt;

        sphereList = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();

        // Safety measure
        graphDegree = Math.Min(graphDegree, sphereList.Length-1);

        // Copy of sphereList to order it without breaking stuff
        Transform[] sphereListCopy = (Transform[]) sphereList.Clone();

         // For each sphere, joint it to closest non-DEGREE-jointed until it has DEGREE joints
        foreach(Transform sphereTransform in sphereList)
        {
            jointedAmnt = sphereTransform.GetComponents<SpringJoint>().Length;

            if (jointedAmnt < graphDegree)
            {

                sphereListCopy = sphereListCopy.OrderBy(x => Vector3.Distance(x.position, sphereTransform.position)).ToArray();

                for (int i=1; i<sphereListCopy.Length; i++) // Skip first item (it's the current sphere)
                {
                    if (sphereListCopy[i].GetComponents<SpringJoint>().Length < graphDegree)
                    {
                        // Found the closest non-double-jointed sphere!
                        SpringJoint joint = sphereTransform.AddComponent<SpringJoint>();
                        joint.connectedBody = sphereListCopy[i].GetComponent<Rigidbody>();
                        joint.damper = 0.01f;
                        joint.spring = 14;
                        //joint.maxDistance = 1;
                        // joint.minDistance = .5f;

                        jointedAmnt++;

                        if (jointedAmnt >= graphDegree) { break; }
                    }
                }
            }
        }
    }
    
    void UpdateJoints()
    {
        Transform[] sphereListCopy = (Transform[])sphereList.Clone();

        foreach (Transform sphereTransform in sphereList)
        {
            sphereListCopy = sphereListCopy.OrderBy(x => Vector3.Distance(x.position, sphereTransform.position)).ToArray();

            // Go through joints and point to closest ones
            int i = 1;
            foreach (SpringJoint joint in sphereTransform.GetComponents<SpringJoint>())
            {
                joint.connectedBody = sphereListCopy[i].GetComponent<Rigidbody>();
                i++;
            }
        }
    }

    void UpdateCentroid()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        var numPoints = sphereList.Length;
        foreach (Transform trans in sphereList)
        {
            centroid += trans.position;
        }

        centroid /= numPoints;

        GameObject.Find("BlobCentroid").transform.position = centroid;
    }

    // Update is called once per frame
    void Update()
    {
        if (frames % JOINT_UPDATE_FRAMES == 0)
        {
            // UpdateJoints();
        }

        UpdateCentroid();

        if (IS_DEBUG)
        {
            foreach (Transform sphereTransform in sphereList)
            {
                foreach (SpringJoint joint in sphereTransform.GetComponents<SpringJoint>())
                {
                    Debug.DrawLine(sphereTransform.position, joint.connectedBody.position, Color.green);
                }
            }
        }
    }
}
