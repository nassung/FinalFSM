using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Idle = 0,
    Walk,
    Battle,
    Buff,
    Dead
}

[RequireComponent(typeof(AIStatus))]
[ExecuteInEditMode]
public class AIFSMManager : MonoBehaviour, IFSMManager
{
    private bool isInit = false;

    public AIState startState = AIState.Idle;
    private Dictionary<AIState, AIFSMState> state_d = new Dictionary<AIState, AIFSMState>();

    [SerializeField] private AIState currentState_p;
    public AIState currentState { get { return currentState_p; } }

    public AIFSMState currentStateComponent
    { get { return state_d[currentState]; } }

    private AIStatus stat_p;
    public AIStatus stat { get { return stat_p; } }

    private Animator anim_p;
    public Animator anim { get { return anim_p; } }

    private Transform[] target_p;
    public Transform[] target { get { return target_p; } }

    private void Awake()
    {
        stat_p = GetComponent<AIStatus>();
        anim_p = GetComponent<Animator>();

        target[0] = gameObject.transform.Find("Monster");
        target[1] = gameObject.transform.Find("BossMonster");

        AIState[] stateValues = (AIState[])System.Enum.GetValues(typeof(AIState));
        foreach (AIState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("AI" + s.ToString());
            AIFSMState state = (AIFSMState)GetComponent(FSMType);

            if (null == state)
                state = (AIFSMState)gameObject.AddComponent(FSMType);

            state_d.Add(s, state);
            state.enabled = false;
        }
    }

	// Use this for initialization
	private void Start ()
    {
        SetState(startState);
        isInit = true;
	}

    public void SetState(AIState newState)
    {
        if (isInit)
        {
            state_d[currentState_p].enabled = false;
            state_d[currentState_p].EndState();
        }

        currentState_p = newState;
        state_d[currentState_p].BeginState();
        state_d[currentState_p].enabled = true;
        anim_p.SetInteger("Anim", (int)currentState_p);
    }

    public void SetAnim(int num)
    {
        anim_p.SetInteger("Anim", num);
    }

    public void NotifyTargetKilled()
    {
        SetState(AIState.Idle);
    }

    public void SetDeadState()
    {
        SetState(AIState.Dead);
    }

    private void Update()
    {
    }
}
