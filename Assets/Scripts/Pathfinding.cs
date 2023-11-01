using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class Pathfinding : MonoBehaviour
{
    public Transform[] points;

    private NavMeshAgent nav;
    private int destPoint;
    Animator anim;
    int randomSecondsTimer;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        randomSecondsTimer = Random.Range(1, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F))
        {
            
            print("random number: " + randomSecondsTimer);
        }
        StartCoroutine(Enemy());
    }

    IEnumerator Enemy()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
            yield return null;
        }
        if (destPoint == 4)
        {
            Attack();
            nav.speed = 0;
            yield return new WaitForSeconds(randomSecondsTimer);
            destPoint = 5;
            anim.Play("Male_Walk");
        }
        if(destPoint == 5)
        {
            nav.speed = 1;
            nav.destination = points[destPoint].position;
            
        }
        
    }
    void GoToNextPoint()
    {
        anim.Play("Male_Walk");

        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    void Attack()
    {
        anim.Play("Male Attack 2");
        
    }
}
