using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerProgress _playerProgress;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
        _playerProgress.MinimumAmountReached += Die;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
        _playerProgress.MinimumAmountReached -= Die;
    }

    public void StartLevel()
    {
        _splineFollower.Enable();
        _animator.SetPoorWalking();
    }

    public void Finish()
    {
        _splineFollower.Disable();
        _animator.SetFinishAnimation();
    }

    public void Die()
    {
        _splineFollower.Disable();
        _animator.SetDieAnimation();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bottle)
        {
            _playerProgress.Decrease();
            interactable.Interact();
        }
        else if(interactable is Money)
        {
            _playerProgress.Increase();
            interactable.Interact();
        }
        else if(interactable is Finish)
        {
            Finish();
        }
    }
}
