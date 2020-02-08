using UnityEngine;

namespace AI
{
    public class SkeletonMove : Node
    {
        [SerializeField] private Transform root;
        [SerializeField] private Animator animator;
        [SerializeField] private int speed = 1;
        private static readonly int Movement = Animator.StringToHash("Movement");
        private bool isRotated = false;

        public override NodeState Evaluate()
        {
            animator.SetInteger(Movement, speed);
            
            var player = FindObjectOfType<PlayerController>();

            if (player != null)
            {
                root.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
            }
            else
            {
                if (!isRotated)
                {
                    Quaternion target = Quaternion.Euler (0, 180, 0);
                    root.transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 25);
                }
                root.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            }
            
            

            return NodeState.Success;
        }
    }
}