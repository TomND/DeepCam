using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {

    public float x;
    public float y;
    public double certainty;
    public int id;
    public string part;
    public GameObject point;
    public GameObject pointPrefab;

    public BodyPart(float x, float y, float c)
    {
        this.x = x;
        this.y = y;
        this.certainty = c;
    }

	// Use this for initialization
	void Start () {
		point = Instantiate(pointPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPoint()
    {
        point.transform.position = new Vector3(x, y, 0);
    }

}
