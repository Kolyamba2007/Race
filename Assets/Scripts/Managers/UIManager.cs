using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _countDownText, _timerTimeText;

    [SerializeField] private TriggerComponent _triggerComponent;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _gameManager.ChangedTimerTime += (string text) => _timerTimeText.text = text;
        _gameManager.ChangedCountdown += (string text) => _countDownText.text = text;
        _gameManager.EndCountdown += () => _countDownText.enabled = false;

        _triggerComponent.СrossedFinish += OpenResultsTable;
    }

    private void OpenResultsTable()
    {
        //code
    }
}
