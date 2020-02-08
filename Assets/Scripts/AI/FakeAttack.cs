using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class FakeAttack : Node
    {
        [SerializeField] private Animator animator;
        private Coroutine attackProcessCoroutine;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override NodeState Evaluate()
        {
            if (NodeState == NodeState.Failure)
            {
                return NodeState.Failure;
            }
            
            if (attackProcessCoroutine != null)
            {
                return NodeState.Running;
            }

            attackProcessCoroutine = StartCoroutine(AttackProcess());

            return NodeState.Success;
        }

        private IEnumerator AttackProcess()
        {
            animator.SetTrigger(Attack);
            yield return new WaitForSeconds(1f);
            attackProcessCoroutine = null;
            NodeState = NodeState.Failure;
        }
    }
}
