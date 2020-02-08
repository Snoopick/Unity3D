using System;
using UnityEngine;

namespace AI
{
    public class SkeletonAi : MonoBehaviour
    {
        [SerializeField] private Node rootNode;

        private void Update()
        {
            rootNode.Evaluate();
        }
    }
}