using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private RCC_CarControllerV3 rccController;
    private int TimerTime;

    [SerializeField] private TriggerComponent _triggerComponent;
    [SerializeField] private TableComponent _tableComponent;

    public event Action<string> ChangedTimerTime, ChangedCountdown;
    public event Action EndCountdown;

    private void Awake()
    {
        carController.enabled = false;
        rccController.enabled = false;
        _triggerComponent.СrossedFinish += EndGame;
    }
    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private void EndGame()
    {
        carController.enabled = false;
        rccController.enabled = false;
        StopAllCoroutines();

        _tableComponent.AddItem(TimerTime);
        _tableComponent.Show(true);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            TimerTime++;
            ChangedTimerTime?.Invoke((TimerTime % 600) < 100 ? $"{TimerTime / 600}:0{TimerTime / 10 % 60}:{TimerTime % 10}" : $"{TimerTime / 600}:{TimerTime / 10 % 60}:{TimerTime % 10}");
          
            yield return new WaitForSeconds(.1f);
        }
    }
    private IEnumerator Countdown()
    {
        for (int i = 5; i > 0; i--)
        {
            ChangedCountdown?.Invoke(i.ToString());

            yield return new WaitForSeconds(1);
        }

        ChangedCountdown?.Invoke("Start!");
        carController.enabled = true;
        rccController.enabled = true;
        StartCoroutine(Timer());
        yield return new WaitForSeconds(1);
        EndCountdown?.Invoke();

        yield break;
    }
}
