using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOneTextUpdater : MonoBehaviour {

    public Text textFeild;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PieShopOne[] blocks = (PieShopOne[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopOne));
        PieShopOne info = blocks[0];
        if (info.open)
        {
            textFeild.text = "Open";
        }
        else { 
            textFeild.text = "Closed";

        }
       
     

    }

}
