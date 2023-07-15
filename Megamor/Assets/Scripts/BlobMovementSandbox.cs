using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovementSandbox : MonoBehaviour
{
    public Transform blob_t;
    public Transform cam;

    private float load_jump = 0;
    public float jump_loading_max = 10;
    public float jump_height = 2;

    public float rotation_speed = 10;
    public float forward_speed = 10;
    public float max_boost_speed = 3;
    private float boost = 3;

    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float jump_interpolation = Mathf.Pow(load_jump / jump_loading_max, 2f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = max_boost_speed;
            particleSystem.Play();
        }
        else
        {
            boost = 1;
            particleSystem.Pause();
            particleSystem.Clear();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // charge le jump
            load_jump += Time.deltaTime;
            if (load_jump > jump_loading_max ) load_jump = jump_loading_max;

            blob_t.localScale = new Vector3(
                1 + 0.5f * jump_interpolation, 
                1 - 0.5f * jump_interpolation, 
                1 + 0.5f * jump_interpolation);
            blob_t.GetComponent<SphereCollider>().radius = 0.5f - 0.3f * jump_interpolation;

        }
        else if( load_jump > 0)
        {
            // jump si chargé
            Rigidbody rb = blob_t.GetComponent<Rigidbody>();
            rb.AddForce (Vector3.up * jump_height * load_jump / jump_loading_max);
            blob_t.localScale = new Vector3(1, 1, 1);
            blob_t.GetComponent<SphereCollider>().radius = 0.5f;

            load_jump = 0;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            blob_t.Rotate(new Vector3(0, boost * - rotation_speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            blob_t.Rotate(new Vector3(0, boost * rotation_speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            blob_t.position += boost * blob_t.forward * (1f - 0.75f * jump_interpolation) * forward_speed * Time.deltaTime;
        }


        // Camera
        cam.position = blob_t.position;
        cam.rotation = blob_t.rotation;
        cam.position -= blob_t.forward * 6f - blob_t.up;
        
        cam.LookAt(blob_t.position);
    }
}
