using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

    public double offset;
    public double time;// since play
    private int offCount = 0;
    public static Body body;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (body != null)
        {
            if(offCount > offset)
            {
                body.updateBody();
            }
            else
            {
                offCount++;
            }
            //print("play BRAAAAAAAA");
            PlayVideo.play = true;
            

        }
	}




    public double getFrame()
    {

        return time * PlayVideo.fps;
    }
}
