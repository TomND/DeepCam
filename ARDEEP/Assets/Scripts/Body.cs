using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    BodyPart[] parts = new BodyPart[19];
    public int partIndex;

	// Use this for initialization
	void Start () {
		
	}


    void addBodyPart(float x, float y, float c)
    {
        parts[partIndex] = new BodyPart(x, y, c);   
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
