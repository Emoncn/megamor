using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBlob : MonoBehaviour
{
    private GameObject _Sphere;
    const float BLOB_SCALE = 4f;

    void Start()
    {
        float gridX = BLOB_SCALE;
        float gridY = BLOB_SCALE;
        float spacing = .9f;
        int layers = 2;

        for (int i = 0; i < layers; i++)
        {
            for (int y = 1; y < gridY; y++)
            {
                for (int x = 1; x < gridX; x++)
                {
                    _Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Rigidbody rBody = _Sphere.AddComponent<Rigidbody>();

                    _Sphere.name = "Sphere" + x.ToString() + "_" + y.ToString();
                    _Sphere.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    _Sphere.transform.position = new Vector3(x, i*1.5f+1, y) * spacing;
                    _Sphere.transform.parent = gameObject.transform;
                }
            }
        }
    }
}
