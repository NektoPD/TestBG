using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _poorOutfit;
    [SerializeField] private SkinnedMeshRenderer _mediumOutfit;
    [SerializeField] private SkinnedMeshRenderer _richOutfit;
    [SerializeField] private PlayerProgress _playerProgress;
    
    private void OnEnable()
    {
        _playerProgress.PoorValueReached += SetPoorOutfit;
        _playerProgress.MediumValueReached += SetMediumOutfit;
        _playerProgress.RichValueReached += SetRichOutfit;
    }

    private void OnDisable()
    {
        _playerProgress.PoorValueReached -= SetPoorOutfit;
        _playerProgress.MediumValueReached -= SetMediumOutfit;
        _playerProgress.RichValueReached -= SetRichOutfit;
    }

    private void SetPoorOutfit()
    {
        _poorOutfit.gameObject.SetActive(true);
        _mediumOutfit.gameObject.SetActive(false);
        _richOutfit.gameObject.SetActive(false);
    }

    private void SetMediumOutfit()
    {
        _poorOutfit.gameObject.SetActive(false);
        _mediumOutfit.gameObject.SetActive(true);
        _richOutfit.gameObject.SetActive(false);
    }

    private void SetRichOutfit()
    {
        _poorOutfit.gameObject.SetActive(false);
        _mediumOutfit.gameObject.SetActive(false);
        _richOutfit.gameObject.SetActive(true);
    }
}
