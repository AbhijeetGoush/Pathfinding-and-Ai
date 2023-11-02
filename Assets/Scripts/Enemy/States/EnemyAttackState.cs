
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Enemy
{
    public class EnemyAttackState : EnemyState
    {
        FindPlayerState find;
        // constructor
        public EnemyAttackState(EnemyScript enemy, EnemyStateMachine eSm) : base(enemy, eSm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            enemy.nav.speed = 0;
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
            enemy.CheckForSearch();
            enemy.DamagePlayer();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}

