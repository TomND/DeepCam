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

        string curFile = "C:/Users/spratiman/UofTHacks4/JustaCam/ARDEEP/Assets/output/output2/frame000" + temp + ".json";
        while (System.IO.File.Exists(curFile))
        {


            var json = System.IO.File.ReadAllText("C:/Users/spratiman/UofTHacks4/JustaCam/ARDEEP/Assets/output/output2/frame000" + temp + ".json");
            i++;

            var objects = JObject.Parse(json);
            var dict = objects.ToObject<Dictionary<string, object>>();
            var value = dict["bodies"];
            var join1_value = (IList)value;
            var joint1_value = join1_value[0];
            var join2_value = (IList)value;
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

                float[] joint1 = System.Array.ConvertAll(joint1_substring_trimmed.Split(','), float.Parse);
                float[] joint2 = System.Array.ConvertAll(joint2_substring_trimmed.Split(','), float.Parse);
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
            curFile = "C:/Users/spratiman/UofTHacks4/JustaCam/ARDEEP/Assets/output/output2/frame000" + temp + ".json";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

