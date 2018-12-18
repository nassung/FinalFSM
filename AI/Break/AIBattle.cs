using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBattle : AIFSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void KickAttack()
    {
        Vector3 mobDistance = manager_t.target[0].transform.position;
        Vector3 bossDistance = manager_t.target[1].transform.position;

        mobDistance.y = bossDistance.y = 0.0f;

        if (Vector3.Distance(mobDistance, this.transform.position) <= 5.0f)
        {
            // 몬스터 피 삭감
        }

        if (Vector3.Distance(bossDistance, this.transform.position) <= 5.0f)
        {
            // 보스 피 삭감
        }
    }
}
