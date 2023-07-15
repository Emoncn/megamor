using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleConstantRender : MonoBehaviour
{
    // Game objects
    public GameObject cylinder;
    public GameObject sphere;

    public float scale;
    public float height;
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale *= scale;        

        GameObject cyl_l = Instantiate(cylinder,this.transform);
        cyl_l.transform.localPosition = new Vector3(0,height/2,0);
        cyl_l.transform.localScale = new Vector3(.25f,height/2,.25f);

        GameObject cyl_r = Instantiate(cylinder,this.transform);
        cyl_r.transform.localPosition = new Vector3(width,height/2,0);
        cyl_r.transform.localScale = new Vector3(.25f,height/2,.25f);

        GameObject cyl_d = Instantiate(cylinder,this.transform);
        cyl_d.transform.localPosition = new Vector3(width/2,0,0);
        cyl_d.transform.eulerAngles = new Vector3(0,0,90);
        cyl_d.transform.localScale = new Vector3(.25f,width/2,.25f);

        GameObject cyl_u = Instantiate(cylinder,this.transform);
        cyl_u.transform.localPosition = new Vector3(width/2,height,0f);
        cyl_u.transform.eulerAngles = new Vector3(0,0,90);
        cyl_u.transform.localScale = new Vector3(.25f,width/2,.25f);
        
        
        GameObject sphere_dl = Instantiate(sphere,this.transform);
        sphere_dl.transform.localPosition = new Vector3(0f,0f,0f);
        sphere_dl.transform.localScale *= .25f;
        
        GameObject sphere_dr = Instantiate(sphere,this.transform);
        sphere_dr.transform.localPosition = new Vector3(0f,height,0f);
        sphere_dr.transform.localScale *= .25f;
        
        GameObject sphere_ul = Instantiate(sphere,this.transform);
        sphere_ul.transform.localPosition = new Vector3(width,0f,0f); 
        sphere_ul.transform.localScale *= .25f;      

        GameObject sphere_ur = Instantiate(sphere,this.transform);
        sphere_ur.transform.localPosition = new Vector3(width,height,0f);
        sphere_ur.transform.localScale *= .25f;
        

        for(int i = 1; i < width; i++)
        {

            GameObject prout = Instantiate(cylinder,this.transform);
            prout.transform.localPosition = new Vector3(i,height/2,0f);
            prout.transform.localScale = new Vector3(.1f,height/2,.1f);

        }
    
        for(int j = 1; j < height; j++)
        {
            GameObject prout2 = Instantiate(cylinder,this.transform);
            prout2.transform.localPosition = new Vector3(width/2,j,0f);
            prout2.transform.eulerAngles = new Vector3(0,0,90);
            prout2.transform.localScale = new Vector3(.1f,width/2,.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
