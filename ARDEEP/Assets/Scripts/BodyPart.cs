using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

    public float x = 0;
    public float y = 0;
    public float[] fx = new float[500];
    public float[] fy = new float[500];
    public double certainty;
    public int id;
    public string part;
    public GameObject point;
    public GameObject pointPrefab;

    public BodyPart(float x, float y, float c)
    {
        //this.x = x;
        //this.y = y;
        //this.certainty = c;
        
    }

	// Use this for initialization
	void Start () {
        //this.x = x;
        //this.y = y;
        //this.certainty = c;
    }
	
	// Update is called once per frame
	void Update () {

        if(x != 0 && y != 0)
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, -25), 0.5f);
        
        
	}

    public void setPoint()
    {
        point.transform.position = new Vector3(x, y, 0);
    }

}
