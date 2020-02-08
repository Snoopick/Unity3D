using UnityEngine;

namespace AI
{
    public class CheckOutField : Node
    {
        public override NodeState Evaluate()
        {
            return transform.position.z > 6f ? NodeState.Running : NodeState.Failure;
        }
    }
}