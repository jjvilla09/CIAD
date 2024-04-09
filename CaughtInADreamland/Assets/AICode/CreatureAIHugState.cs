using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAIHugState : CreatureAIState
{

    public CreatureAIHugState(CreatureAI creatureAI) : base(creatureAI){}
    List<Vector2> path;

    public override void BeginState()
    {
        // Initialize list
        if(path == null) {
            path = new List<Vector2>();
        }

        // Set color red
        creatureAI.SetColor(Color.red);
    }

    public override void UpdateState()
    {
        if(creatureAI.GetTarget() != null){
            creatureAI.myCreature.MoveCreatureToward(creatureAI.GetTarget().transform.position);
        }else{
            creatureAI.ChangeState(creatureAI.investigateState);
        }
    }


}
