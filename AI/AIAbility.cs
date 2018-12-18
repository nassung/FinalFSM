using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAbility : MonoBehaviour
{
    public  float health = 200.0f;
    public  float attack = 20.0f;
    public  float skill_1 = 40.0f;
    public  float skill_2 = 100.0f;

    PlayerCntrl pc;
    bool isDead = false;

    void Update()
    {
            if (health <= 0.0f && isDead == false)
            {
                isDead = true;
                pc.anim.SetTrigger("Dead");
        }
    }

    float AttackSkill1(MonsterAbility ma)
    {
        return ma.health -= 40.0f;
    }

    float AttackSkill2(MonsterAbility ma)
    {
        return ma.health -= 100.0f;
    }

}