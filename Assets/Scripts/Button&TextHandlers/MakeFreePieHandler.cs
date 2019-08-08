using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFreePieHandler : MonoBehaviour
{


    public Sprite pie;

    public void placePie()
    {

        GameObject newPie = new GameObject();

        System.Random rnd = new System.Random();
        int x = rnd.Next(8, 12);  // creates a number between 1 and 12
        int y = rnd.Next(1, 5);   // creates a number between 1 and 6

        newPie.transform.position = new Vector3((float)(x), (float)(y), 0f);

        SpriteRenderer renderer = newPie.AddComponent<SpriteRenderer>();
        newPie.AddComponent<FreePie>();
        newPie.GetComponent<SpriteRenderer>().sprite = pie;
        newPie.transform.localScale = new Vector3(0.4374993f, 0.414993f, 1);

    }

}
