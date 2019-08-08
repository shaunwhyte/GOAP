
using System;
using UnityEngine;

public class CheckFullAction : GoapAction
{

    public CheckFullAction()
    {
        addPrecondition("isAlive", true); //must be alive to eat
        addPrecondition("isFull", true); // if rats eating enough, rat doesnt need more.
        addEffect("eatFood", true); //Effect will be that hunger level decreases.
    }

    bool done =false;

    public override void reset()
    {
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

    /*
     * Should always succed as its just a check.
     * */
    public override bool perform(GameObject agent)
    {
        done = true;
        return true;
    }

}

