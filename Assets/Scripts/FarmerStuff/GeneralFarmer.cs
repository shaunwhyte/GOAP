using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**
 *A general Farmer class so in future there can be multiple farmers
 */
public abstract class GeneralFarmer : MonoBehaviour, IGoap
{
    public FarmersBag bag;
    public float moveSpeed = 1;


    void Start()
    {
        if (bag == null)
            bag = gameObject.AddComponent<FarmersBag>() as FarmersBag;

    }

    /**
	 * Key-Value data that will feed the GOAP actions and system while planning.
	 */
    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("hasEnoughMoney", (bag.money >= 5)));
        worldData.Add(new KeyValuePair<string, object>("eat", (bag.eaten)));
        worldData.Add(new KeyValuePair<string, object>("hasPie", (bag.hasPie)));
        worldData.Add(new KeyValuePair<string, object>("hasMilk", (bag.hasMilk)));
        worldData.Add(new KeyValuePair<string, object>("storeMilk", (bag.storedMilk)));

        PieShopOne[] p1 = (PieShopOne[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopOne));
        PieShopOne info1 = p1[0];

        
        worldData.Add(new KeyValuePair<string, object>("pieShopOneOpen", (info1.open)));


        PieShopTwo[] p2 = (PieShopTwo[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopTwo));
        PieShopTwo info2 = p2[0];
        worldData.Add(new KeyValuePair<string, object>("pieShopTwoOpen", (info2.open)));


        ACow[] cows = (ACow[])UnityEngine.GameObject.FindObjectsOfType(typeof(ACow));
        ACow theCow = cows[0];


        Grass[] grasses = (Grass[])UnityEngine.GameObject.FindObjectsOfType(typeof(Grass));

        worldData.Add(new KeyValuePair<string, object>("grassAvailable", (grasses.Length > 0)));


        WaterTrough[] waters = (WaterTrough[])UnityEngine.GameObject.FindObjectsOfType(typeof(WaterTrough));
        WaterTrough water = waters[0];


        worldData.Add(new KeyValuePair<string, object>("waterAvailable", (water.level > 0)));


        worldData.Add(new KeyValuePair<string, object>("cowHasMilk", (theCow.stomach.hasMilk())));


        FreePie[] freePies = (FreePie[])UnityEngine.GameObject.FindObjectsOfType(typeof(FreePie));

        worldData.Add(new KeyValuePair<string, object>("freePieAvailable", (freePies.Length > 0)));


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

