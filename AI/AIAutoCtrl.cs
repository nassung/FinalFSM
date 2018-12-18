using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAutoCtrl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] AIFSMSystem afs;
    NavMeshAgent navi;
    public Animator anim;

    public float distance;

    private float naviTime;

	// Use this for initialization
	void Start () 
    {
        navi = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        naviTime += Time.deltaTime;

        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (afs.aiCondition == AICondition.Idle)
        {
            if (naviTime / 3 >= 0.0f)
            {
                navi.destination = player.transform.position;
                anim.SetInteger("Anim", 1);
            }

            if (distance <= 3.0f)
            {
                anim.SetInteger("Anim", 0);
            }
        }

        if (afs.aiCondition == AICondition.Kick)
        {
            if (afs.disTanceM <= 5.0f)
                navi.destination = afs.target[0].transform.position;
            else if (afs.disTanceB <= 5.0f)
                navi.destination = afs.target[1].transform.position;
        }
    }
    
}
