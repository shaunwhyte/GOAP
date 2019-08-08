
using System;
using UnityEngine;

public class EatGrassAction : GoapAction
{
    private Grass targetGrass; // what food we eat;
  
    public EatGrassAction()
    {
        addPrecondition("grassAvailable", true);
        addPrecondition("drankEnoughToEat", true);
        addEffect("hasMilk", true);
    }


    public override void reset()
    {
        finishedAction = false;
        targetGrass = null;
    }

    public override bool isDone()
    {
        return finishedAction;
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
        Grass[] availableGrass = (Grass[])UnityEngine.GameObject.FindObjectsOfType(typeof(Grass));
        Grass closest = null;
        float closestDist = 0;

        foreach (Grass supply in availableGrass)
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

        targetGrass = closest;
        target = targetGrass.gameObject;

        return closest != null;
    }

    public override bool perform(GameObject agent)
    {
        CowStomach cowStomach = (CowStomach)agent.GetComponent(typeof(CowStomach));
        cowStomach.grassEaten += 10;
        Destroy(target.gameObject);
        finishedAction = true;
        return true;
    }

}

