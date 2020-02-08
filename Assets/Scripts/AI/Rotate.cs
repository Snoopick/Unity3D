using UnityEngine;

namespace AI
{
    public class Rotate : Node
    {
        [SerializeField] private float angle;
        [SerializeField] private Transform root;
        public override NodeState Evaluate()
        {
            Quaternion target = Quaternion.Euler (0, angle, 0);
            root.transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 25);

            return NodeState.Success;
        }
    }
}