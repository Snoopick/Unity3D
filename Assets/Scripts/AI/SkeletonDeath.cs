using UnityEngine;

namespace AI
{
    public class SkeletonDeath : Node
    {
        [SerializeField] private int health = 5;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject healthBar;

        private bool isAnimationRunning = false;
        
        public override NodeState Evaluate()
        {
            if (health == 0)
            {
                return NodeState.Success;
            }

            return NodeState.Failure;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var isBall = other.GetComponent<Ball>();
            
            Debug.Log(isBall);
            if (isBall != null && !isAnimationRunning)
            {
                health--;
                
                if (health >= 1)
                {
                    animator.SetTrigger("Hit");
                }
                else
                {
                    animator.SetTrigger("Death");
                    isAnimationRunning = true;
                }
            }
            
            Debug.Log(health);
        }
    }
}