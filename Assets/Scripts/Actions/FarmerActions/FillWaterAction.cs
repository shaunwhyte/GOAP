
using System;
using UnityEngine;

public class FillWaterAction : GoapAction
{
    private bool eaten = false;
    private WaterTrough targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds

    public FillWaterAction()
    {
        addEffect("waterAvailable", true);
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
        // find the nearest supply pile that has spare logs
        WaterTrough[] supplyPiles = (WaterTrough[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterTrough));
        WaterTrough closest = supplyPiles[0];
       
        targetChoppingBlock = closest;
        target = targetChoppingBlock.gameObject;

        return closest != null;
    }

    public override bool perform(GameObject agent)
    {

        WaterTrough[] waters = (WaterTrough[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterTrough));
        WaterTrough water = waters[0];
        water.level = 3;
        eaten = true;
        return true;
    }

}

