using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieShopOne : MonoBehaviour {


    public bool open = true;
    public Text textFeild;

    /**
     * Open and close the pie shop
     */

    public void closeOpen()
    {
        open = !open;
    }

    void Update()
    {
        PieShopOne[] blocks = (PieShopOne[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopOne));
        PieShopOne info = blocks[0];
        if (info.open)
        {
            textFeild.text = "Open";
        }
        else
        {
            textFeild.text = "Closed";

        }

    }
}
