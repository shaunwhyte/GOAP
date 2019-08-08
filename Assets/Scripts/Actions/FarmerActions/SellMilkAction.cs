using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMilkAction : GoapAction
{

    private SuperMarketOne targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds
    public bool selledMilk = false;

    public SellMilkAction()
    {
        addPrecondition("hasMilk", true); //must have been to buy a pie.
        addEffect("hasEnoughMoney", true);
    }


    public override void reset()
    {
        selledMilk = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return selledMilk;
    }

    public override bool requiresInRange()
    {
        return true; ; // yes we need to be near food
    }


    /**
     *  Some actions need to use data from the world state to determine if they are able to run. These preconditions are called procedural preconditions.
     *  Need to check there is food available
     * **/
    public override bool checkProceduralPrecondition(GameObject agent)
    {

        // find the nearest chopping block that we can chop our wood at
        SuperMarketOne[] blocks = (SuperMarketOne[])UnityEngine.GameObject.FindObjectsOfType(typeof(SuperMarketOne));


        targetChoppingBlock = blocks[0];
        target = targetChoppingBlock.gameObject;


        return blocks[0] != null;


    }

    public override bool perform(GameObject agent)
    {

        selledMilk = true;
        FarmersBag bag = (FarmersBag)agent.GetComponent(typeof(FarmersBag));
        bag.money += 5;
        bag.hasMilk = false;
       
        return true;
    }


}
