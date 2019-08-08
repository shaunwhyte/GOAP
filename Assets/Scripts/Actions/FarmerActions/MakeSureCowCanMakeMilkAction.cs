
using System;
using UnityEngine;

public class MakeSureCowCanMakeMilkAction : GoapAction
{
    private bool done = false;
    private ACow targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds
    public bool milked = false;

    public MakeSureCowCanMakeMilkAction()
    {
        addPrecondition("grassAvailable", true);
        addEffect("cowCanEat", true);
        
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
        done = true;
        return true;
    }

}

