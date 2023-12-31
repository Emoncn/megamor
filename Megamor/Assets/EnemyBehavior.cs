using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start()
    {
        
    }


    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);

		Vector3 Targetposition = new Vector3 (target.position.x, transform.position.y, target.position.z);

        this.transform.position = Vector3.MoveTowards(transform.position, Targetposition, speed);
    }
}
