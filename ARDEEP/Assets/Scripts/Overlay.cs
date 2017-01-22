using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour {

    public double offset;
    public double time;// since play
    private int offCount = 0;
    public static Body body;
    //public GameObject[] clothes = new GameObject[3];// shirt,hat,pants
    public GameObject shirtObj;
    public bool shirt;
    public bool hat;
    public bool pants;
    private bool initializedClothes = false;

	// Use this for initialization
	void Start () {

    }


    void initializeClothes()
    {
        if (shirt)
        {
            print("MEOOOW");
            shirtObj = (GameObject)Instantiate(Resources.Load("jersey-front"), new Vector3(0, 0, -2), Quaternion.identity);
            shirtObj.GetComponent<ARItem>().anchor = body.parts[5];
            print(shirtObj.GetComponent<ARItem>().anchorsx[0]);
            shirtObj.GetComponent<ARItem>().anchors = new BodyPart[] { body.parts[2], body.parts[5], body.parts[1], body.parts[11] };
            shirtObj.GetComponent<ARItem>().anchorsx[0] = body.parts[2].x;
            shirtObj.GetComponent<ARItem>().anchorsx[1] = body.parts[5].x;
            shirtObj.GetComponent<ARItem>().anchorsx[2] = body.parts[1].x;
            shirtObj.GetComponent<ARItem>().anchorsx[3] = body.parts[11].x;

            shirtObj.GetComponent<ARItem>().anchorsy[0] = body.parts[2].x;
            shirtObj.GetComponent<ARItem>().anchorsy[1] = body.parts[5].x;
            shirtObj.GetComponent<ARItem>().anchorsy[2] = body.parts[1].x;
            shirtObj.GetComponent<ARItem>().anchorsy[3] = body.parts[11].x;
            
            

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
            if (initializedClothes == false)
            {
                initializedClothes = true;
                initializeClothes();
                
            }
                if (offCount > offset)
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
                shirtObj.GetComponent<ARItem>().track = true;
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
