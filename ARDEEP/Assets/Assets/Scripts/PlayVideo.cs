using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

    public static bool play;

    public static int fps;

    private static MovieTexture mTexture;

    GstUnityBridgeTexture t;


    void Awake()
    {
        fps = 30;
        Application.targetFrameRate = fps;
        QualitySettings.vSyncCount = 1;
        GetComponent<Renderer>().sortingLayerName = "Default";
        print("here");
        
    }

    // Use this for initialization


	// Use this for initialization
	void Start () {
        t = GetComponent<GstUnityBridgeTexture>();
        mTexture = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (play)
        {
            t.enabled = true;
            //print(mTexture.duration);
        }
	}

    public static int getFrames()
    {
        return fps * (int)(mTexture.duration);

    }

}
