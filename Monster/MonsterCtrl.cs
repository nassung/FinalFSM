using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] public Transform aiCharacter;
    [SerializeField] public AIAbility aab;
    public Animator anim;

    float disTanceAi;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        disTanceAi = Vector3.Distance(aiCharacter.transform.position, this.transform.position);

        if (disTanceAi <= 3.0f)
            anim.SetBool("Attack", true);
        else
            anim.SetBool("Attack", false);
    }

    void MonsterAttack()
    {
        aab.health -= 10.0f;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            anim.SetTrigger("Dead");
    }
}
