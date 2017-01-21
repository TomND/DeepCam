using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

    public double offset;
    public double time;// since play

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    public double getFrame()
    {

        return time * PlayVideo.fps;
    }
}
