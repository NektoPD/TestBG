using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _startUI;
    [SerializeField] private Canvas _gamePlayUI;
    [SerializeField] private Player _player;
    
    private void Start()
    {
        _gamePlayUI.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _player.StartLevel();
            _gamePlayUI.enabled = true;
            _startUI.enabled = false;
        }
    }
}
