using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARItem : MonoBehaviour {

    public bool track;
    public BodyPart[] anchors = new BodyPart[4];
    public float[] anchorsx = new float[4]; //left, right, up, down
    public float[] anchorsy = new float[4];//bad
    private float dimensionX;

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
    public bool flipX;

	// Use this for initialization
	void Start () {

        if (flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);

        }
    }


    public void setOffSet()
    {
        if (anchorsx.Length == 1)
        {
            offsetX = anchors[0].x;
            offsetY = anchors[0].y;
        }
        else
        {
            float xAvg = Mathf.Abs(anchors[0].x - anchors[1].x)/1;
            float yAvg = Mathf.Abs(anchors[2].y - anchors[3].y)/1;
            /*for(int i = 0; i < anchorsx.Length; i++)
            {
                xAvg += anchorsx[i];
                yAvg += anchorsy[i];
            }*/
            offsetX = Mathf.Lerp(offsetX,xAvg,0.95f);
            offsetY = Mathf.Lerp(offsetY, yAvg, 0.95f);
            //print(offsetX + "is the offset  and "+ anchors[0].x);
        }

    }


    void setHeight()
    {
        float boundY = GetComponent<SpriteRenderer>().bounds.size.x *2;
        float target= Mathf.Abs(anchors[2].x - anchors[3].x);
        
        float scale = target / boundY;
        height = scale*150;//boundY * scale;
        //height = target / 2;

    }

    void setWidth() //TODO: remove absolute value, can have negative scale, should show back.
    {
        
        float boundX = GetComponent<SpriteRenderer>().bounds.size.y *2 ;
        //print(boundX + "is the bound x");
        float target = Mathf.Abs(anchors[0].y - anchors[1].y);
        //print(target);
        float scale = target / boundX;
        width = scale*150;//boundX * scale;
        //width = target / 2;
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
        if (anchor.x >= 10 && anchor.y <= -10 && anchor.x <= 1900 && anchor.y >= -1050 && offsetX <= 150 && offsetY <= 150 )
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(anchor.x+12*offsetX,anchor.y-offsetY,-2f),0.2f); // follow

        //scale
        setOffSet();
        setHeight();
        setWidth();
        if(width != 0 && height != 0)
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(width*2, height*2, 1),0.2f) ;
    }
}
