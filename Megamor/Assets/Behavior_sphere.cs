using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior_sphere : MonoBehaviour
{
    public float speed;
    public Vector3 mLastPosition;
    public float elapsedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        mLastPosition = new Vector3(0,0,0);
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        speed = (transform.position - this.mLastPosition).magnitude / elapsedTime;
        this.mLastPosition = transform.position;
        gameObject.transform.position = new Vector3(transform.position.x,transform.position.y*elapsedTime,transform.position.z);
        
    }


}
