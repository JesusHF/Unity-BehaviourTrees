using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MinaBehaviorTree;

public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;
    private Animator _animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, GuardBT.fovRange, _enemyLayerMask);

            if (colliders.Length > 0)
            {
                _parent.Parent.SetData("target", colliders[0].transform);
                _animator.SetBool("Walking", true);
                _state = NodeState.Success;
                return _state;
            }

            _state = NodeState.Failure;
            return _state;
        }

        _state = NodeState.Success;
        return _state;
    }

}
