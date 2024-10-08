using UnityEngine;

namespace MinaBehaviorTree
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        private Node _root = null;

        private void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
            {
                _root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }
}
