using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFreeMoney : MonoBehaviour {

	public void giveFarmerMoney()
    {
        FarmersBag[] blocks = (FarmersBag[])UnityEngine.GameObject.FindObjectsOfType(typeof(FarmersBag));
        FarmersBag bag = blocks[0];
        bag.money += 5;
    }
}
