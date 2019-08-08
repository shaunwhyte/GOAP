using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


/*
 * 
 * holds water level for the trough
 * */

public class WaterTrough : MonoBehaviour {


    public int level = 2;
    public Text textFeild;
    public bool takeDrink()
    {
        if(level > 0)
        {
            level--;
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {

            textFeild.text = "Water Level:" + level;
     
    }
}

