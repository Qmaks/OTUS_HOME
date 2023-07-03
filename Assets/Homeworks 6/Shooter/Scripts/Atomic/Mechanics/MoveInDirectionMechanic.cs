using System;
using Declarative;
using Lessons.Gameplay;
using UnityEngine;

[Serializable]
public sealed class MoveInDirectionMechanic : IUpdateListener
{
    private Transform _transform;
    private AtomicVariable<float> _speed;

    private Vector3 _direction;
        
    public void Construct(Transform transform, AtomicVariable<float> speed)
    {
        _transform = transform;
        _speed = speed;
    }
        
    void IUpdateListener.Update(float deltaTime)
    {
        _transform.position += _direction * (_speed.Value * deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
