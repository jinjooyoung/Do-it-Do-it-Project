using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContorll : MonoBehaviour
{
    public LayerMask whatIsTarget; //추적대상 레이어
    private NavMeshAgent pathFinder; //경로 계산 AI 에이전트

    private Animator enemyAnimator; // 적 에니메이션

    public float damage = 20f; //공격력
    public float attackDelay = 1f;  //공격 딜레이
    private float lastAttackTime; // 마지막 공격 시점
    private float dist;     // 추적대상과의 거리

    public Transform tr;

    //private float attackRange = 2.3f;

    private bool hasTarget
    {
        get
        {
            //추적할 대상이 존재하고, 대상이 사망하지 않았다면 true
           // if (targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            //그렇지 않다면 false
            //return false;
        }
    }

    private bool canMove;
    private bool canAttack;

}



