using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAbility : MonoBehaviour
{
    public float health = 300.0f;
    public float attack = 20.0f;

    [SerializeField] public AIFSMSystem aiSystem;
    Animator anim;
    bool isDead = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        aiSystem = GetComponent<AIFSMSystem>();
    }

    private void Update()
    {
        if (health <= 0.0f && isDead == false)
        {
            isDead = true;
            anim.SetTrigger("Dead");
        }
    }

    float AttackAI(AIAbility ab)
    {
        return ab.health -= 15.0f;
    }

    void RealDead()
    {
        this.gameObject.SetActive(false);
        this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        aiSystem.disTanceM = 10.0f;
    }
}