
using System;
using UnityEngine;

public class EatPieAction : GoapAction
{
    private bool eaten = false;
    private Table targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds

    public EatPieAction()
    {
         addPrecondition("hasPie", true); //must have pie in bag
         addEffect("eat", true); //Goal state of eating has occured.
    }


    public override void reset()
    {
        eaten = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return eaten;
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

        // find the nearest chopping block that we can chop our wood at
        Table[] blocks = (Table[])UnityEngine.GameObject.FindObjectsOfType(typeof(Table));


        targetChoppingBlock = blocks[0];
        target = targetChoppingBlock.gameObject;


        return blocks[0] != null;
    }

    public override bool perform(GameObject agent)
    {

        FarmersBag bag = (FarmersBag)agent.GetComponent(typeof(FarmersBag));
        bag.eaten = false;
        bag.hasPie = false;
        eaten = true;
        return true;
    }

}

