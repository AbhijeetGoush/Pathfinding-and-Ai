
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class FindPlayerState : EnemyState
    {

        public Transform playerPos;
        // constructor
        public FindPlayerState(EnemyScript enemy, EnemyStateMachine eSm) : base(enemy, eSm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            enemy.nav.speed = 4;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            enemy.CheckForAttack();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            playerPos = enemy.player;
            enemy.nav.destination = playerPos.position;
        }
    }
}
