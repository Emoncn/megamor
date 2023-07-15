using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using static UnityEditor.PlayerSettings;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] sphereList;
    const int GRAPH_DEGREE = 5;
    const bool isDebug = true;

    // Start is called before the first frame update
    void Start()
    {
        int jointedAmnt;

        // Copy of sphereList to order it without breaking stuff
        Transform[] sphereListCopy = (Transform[]) sphereList.Clone();

         // For each sphere, joint it to closest non-DEGREE-jointed until it has 2 joints
        foreach(Transform sphereTransform in sphereList)
        {
            jointedAmnt = sphereTransform.GetComponents<SpringJoint>().Length;

            if (jointedAmnt < GRAPH_DEGREE)
            {

                sphereListCopy = sphereListCopy.OrderBy(x => Vector3.Distance(x.position, sphereTransform.position)).ToArray();

                for (int i=1; i<sphereListCopy.Length; i++) // Skip first item (it's the current sphere)
                {
                    if (sphereListCopy[i].GetComponents<SpringJoint>().Length < GRAPH_DEGREE)
                    {
                        // Found the closest non-double-jointed sphere!
                        SpringJoint joint = sphereTransform.AddComponent<SpringJoint>();
                        joint.connectedBody = sphereListCopy[i].GetComponent<Rigidbody>();

                        jointedAmnt++;

                        if (jointedAmnt >= GRAPH_DEGREE) { break; }
                    }
                }
            }

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDebug)
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
