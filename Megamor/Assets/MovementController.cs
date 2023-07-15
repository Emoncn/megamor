using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float
        x = 0,
        y = 0,
        z = 0,
        speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float
            moveX = 0,
            moveY = this.y,
            moveZ = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 0.001f * this.speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -0.001f * this.speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveZ = 0.001f * this.speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveZ = -0.001f * this.speed;
        }

        this.GetComponent<Transform>().position = new Vector3(
            this.x += moveX,
            moveY,
            this.z += moveZ
        );
    }
}
