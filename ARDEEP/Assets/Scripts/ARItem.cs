using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARItem : MonoBehaviour {

    public bool track;
    public float[] anchorsx; //left, right, up, down
    public float[] anchorsy;

    /*
     * 
     * 
     * Rshoulder - 2

        LShoulder - 5

        Rhip - 8

        LHip - 11
     * 
     * 
     * 
     */
    public BodyPart anchor; // in a perfect world, i'd choose based on certainty, but in a hackathon world, i choose left shoulder
    public float offsetX;
    public float offsetY;
    public float width;
    public float height;

	// Use this for initialization
	void Start () {
		if(anchorsx.Length == 1)
        {
            offsetX = anchorsx[0];
            offsetY = anchorsy[0];
        }
        else
        {
            float xAvg = 0;
            float yAvg =0 ;
            for(int i = 0; i < anchorsx.Length; i++)
            {
                xAvg += anchorsx[i];
                yAvg += anchorsy[i];
            }
            offsetX = xAvg / anchorsx.Length;
            offsetY = xAvg / anchorsy.Length;
        }
	}


    void setHeight()
    {
       height = Mathf.Abs(anchorsx[0] - anchorsx[1]);

    }

    void setWidth() //TODO: remove absolute value, can have negative scale, should show back.
    {
        width = Mathf.Abs(anchorsy[0] - anchorsy[1]);
    }
	
	// Update is called once per frame
	void Update () {
        if (track)
        {
            tracker();
        }
	}


    void tracker()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(anchor.x,anchor.y,-2f),0.9f); // follow

        //scale
        setHeight();
        setWidth();
        gameObject.transform.localScale = new Vector3(width,height,1);
    }
}
