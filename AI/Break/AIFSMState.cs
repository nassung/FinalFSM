using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIFSMManager))]
public class AIFSMState : MonoBehaviour
{
    protected AIFSMManager manager_t;
    
    private void Awake()
    {
        manager_t = GetComponent<AIFSMManager>();
    }

    public virtual void BeginState()
    {
    }

    public virtual void EndState()
    {

    }

    protected virtual void Update()
    {
        if (GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            manager_t.SetState(AIState.Idle);
        }
    }
}
