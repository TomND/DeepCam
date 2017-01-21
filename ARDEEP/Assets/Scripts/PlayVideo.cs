using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

    public bool play;

    public static int fps;

    private static MovieTexture mTexture;

    void Awake()
    {
        fps = 30;
        Application.targetFrameRate = fps;
        GetComponent<Renderer>().sortingLayerName = "Default";
        print("here");
    }

    // Use this for initialization


	// Use this for initialization
	void Start () {
        mTexture = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (play)
        {
            mTexture.Play();
            print(mTexture.duration);
        }
	}

    public static int getFrames()
    {
        return fps * (int)(mTexture.duration);

    }

}
