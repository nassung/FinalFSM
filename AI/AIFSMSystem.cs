using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AICondition
{
    Idle = 0,
    Kick = 1,
    Dead = 2
};

public class AIFSMSystem : MonoBehaviour
{
    [SerializeField] public MonsterAbility[] target;
    [SerializeField] public AICondition aiCondition;
    [SerializeField] AIAbility ab;
    [SerializeField] AIAutoCtrl aac;


    [SerializeField] public float disTanceM, disTanceB;

    float aiTime;
    int state;

	// Use this for initialization
	void Start ()
    {
        aiCondition = AICondition.Idle;
	}
	
	// Update is called once per frame
	void Update ()
    {
        aiTime += Time.deltaTime;
        CheckDistance();
        
        if (aiCondition == AICondition.Kick)
        {

            SwitchState(aiCondition);

            if (Input.GetMouseButtonDown(0))
            {
                Skill1();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Skill2();
            }
        }
	}

    AICondition CheckDistance()
    {
        disTanceM = Vector3.Distance(target[0].transform.position, this.transform.position);
        disTanceB = Vector3.Distance(target[1].transform.position, this.transform.position);

        if (disTanceM <= 5.0f || disTanceB <= 5.0f)
            return aiCondition = AICondition.Kick;  //   AICondition.Kick;

        return aiCondition = AICondition.Idle;
    }

    void SwitchState(AICondition aic)
    {
        state = (int) aic;

        switch (state)
        {
            case 0 :    // Idle
                {

                    break;
                }
            case 1:     // Kick
                {
                    Attack();
                    break;
                }
            case 2:     // Dead
                {
                    break;
                }
        }
    }

    void Attack()
    {
        aac.anim.SetInteger("Anim", 2);

        float disTanceM = Vector3.Distance(target[0].transform.position, this.transform.position);
        float disTanceB = Vector3.Distance(target[1].transform.position, this.transform.position);

    }

    void KickAttack()
    {
        Debug.Log("KickAttack");

        if (disTanceM <= 5.0f)
            target[0].health -= 20.0f;
        else if (disTanceB <= 5.0f)
            target[0].health -= 20.0f;
    }

    void Skill1()
    {
        aac.anim.SetTrigger("Skill1");

        float disTanceM = Vector3.Distance(target[0].transform.position, this.transform.position);
        float disTanceB = Vector3.Distance(target[1].transform.position, this.transform.position);

        if (disTanceM <= 5.0f)
            target[0].health -= 40.0f;
        else if (disTanceB <= 5.0f)
            target[0].health -= 40.0f;
    }

    void Skill2()
    {
        aac.anim.SetTrigger("Skill2");

        float disTanceM = Vector3.Distance(target[0].transform.position, this.transform.position);
        float disTanceB = Vector3.Distance(target[1].transform.position, this.transform.position);

        if (disTanceM <= 5.0f)
        {
            target[0].health -= 100.0f;
            // 타켓 녹아웃
        }
        else if (disTanceB <= 5.0f)
        {
            target[0].health -= 100.0f;
            // 타켓 녹아웃
        }
    }
}
