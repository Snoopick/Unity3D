using UnityEngine;

namespace AI
{
    public class SkeletonHit : Node
    {
        [SerializeField] private int health = 2;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject healthBar;

        private bool isAnimationRunning = false;
        
        public override NodeState Evaluate()
        {
            if (health < 1)
            {
                return NodeState.Success;
            }

            return NodeState.Failure;
        }
    }
}