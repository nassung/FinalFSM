using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdle : AIFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        manager_t.SetAnim(0);
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();

        Vector3 mobDistance = manager_t.target[0].transform.position;
        Vector3 bossDistance = manager_t.target[1].transform.position;

        mobDistance.y = bossDistance.y = 0.0f;

        Vector3 aIPos = transform.position;

        if (Vector3.Distance(mobDistance, aIPos) > 50.0f)
        {
            manager_t.SetState(AIState.Battle);
            return;
        }

        if (Vector3.Distance(bossDistance, aIPos) > 50.0f)
        {
            manager_t.SetState(AIState.Battle);
            return;
        }
    }
}