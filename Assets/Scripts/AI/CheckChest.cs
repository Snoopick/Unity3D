using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AI
{
    public class CheckChest : Node
    {
        [SerializeField] private Transform forwardPoint;
        public override NodeState Evaluate()
        {
            var hit = new RaycastHit();

            if (Physics.Raycast(forwardPoint.position, forwardPoint.forward, out hit, 1f))
            {
                if (hit.collider != null)
                {
                    var bonus = hit.collider.GetComponent<BonusContainer>();
                    return bonus != null ? NodeState.Success : NodeState.Failure;
                }
            }

            return NodeState.Failure;
        }
    }
}
