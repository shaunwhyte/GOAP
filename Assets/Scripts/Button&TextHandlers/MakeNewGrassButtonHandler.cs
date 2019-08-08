using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNewGrassButtonHandler : MonoBehaviour {


    public Sprite grass;

    public void placeGrass() { 

        GameObject newGrass = new GameObject();

        System.Random rnd = new System.Random();
        int x = rnd.Next(-10, 2);  // creates a number between 1 and 12
        int y = rnd.Next(-7, -2);   // creates a number between 1 and 6

        newGrass.transform.position = new Vector3((float)(x), (float)(y), 0f);

        SpriteRenderer renderer = newGrass.AddComponent<SpriteRenderer>();
        newGrass.AddComponent<Grass>();
        newGrass.GetComponent<SpriteRenderer>().sprite = grass;
        newGrass.transform.localScale = new Vector3(0.07606174F, 0.07606174f, 1);
        
    }

}
