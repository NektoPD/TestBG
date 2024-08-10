using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int PoorWalk = Animator.StringToHash(nameof(PoorWalk));
    private readonly int MediumWalk = Animator.StringToHash(nameof(MediumWalk));
    private readonly int RichWalk = Animator.StringToHash(nameof(RichWalk));
    private readonly int Finish = Animator.StringToHash(nameof(Finish));
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Spin = Animator.StringToHash(nameof(Spin));

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerProgress _playerProgress;

    private void OnEnable()
    {
        _playerProgress.MediumValueReached += SetMediumWalking;
        _playerProgress.RichValueReached += SetRichWalking;
        _playerProgress.PoorValueReached += SetPoorWalking;
    }

    private void OnDisable()
    {
        _playerProgress.MediumValueReached -= SetMediumWalking;
        _playerProgress.RichValueReached -= SetRichWalking;
        _playerProgress.PoorValueReached -= SetPoorWalking;
    }

    public void SetPoorWalking()
    {
        _animator.SetTrigger(PoorWalk);
    }

    public void SetMediumWalking()
    {
        SetSpinAnimation();
        _animator.SetTrigger(MediumWalk);
    }

    public void SetRichWalking()
    {
        SetSpinAnimation();
        _animator.SetTrigger(RichWalk);
    }

    public void SetFinishAnimation()
    {
        _animator.SetTrigger(Finish);
    }

    public void SetDieAnimation()
    {
        _animator.SetTrigger(Die);
    }

    public void SetSpinAnimation()
    {
        _animator.SetTrigger(Spin);
    }
    
}