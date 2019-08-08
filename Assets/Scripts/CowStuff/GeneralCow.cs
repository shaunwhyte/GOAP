using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
    Base classs for future cows
 */
public abstract class GeneralCow : MonoBehaviour, IGoap
{
    public CowStomach stomach;
    public float moveSpeed = 1;


    void Start()
    {
        if (stomach == null)
            stomach = gameObject.AddComponent<CowStomach>() as CowStomach;

    }


    void Update()
    {

    }

    /**
	 * Key-Value data that will feed the GOAP actions and system while planning.
	 */
    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        bool grassAvaialve = false;
        Grass[] supplyPiles = (Grass[])UnityEngine.GameObject.FindObjectsOfType(typeof(Grass));
        if(supplyPiles.Length > 0)
        {
            grassAvaialve = true;
        }

        worldData.Add(new KeyValuePair<string, object>("grassAvailable", grassAvaialve));



        worldData.Add(new KeyValuePair<string, object>("hasMilk", (stomach.hasMilk())));
        worldData.Add(new KeyValuePair<string, object>("drankEnoughToEat", (stomach.waterDrunk >= 10)));
        return worldData;
    }

    /**
	 * Implement in subclasses
	 */
    public abstract HashSet<KeyValuePair<string, object>> createGoalState();


    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        // Not handling this here since we are making sure our goals will always succeed.
        // But normally you want to make sure the world state has changed before running
        // the same goal again, or else it will just fail.
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {
        // Yay we found a plan for our goal
        Debug.Log("<color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
    }

    public void actionsFinished()
    {
        // Everything is done, we completed our actions for this gool. Hooray!
        Debug.Log("<color=blue>Actions completed</color>");
    }

    public void planAborted(GoapAction aborter)
    {
        // An action bailed out of the plan. State has been reset to plan again.
        // Take note of what happened and make sure if you run the same goal again
        // that it can succeed.
        Debug.Log("<color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
    }

    public bool moveAgent(GoapAction nextAction)
    {
        // move towards the NextAction's target
        float step = moveSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextAction.target.transform.position, step);

        if (gameObject.transform.position.Equals(nextAction.target.transform.position))
        {
            // we are at the target location, we are done
            nextAction.setInRange(true);
            return true;
        }
        else
            return false;
    }
}

