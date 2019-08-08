
using System;
using UnityEngine;

public class MilkCowAction : GoapAction
{
    private bool eaten = false;
    private ACow targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds
    public bool milked = false;

    public MilkCowAction()
    {
        addPrecondition("grassAvailable", true);
        addPrecondition("waterAvailable", true);
        addPrecondition("cowHasMilk", true);
        addPrecondition("hasMilk", false); //must have been to buy a pie.
                                        //  addEffect("hasEnoughMoney", true);
        addEffect("hasMilk", true);
    }


    public override void reset()
    {
        eaten = false;
        milked = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return milked;
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
        ACow[] blocks = (ACow[])UnityEngine.GameObject.FindObjectsOfType(typeof(ACow));


        targetChoppingBlock = blocks[0];
        target = targetChoppingBlock.gameObject;


        return blocks[0] != null;
    }

    public override bool perform(GameObject agent)
    {

        FarmersBag bag = (FarmersBag)agent.GetComponent(typeof(FarmersBag));
        bag.eaten = false;
        milked = true;

        ACow[] theCows = (ACow[])UnityEngine.GameObject.FindObjectsOfType(typeof(ACow));
        ACow aCow = theCows[0];
        aCow.stomach.takeMilk();

        return true;
    }

}

