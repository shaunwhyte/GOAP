
using System;
using UnityEngine;

public class MakeMilkAction : GoapAction
{
    private bool done = false;
    private ACow targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds
    public bool milked = false;

    public MakeMilkAction()
    {
        addPrecondition("hasMilk", true);
        addEffect("makeMilk", true);
    }


    public override void reset()
    {
      
        targetChoppingBlock = null;
        startTime = 0;
        done = false;
    }

    public override bool isDone()
    {
        return done;
    }

    public override bool requiresInRange()
    {
        return false; // yes we need to be near food
    }


    /**
     *  Some actions need to use data from the world state to determine if they are able to run. These preconditions are called procedural preconditions.
     *  Need to check there is food available
     * **/
    public override bool checkProceduralPrecondition(GameObject agent)
    {
        return true;
    }

    public override bool perform(GameObject agent)
    {

        CowStomach bag = (CowStomach)agent.GetComponent(typeof(CowStomach));

        if (bag.hasMilk())
        {
            done = true;
            return true;
        }
        done = true;
        return false;
       
    }

}

