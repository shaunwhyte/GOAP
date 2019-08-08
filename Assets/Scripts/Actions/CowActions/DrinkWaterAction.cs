
using System;
using UnityEngine;

public class DrinkWaterAction : GoapAction
{
    private WaterTrough targetWaterTrough;

    public DrinkWaterAction()
    {
        addEffect("drankEnoughToEat", true);
    }


    public override void reset()
    {
        finishedAction = false;
        targetWaterTrough = null;
    }

    public override bool isDone()
    {
        return finishedAction;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
      
        WaterTrough[] supplyPiles = (WaterTrough[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterTrough));
        WaterTrough closest = null;
        float closestDist = 0;

        foreach (WaterTrough supply in supplyPiles)
        {

            if (closest == null)
            {
                // first one, so choose it for now
                closest = supply;
                closestDist = (supply.gameObject.transform.position - agent.transform.position).magnitude;
            }
            else
            {
                // is this one closer than the last?
                float dist = (supply.gameObject.transform.position - agent.transform.position).magnitude;
                if (dist < closestDist)
                {
                    // we found a closer one, use it
                    closest = supply;
                    closestDist = dist;
                }
            }
        }

        if (closest == null)
            return false;

        targetWaterTrough = closest;
        target = targetWaterTrough.gameObject;

        return closest != null;
    }

    public override bool perform(GameObject agent)
    {

        CowStomach stomach = (CowStomach)agent.GetComponent(typeof(CowStomach));
        stomach.waterDrunk += 10;

        WaterTrough[] waters = (WaterTrough[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterTrough));
        WaterTrough water = waters[0];


        bool drank = water.takeDrink();
        if (drank == false)
        {
            finishedAction = true;
            return false;
        }
        finishedAction = true;
        return true;
    }

}

