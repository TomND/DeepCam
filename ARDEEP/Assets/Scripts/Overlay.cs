using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

    public double offset;
    public double time;// since play
    private int offCount = 0;
    public static Body body;
    public GameObject[] clothes = new GameObject[3];// shirt,hat,pants
    bool shirt;
    bool hat;
    bool pants;

	// Use this for initialization
	void Start () {
        if (shirt)
        {
            clothes[0].GetComponent<ARItem>().anchor = body.parts[5];
            clothes[0].GetComponent<ARItem>().anchorsx[0] = body.parts[2].x;
            clothes[0].GetComponent<ARItem>().anchorsx[1] = body.parts[5].x;
            clothes[0].GetComponent<ARItem>().anchorsx[2] = body.parts[1].x;
            clothes[0].GetComponent<ARItem>().anchorsx[3] = body.parts[11].x;

            clothes[0].GetComponent<ARItem>().anchorsy[0] = body.parts[2].x;
            clothes[0].GetComponent<ARItem>().anchorsy[1] = body.parts[5].x;
            clothes[0].GetComponent<ARItem>().anchorsy[2] = body.parts[1].x;
            clothes[0].GetComponent<ARItem>().anchorsy[3] = body.parts[11].x;

        }
        if (pants)
        {

        }
        if (hat)
        {

        }
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

            if (shirt)
            {
                clothes[0].GetComponent<ARItem>().track = true;
            }
            if (pants)
            {

            }
            if (hat)
            {

            }

        }
	}




    public double getFrame()
    {

        return time * PlayVideo.fps;
    }
}
