using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * A simple cow, more advnce cows can implement General Cow aswell.
 * */

public class ACow : GeneralCow {

    /**
     * Defining a goal make milk
     * */
    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("makeMilk", true));
        return goal;
    }

}
