
using System;
using UnityEngine;

public class PlantGrassAction : GoapAction
{
    private bool done = false;
    private ACow targetChoppingBlock; // what food we eat;

    public Sprite grass;
    private float startTime = 0;
    public float workDuration = 2; // seconds
    public bool milked = false;

    public PlantGrassAction()
    {
        addEffect("grassAvailable", true);
    }


    public override void reset()
    {
        done = false;
        milked = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return done;
    }

    public override bool requiresInRange()
    {
        return true; // yes we need to be near food
    }


    /**
     *  Some actions need to use data from the world state to determine if they are able to run. These preconditions are called procedural preconditions.
     *  Need to check there is food available
     * **/
    public override bool checkProceduralPrecondition(GameObject agent)
    {

        GameObject newGrass = new GameObject();

        System.Random rnd = new System.Random();
        int x = rnd.Next(-10, 2);  // creates a number between 1 and 12
        int y = rnd.Next(-7, -2);   // creates a number between 1 and 6

        newGrass.transform.position = new Vector3((float)(x) , (float)(y), 0f);

        target = newGrass;

        return true;
    }

    public override bool perform(GameObject agent)
    {

        GameObject newGrass = new GameObject();
        SpriteRenderer renderer = newGrass.AddComponent<SpriteRenderer>();
        newGrass.AddComponent<Grass>();



        newGrass.GetComponent<SpriteRenderer>().sprite = grass;
        newGrass.transform.localScale = new Vector3(0.07606174F, 0.07606174f, 1);
        newGrass.transform.position = target.transform.position;
       // Instantiate(newGrass);
        done = true;
        return true;
    }

}

