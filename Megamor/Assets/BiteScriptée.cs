using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteScriptée : MonoBehaviour
{

    public float
        x = 0,
        y = 0,
        z = 0,
        jumpState = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = this.GetComponent<Transform>();
        //this.x = this.x + 0.01f;
        //transform.position = new Vector3(this.x, this.y, this.z);

        float
            moveX = 0,
            moveY = this.y,
            moveZ = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveZ = 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveZ = -0.1f;
        }
        transform.position = new Vector3(this.x += moveX, moveY, this.z += moveZ);

    }
}
