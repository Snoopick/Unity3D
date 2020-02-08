using UnityEngine;

namespace AI
{
    public class PickUpBonus : Node
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
                    if (bonus)
                    {
                        var health = bonus.gameObject.GetComponent<Health>();
                        health.SetDamage(int.MaxValue);
                    }
                }
            }

            return NodeState.Failure;
        }
    }
}