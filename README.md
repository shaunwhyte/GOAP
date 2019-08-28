## GOAP Goal Orientated Action Planning

Link to demonstration
https://www.youtube.com/watch?v=Os2ckoNvScM

Goal Oriented Action planning is a smarter method for creating Artificial Intelligent agents within a game. Originally, simple logic could be used to program an AI system within a game. For instance, “if player in range Throw bomb”. Simplistic patterns could also be implemented in a game such as ‘block block hit block block hit’. For many games where the logic is relatively simple and repetitive, this works well. If the person playing the game does not notice advanced AI behaviour, there's no point in trying to implement. In fact on simple games, the overhead of a more advanced system may not even be worth having. Another option before using GOAP was by using complex finite state machines. The issue with these finite state machines is how the complexity rapidly grows as new states are added. The finite state machines will get quite messy once you want some smarter behaviour. This makes creating more advanced systems more difficult.

By using a goal oriented action planning system the advanced AI systems can be created. The decoupled arrangement of the states in a GOAP system fixes this issue of complex FSMs. Using GOAP means that adding new actions to an agent is quite simple. States can be dynamically added to the system so new paths to a goal can be established during runtime. 
In my demonstration this is evident with the so called “Close Shop Button”. A pie shop can be closed, resulting in the Farmer moving to the next path to the goal, which will be going to the other shop. GOAP allows for AI agents to be able to change the way they behave, based off the state that the world is currently in. 

#Written Walkthrough

In this simulation, the farmer has a goal of eating. One way he can satisfy this goal is if we give him a free pie via the “Give Free Pie” button.
Another way the farmer can satisfy his goal is by purchasing a pie from one of the pie shops.
He needs 5 dollars to do this. To get money, we can again give it to him, or he can go milk the cow and sell the milk.
He can only milk the cow when the cow has milk. For the cow to have milk, the cow take a drink from the trough then eat some grass. 
When the cow drinks, the trough level goes down, starting at three going down to zero, so the cow can drink three times, before the trough needs to be refilled. Each time the cow eats grass, the grass patch disappears. So from the beginning, the cow can make milk 3 times. 
After that, the farmer will notice that the cow does not have the resources that enable it to make milk, so the Farmer will replenish the resources. The farmer can plant one grass patch at a time but fills the trough up completely(form 0 to 3).
This shows the adaptive behaviour of the Farmer. Depending on the environment, his path to his goal changes. He only fills the trough up to a third of the times he plants grass.
I've added a button so that the user can add grass by themselves, to show how the farmer doesn't always plant grass. 
The buttons give “Free Pie” and “Give 5 Dollars” shows how the farmer will not simply go to the cow every time, he will take the shortest path that is available from the state of the world around him, showing that there are several different paths for the Farmer to reach his goal.

The other way the user can affect the scenario is by clicking the buttons which close and open the pie shops. When a pie shop gets closed that means that the farmer can no longer go to that shop. He will then try to take the shortest path to the goal, which will be to walk to the other shop.
Real GOAP planning systems can search for new best cost paths as its executing its current path, and switch over if it finds a better path. My demonstration is too simple for this, and will execute a path unless an action fails, like when a shop is closed. It will then determine the next path to take. If we close both of the pie shops, then the farmer may stop(as long as there's no free pies and he has no money), this is because there will be no possible way to reach the goal.

#Understanding how the base code works.

Simply put, the agents who are going to be performing actions must have a GOAPAgent class attached to the gameobject as well as a class implementing the “IGOAP” interface. This interface defines some key behaviours for the agent. One thing it defines is what the goal for agent is.
For the Farmer, the goal is to “eat”, shown below.
goal.Add(new KeyValuePair<string, object>("eat", true));

So now that we have this goal in place, we must make some actions to satisfy this goal. When I first started making my simulation, I made this goal really easy to achieve, by just having one action that will satisfy the goal.
The “EatPieAction” gives an example of how preonditions and effects are added to an action.
         addPrecondition("hasPie", true); //must have a pie in bag
         addEffect("eat", true); //Goal state of eating has occurred.
This goal simply says that the Farmer must have a pie before this action can be run, and the effect will be that eat is true , our goal.
The “hasPie” attribute is implemented in the class extending the IGOAP interface, in my case the GeneralFarmer class. “hasPie” simply gets the boolean variable from the FarmersBag class.
The method “getWorldState” defines “hasPie” is a hashmap and its current value along with other variables that are determined by the current state of the world. This allows the agent to be able to change its next actions, based off the world state.
The GOAP agent gets its actions from classes extending GOAPAction, which are attached to the unity object. It can only use these actions to get to the goal.

We can now chain together multiple actions to get more complex decision making which is based off of what actions are available, and what paths will give the smallest cost.


The GOAPPlanner class is what generates the paths for the agents. Plans are built up by firstly taking all the possible actions that can be taken. Then by using these actions we have to see if a path can be found to the goal. We have to check that the parent node of the search has the correct preconditions before the action can be taken, otherwise the move cannot be taken. If the action can be used, then we take that action, and check if we have reached the goal, if we have reached the goal, we keep this path for latter, otherwise we test the other actions, by branching out the tree. In this implementation, all possible paths to the goals are found, then once we have the paths, we find out which path contains the cheapest cost across the individual nodes to reach the goal.

The FEAR AI system referenced below uses a three state FSM to orchestrate the system. Similarly, the GOAP system I used also uses three states, idleState , moveToState and performActionState. These are used to facilitate the GOAP algorithm with actions that are quite commonly used. For instance, many actions must be performed at a certain place in the game world. Action have a logic that supports making the player have to move to a location, otherwise there will be many actions that are just providing the agent a means to move to different places. If the player has to move to a position, a moveToState will pushed to the queue, if the agent is already in the correct position, then the performActionState can be used and execute the action thats ready. When plans fail for whatever reason, we go into the idleState, and find a plan to reach the goal again. 

To conclude, the GOAP demonstration shows some key features of a GOAP AI system. Mainly finding the best cost path to a goal, where the game world is altered, meaning that the paths to the goal also get alterated. My simple example shows how the agent can handle quite a range of different world states and adjusts accordingly . If I were to have more time, I would be interested in researching how to implement a multiple goal system, where goals have a priority that gets adjusted based on the state of the world. More advanced paths would then be generated, where the desired goal is changing, and if it can't be complemented at a given time, then another goal may run. 


#Sources
https://alumni.media.mit.edu/~jorkin/gdc2006_orkin_jeff_fear.pdf
https://gamedevelopment.tutsplus.com/tutorials/goal-oriented-action-planning-for-a-smarter-ai--cms-20793
https://medium.com/@vedantchaudhari/goal-oriented-action-planning-34035ed40d0b

The article by developer Brent Owens (https://gamedevelopment.tutsplus.com/tutorials/goal-oriented-action-planning-for-a-smarter-ai--cms-20793) provided some base code, that I was able to understand, and build my project off.
I implemented classes that extend his base classes.

