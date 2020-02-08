using System.Collections;
using UnityEngine;

namespace AI
{
    public class SkeletonAttack : Node
    {
        [SerializeField] private Animator animator;
        private Coroutine attackProcessCoroutine;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public override NodeState Evaluate()
        {
            if (attackProcessCoroutine != null)
            {
                return NodeState.Running;
            }

            var player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                return NodeState.Failure;
            }

            if(Vector3.Distance(transform.position, player.transform.position) > 1f)
            {
                return NodeState.Failure;
            }

            attackProcessCoroutine = StartCoroutine(AttackProcess());

            return NodeState.Success;
        }

        private IEnumerator AttackProcess()
        {
            animator.SetTrigger(Attack);
            yield return new WaitForSeconds(1f);
            attackProcessCoroutine = null;
            
            var player = FindObjectOfType<PlayerController>();
            player.gameObject.SetActive(false);
        }
    }
}