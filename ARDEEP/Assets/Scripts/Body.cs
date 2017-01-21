using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    BodyPart[] parts = new BodyPart[17];
    GameObject[] joints = new GameObject[17];
    int partIndex = 0;
    public int frame = 0;
    public  bool created = false;
    public  GameObject joint;

    public Body()
    {
        print("i've been made");
        created = true;
    }

	// Use this for initialization
	void Start () {
		
	}


    public void addBodyPart(float x, float y, float c)
    {
        
        joints[partIndex] = (GameObject)Instantiate(Resources.Load("Point"), new Vector3(x, y, -25), Quaternion.identity);
        parts[partIndex] = joints[partIndex].GetComponent<BodyPart>();
       // print("make body parts $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ at index " + partIndex + "position"+x+"  "+y);
        partIndex++;
    }

    public void updateBodyPart(float x, float y, float c, int index, int frame)
    {
        
        //print("frame is hello" + frame + "index is heoo" + index);
        
        parts[index].fx[frame] = x;
        parts[index].fy[frame] = -y;
    }


    // updates body
    public void updateBody()
    {
        print(parts[16] + "the second ");
        //print(parts[1] + "the last part");
        
        print(frame + "is the frame");
       /* foreach (BodyPart p in parts)
        {
            if(p != null)
            {
                print("ASDAROIHQEGFIOUWRHGLOIWUQRGHLBNWHGLBNWR   " + p.fx[0]);
                p.x = p.fx[frame];
                p.y = p.fy[frame];

            }

        }*/

        for(int i = 0; i < parts.Length; i++)
        {
           // print("ASDAROIHQEGFIOUWRHGLOIWUQRGHLBNWHGLBNWR   " + parts[i].fx[0] + " the part " + i);
            parts[i].x = parts[i].fx[frame];
            parts[i].y = parts[i].fy[frame];
        }
        
        frame ++;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
