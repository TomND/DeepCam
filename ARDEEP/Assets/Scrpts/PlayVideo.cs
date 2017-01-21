using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour {

    public bool play;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (play)
        {
            ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();

        }
	}
}
