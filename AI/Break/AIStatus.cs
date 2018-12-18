using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MonsterStatus))]
public class AIStatus : MonoBehaviour
{
    public AIStatusData AIStat;

    private void Awake()
    {
        Debug.Log(AIStatusData.maxHP);
    }
    
}
