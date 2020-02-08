using UnityEngine;

namespace AI
{
    public class EndMap : Node
    {
        public override NodeState Evaluate()
        {
            var player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(180f, 0, 0), Time.deltaTime * 1);
            }
            
            return NodeState.Success;
        }
    }
}