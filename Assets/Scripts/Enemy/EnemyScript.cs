using Enemy;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    PlayerScript playerScr;
    public GameObject playerObj;
    public EnemyStateMachine eSm;
    public Animator anim;
    public NavMeshAgent nav;
    public EnemyAttackState enemyAttackState;
    public FindPlayerState findPlayerState;
    public Transform player;
    public Transform enemy;
    bool attackRange;
    

    int health;
    string healthString;
    float timer;
    float tillTimer = 1f;
    float attackTimer;
    float attacktillTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        eSm = gameObject.AddComponent<EnemyStateMachine>();
        findPlayerState = new FindPlayerState(this, eSm);
        enemyAttackState = new EnemyAttackState(this, eSm);
        playerScr = playerObj.GetComponent<PlayerScript>();
        eSm.Init(findPlayerState);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        attackRange = false;
        timer = tillTimer;
        attackTimer = attacktillTimer;
        anim.Play("Male_Walk");
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
        if(attackRange == true)
        {
            anim.Play("Male Attack 2");
            eSm.ChangeState(enemyAttackState);
        }
    }

    public void CheckForSearch()
    {
        if(attackRange == false)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if(timer < 0)
            {
                anim.Play("Male_Walk");
                eSm.ChangeState(findPlayerState);
            }
        }
    }

    public void DamagePlayer()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if(attackTimer < 0)
        {
            playerScr.health -= 1;
            attackTimer = attacktillTimer;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attackRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attackRange = false;
        }
    }
}
