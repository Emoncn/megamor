using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomBehavior : MonoBehaviour
{
    private Vector3[] positions;

    private float timeElapsed = 0;

    void Start()
    {
        positions = new Vector3[5];
        positions[0] = new Vector3(125, 10, 125);
        positions[1] = new Vector3(125, 10, 375);
        positions[2] = new Vector3(375, 10, 125);
        positions[3] = new Vector3(250, 10, 250);
        positions[4] = new Vector3(375, 10, 375);
    }


    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= .5)
        {
            timeElapsed = 0;
            this.transform.position = positions[Random.Range(0,4)];
        }
    }
}
