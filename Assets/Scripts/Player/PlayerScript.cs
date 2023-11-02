using Player;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider capsCol;
    public Animator anim;
    private string currentAnimState;
    public float xv, yv, zv;
    public float veritcalRunSpeed;
    public float horizontalRunSpeed;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;

    public int health;
    string healthString;
    public int points = 0;
    string pointsStr;
    const string PACMAN_RUNNING = "Pacman_Run";
    const string PACMAN_IDLE = "Pacman_Idle";
    

    public StandingState standingState;
    public RunningVerticalState runningVerticalState;
    public RunningHorizontalState runningHorizontalState;
    public StateMachine sm;
    // Start is called before the first frame update
    void Start()
    {
        sm = gameObject.AddComponent<StateMachine>();
        anim = GetComponent<Animator>();
        standingState = new StandingState(this, sm);
        runningVerticalState = new RunningVerticalState(this, sm);
        runningHorizontalState = new RunningHorizontalState(this, sm);
        sm.Init(standingState);
        health = 3;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthString = health.ToString();
        healthText.text = "Health: " + healthString;

        pointsStr = points.ToString();
        pointsText.text = "Score: " + pointsStr;

        sm.CurrentState.HandleInput();
        sm.CurrentState.LogicUpdate();

        if(health <= 0)
        {
            SceneManager.LoadScene(1);
        }
        if(points == 6)
        {
            SceneManager.LoadScene(2);
        }
    }

    void FixedUpdate()
    {
        sm.CurrentState.PhysicsUpdate();
        rb.velocity = new Vector3(xv, yv, zv);
    }
    public void CheckForhorizontalRun()
    {
        if(Input.GetKey("left"))
        {
            horizontalRunSpeed = -10;
            sm.ChangeState(runningHorizontalState);
            
            return;
        }
        if(Input.GetKey("right"))
        {
            anim.Play(PACMAN_RUNNING);
            horizontalRunSpeed = 10;
            sm.ChangeState(runningHorizontalState);
            return;
        }
    }

    public void CheckForVerticalRun()
    {
        if (Input.GetKey("up"))
        {
            
            veritcalRunSpeed = 10;
            sm.ChangeState(runningVerticalState);
            return;
        }
        if (Input.GetKey("down"))
        {
            
            veritcalRunSpeed = -10;
            sm.ChangeState(runningVerticalState);
        }
    }

    public void CheckForStand()
    {
        if (Input.GetKeyUp("left")) // key held down
        {
            sm.ChangeState(standingState);
        }
        if (Input.GetKeyUp("right")) // key held down
        {
            sm.ChangeState(standingState);
        }
        if (Input.GetKeyUp("up")) // key held down
        {
            sm.ChangeState(standingState);
        }
        if (Input.GetKeyUp("down")) // key held down
        {
            sm.ChangeState(standingState);
        }

        
    }
}
