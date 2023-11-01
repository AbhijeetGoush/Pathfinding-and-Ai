
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyState
    {
        protected EnemyScript enemy;
        protected EnemyStateMachine eSm;


        // base constructor
        protected EnemyState(EnemyScript enemy, EnemyStateMachine eSm)
        {
            this.enemy = enemy;
            this.eSm = eSm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}
