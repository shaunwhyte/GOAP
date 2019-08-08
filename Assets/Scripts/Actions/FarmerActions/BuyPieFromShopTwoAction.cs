using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPieFromShopTwoAction : GoapAction {

    private bool bought = false;
    private PieShopTwo targetChoppingBlock; // what food we eat;

    private float startTime = 0;
    public float workDuration = 2; // seconds

    public BuyPieFromShopTwoAction()
    {
        addPrecondition("hasEnoughMoney", true); //must have available funds for pie.

        addPrecondition("pieShopTwoOpen", true); //must have available funds for pie.
                                                 //  addPrecondition("eaten", false); // Cant have more than one pie.
                                                 // addPrecondition("hasPie", false); // Cant already have pie, can only hold one.
        addEffect("hasPie", true); //Now has pie, can go eat it at the table.
    }


    public override void reset()
    {
        bought = false;
        targetChoppingBlock = null;
        startTime = 0;
    }

    public override bool isDone()
    {
        return bought;
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
        PieShopTwo[] blocks = (PieShopTwo[])UnityEngine.GameObject.FindObjectsOfType(typeof(PieShopTwo));


        targetChoppingBlock = blocks[0];
        target = targetChoppingBlock.gameObject;


        return blocks[0] != null;
    }

    public override bool perform(GameObject agent)
    {
        if (targetChoppingBlock.open == false)
        {
            return false;
        }

        FarmersBag bag = (FarmersBag)agent.GetComponent(typeof(FarmersBag));

        bag.money -= 5;
        bag.hasPie = true;
        bought = true;
        return true;
    }
}
