
using System;
using UnityEngine;

public class GetFreePie : GoapAction
{
    private bool bought = false;
    private FreePie targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds

    public GetFreePie()
    {
        addPrecondition("freePieAvailable", true); //must have available funds for pie.
        addEffect("hasPie", true); //Now has pie, can go eat it at the table.
    }


    public override void reset()
    {
        bought = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return bought;
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
        FreePie[] blocks = (FreePie[])UnityEngine.GameObject.FindObjectsOfType(typeof(FreePie));
        if(blocks.Length == 0)
        {
            return false;
        }

        targetChoppingBlock = blocks[0];
        target = targetChoppingBlock.gameObject;


        return blocks[0] != null;
    }

    public override bool perform(GameObject agent)
    {
     
        FarmersBag bag = (FarmersBag)agent.GetComponent(typeof(FarmersBag));
        bag.hasPie = true;
        Destroy(target);
        bought = true;
        return true;
    }

}

