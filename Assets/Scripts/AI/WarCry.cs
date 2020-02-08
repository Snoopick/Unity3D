using System;
using System.Collections;
using UnityEngine;

namespace AI
{
    public class WarCry : Node
    {
        [SerializeField] private Animator animator;
        private enum State
        {
            Wait,
            WarCry,
            Complete,
        }

        private State state;
        private Coroutine warCryCoroutine;
        private static readonly int WCry = Animator.StringToHash("WCry");

        public override NodeState Evaluate()
        {
            switch (state)
            {
                case State.Wait:
                    state = State.WarCry;
                    warCryCoroutine = StartCoroutine(WarCryProccess());
                    return NodeState.Running;
                case State.WarCry:
                    if (warCryCoroutine != null)
                    {
                        return NodeState.Running;
                    }
                    else
                    {
                        state = State.Complete;
                        return NodeState.Success;
                    }
                case State.Complete:
                    return NodeState.Failure; 
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator WarCryProccess()
        {
            animator.SetTrigger(WCry);
            yield return new WaitForSeconds(1.5f);
            warCryCoroutine = null;
        }
    }
}