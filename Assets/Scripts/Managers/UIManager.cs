using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _countDownText, _timerTimeText;

    public static Text CountDownText;
    public static Text TimerTimeText;

    private void Awake()
    {
        TriggerComponent.OnEndedGame += OpenResultsTable;
    }

    void OnEnable()
    {
        CountDownText = _countDownText;
        TimerTimeText = _timerTimeText;
    }

    private void OpenResultsTable()
    {
        //code
    }
}
