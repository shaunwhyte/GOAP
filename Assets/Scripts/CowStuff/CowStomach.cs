using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class contains state data for the cow
 * */

public class CowStomach : MonoBehaviour {

    public int grassEaten = 0;
    public int waterDrunk = 0;

    public bool hasMilk()
    {
        if(grassEaten >= 10 && waterDrunk >= 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
     * Used by farmer to take the milk from the cow
     */

    public bool takeMilk()
    {
        if (grassEaten >= 10 && waterDrunk >= 10)
        {

            grassEaten -= 10;
            waterDrunk -= 10;
            return true;
        }
        else
        {
            return false;
        }


    }

}
