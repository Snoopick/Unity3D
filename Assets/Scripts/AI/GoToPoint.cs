using UnityEngine;

namespace AI
{
    public class GoToPoint : Node
    {
        [SerializeField] private float xPoint = 0f;
        [SerializeField] private float zPoint = 0f;
        [SerializeField] private Transform root;
        [SerializeField] private int side = 1;

        private bool isRotate = false;
        public override NodeState Evaluate()
        {
            switch (side)
            {
                case 1:

                    if (transform.position.z > zPoint)
                    {
                        root.Translate(new Vector3(transform.position.x, transform.position.y, zPoint) * Time.deltaTime * 1, Space.World);
                        return NodeState.Running;
                    }

                    return NodeState.Failure;
                case -1: 
                    
                    
                    if (transform.position.z < zPoint)
                    {
                        root.Translate(new Vector3(transform.position.x, transform.position.y, zPoint) * Time.deltaTime * 1, Space.World);
                        return NodeState.Running;
                    }

                    return NodeState.Failure;
                case 2:
                    if (!isRotate)
                    {
                        Quaternion target = Quaternion.Euler (0, 90, 0);
                        root.transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 45);
                        isRotate = true;
                    }
                    
                    if (transform.position.x > xPoint)
                    {
                        root.Translate(new Vector3(xPoint, transform.position.y, 6) * Time.deltaTime * 1, Space.World);
                        return NodeState.Running;
                    }
                    
                    isRotate = false;
                    if (!isRotate)
                    {
                        Quaternion target = Quaternion.Euler(0, 0, 0);
                        root.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 45);
                        isRotate = true;
                    }

                    return NodeState.Failure;
                case -2:

                    if (!isRotate)
                    {
                        Quaternion target = Quaternion.Euler (0, -90, 0);
                        root.transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 180);
                        isRotate = true;
                    }


                    if (transform.position.x < xPoint)
                    {
                        root.Translate(new Vector3(xPoint, transform.position.y, 5.9f) * Time.deltaTime * 2, Space.World);
                        return NodeState.Running;
                    }

                    isRotate = false;
                    if (!isRotate)
                    {
                        Quaternion target = Quaternion.Euler(0, 0, 0);
                        root.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 45);
                        isRotate = true;
                    }

                    return NodeState.Failure;
            }

            return NodeState.Failure;
        }
    }
}