using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class json_parse : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {
        int i = 0;
        string temp = "000";

        string curFile = "C:/Projects/uoftHacks2017/JustaCam/ARDEEP/Assets/output2/frame000" + temp + ".json";
        while (System.IO.File.Exists(curFile))
        {
            print(i + " is the FRAME");

            var json = System.IO.File.ReadAllText("C:/Projects/uoftHacks2017/JustaCam/ARDEEP/Assets/output2/frame000" + temp + ".json");
            i++;

            var objects = JObject.Parse(json);
            var dict = objects.ToObject<Dictionary<string, object>>();
            var value = dict["bodies"];
            var join1_value = (IList)value;
            var joint1_value = join1_value[0];
            var join2_value = (IList)value;
            float[] joint1 = new float[19];
            float[] joint2 = new float[19];
            try
            {
                var joint2_value = join2_value[1];
                var joint1_string = joint1_value.ToString();
                var joint2_string = joint2_value.ToString();
                string joint1_substring = joint1_string.Substring(16, joint1_string.Length - 20);
                string joint2_substring = joint2_string.Substring(16, joint2_string.Length - 20);

                string joint1_substring_trimmed = joint1_substring.Trim().Replace(" ", "");
                string joint2_substring_trimmed = joint2_substring.Trim().Replace(" ", "");

                print(joint2_substring_trimmed);

                joint1 = System.Array.ConvertAll(joint1_substring_trimmed.Split(','), float.Parse);
                joint2 = System.Array.ConvertAll(joint2_substring_trimmed.Split(','), float.Parse);
            }
            catch (System.Exception e)
            {

            }

            if (i.ToString().Length == 1)
            {
                temp = "00" + i;
            }
            else if (i.ToString().Length == 2)
            {
                temp = "0" + i;
            }
            else
            {
                temp = i.ToString();
            }


            if(Overlay.body == null)
            {
                CreateBody(joint1);
                   
            }
            else
            {
                updateBody(joint1, i);
            }
            print("here");

            curFile = "C:/Projects/uoftHacks2017/JustaCam/ARDEEP/Assets/output2/frame000" + temp + ".json";
            print(curFile);
        }

    }


    void CreateBody(float[] parts)
    {
        GameObject bodyObj =  (GameObject)(Instantiate(Resources.Load("Body"), new Vector3(0, 0, 0), Quaternion.identity));
        Body body = bodyObj.GetComponent<Body>();
        for (int i =0; i < parts.Length/3; i++)
        {
            body.addBodyPart(parts[i], parts[i + 1], parts[i + 2]);
            print("created PART AASDASDASD Num " + i);
        }
        print("body made");
       
        Overlay.body = body;

    }

    void updateBody(float[] parts, int frame)
    {
        print("updated body part");
        int part = 0;
        for (int i = 0; i < parts.Length / 3; i+=3)
        {
            Overlay.body.updateBodyPart(parts[i], parts[i + 1], parts[i + 2],part,frame);
            part++;
        }

    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

