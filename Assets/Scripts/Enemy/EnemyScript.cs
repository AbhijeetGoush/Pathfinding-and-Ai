using Enemy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public EnemyStateMachine eSm;
    public Animator anim;
    public NavMeshAgent nav;
    public EnemyAttackState enemyAttackState;
    public FindPlayerState findPlayerState;
    public Transform player;
    public Transform enemy;

    
    // Start is called before the first frame update
    void Start()
    {
        eSm = gameObject.AddComponent<EnemyStateMachine>();
        findPlayerState = new FindPlayerState(this, eSm);
        enemyAttackState = new EnemyAttackState(this, eSm);
        eSm.Init(findPlayerState);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        eSm.CurrentState.HandleInput();
        eSm.CurrentState.LogicUpdate();
        
    }

    private void FixedUpdate()
    {
        eSm.CurrentState.PhysicsUpdate();
    }

    public void CheckForAttack()
    {
        if (nav.remainingDistance < 2f)
        {
            anim.Play("Male Attack 2");
            eSm.ChangeState(enemyAttackState);
        }
    }

    public void CheckForSearch()
    {
        if (!nav.pathPending && nav.remainingDistance > 1f)
        {
            nav.ResetPath();
            anim.Play("Male_Walk");
            eSm.ChangeState(findPlayerState);
        }
    }
}
