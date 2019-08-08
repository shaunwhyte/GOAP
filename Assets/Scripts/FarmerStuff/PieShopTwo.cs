using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieShopTwo : MonoBehaviour
{
    public bool open = true;
    public Text textFeild;
    public void closeOpen()
    {
        open = !open;
    }

    void Update()
    {
        PieShopTwo[] blocks = (PieShopTwo[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopTwo));
        PieShopTwo info = blocks[0];
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
