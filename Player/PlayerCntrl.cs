using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private float rotateX;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] Vector3 playerPos;
    [SerializeField] MonsterCtrl mc;

    public Animator anim;
    // 0 : Idle, 1 : Walk, 2 : BackWalk, 3 : Attack

	// Use this for initialization
	void Start ()
    {
        playerPos = this.transform.position;
        rotateSpeed = 30.0f;
        moveSpeed = 2.0f;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        this.transform.Rotate(0.0f, rotateX, 0.0f);
        anim.SetInteger("Anim", 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, playerPos.z * moveSpeed * Time.deltaTime));
            anim.SetInteger("Anim", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -playerPos.z * (moveSpeed / 2) * Time.deltaTime));
            anim.SetInteger("Anim", 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-playerPos.x * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
            anim.SetInteger("Anim", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(playerPos.x * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
            anim.SetInteger("Anim", 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("Anim", 3);
        }
    }

    void SlideAttack(MonsterCtrl msc)
    {
        msc.anim.SetTrigger("Dead");
    }
}
