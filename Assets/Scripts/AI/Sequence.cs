using UnityEngine;

namespace AI
{
    public class Sequence : Node
    {
        [SerializeField] private Node[] nodes;
        public override NodeState Evaluate()
        {
            var anyChildeRunning = false;
            foreach (var node in nodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Success:
                        continue;
                    case NodeState.Failure:
                        NodeState = NodeState.Failure;
                        return NodeState;
                    case NodeState.Running:
                        anyChildeRunning = true;
                        continue;
                    default:
                        break;
                }
            }

            NodeState = anyChildeRunning ? NodeState.Running : NodeState.Success;
            return NodeState;
        }
    }
}