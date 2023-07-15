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
    private int frames = 0;
    public Transform[] sphereList;
    public int graphDegree = 5;
    const bool IS_DEBUG = false;
    const int JOINT_UPDATE_FRAMES = 10;

    void UpdateJoints()
    {
        int jointedAmnt;

        sphereList = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        // foreach(Transform sphere in sphereList) { print(sphere); }

        // Safety measure
        graphDegree = Math.Min(graphDegree, sphereList.Length - 1);

        // Copy of sphereList to order it without breaking stuff
        Transform[] sphereListCopy = (Transform[])sphereList.Clone();

        // For each sphere, joint it to closest non-DEGREE-jointed until it has 2 joints
        foreach (Transform sphereTransform in sphereList)
        {
            jointedAmnt = sphereTransform.GetComponents<SpringJoint>().Length;

            if (jointedAmnt < graphDegree)
            {

                sphereListCopy = sphereListCopy.OrderBy(x => Vector3.Distance(x.position, sphereTransform.position)).ToArray();

                for (int i = 1; i < sphereListCopy.Length; i++) // Skip first item (it's the current sphere)
                {
                    if (sphereListCopy[i].GetComponents<SpringJoint>().Length < graphDegree)
                    {
                        // Found the closest non-double-jointed sphere!
                        SpringJoint joint = sphereTransform.AddComponent<SpringJoint>();
                        joint.connectedBody = sphereListCopy[i].GetComponent<Rigidbody>();

                        jointedAmnt++;

                        if (jointedAmnt >= graphDegree) { break; }
                    }
                }
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateJoints();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % JOINT_UPDATE_FRAMES == 0)
        {
            UpdateJoints();
        }

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
