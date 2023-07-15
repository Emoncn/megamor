using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasGary : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-25f, 25f), transform.position.y, Random.Range(-25f, 25f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Blob")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            transform.localScale = Vector3.one * 1;
        }
    }
}
