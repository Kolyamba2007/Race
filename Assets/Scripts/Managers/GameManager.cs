using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarController carController;
    private int TimerTime;

    private void Awake()
    {
        carController.enabled = false;
        TriggerComponent.OnEndedGame += EndGame;
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private void EndGame()
    {
        carController.enabled = false;
        StopAllCoroutines();
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            TimerTime++;
            UIManager.TimerTimeText.text = (TimerTime % 600) < 100 ? $"{TimerTime / 600}:0{TimerTime / 10 % 60}:{TimerTime % 10}" : $"{TimerTime / 600}:{TimerTime / 10 % 60}:{TimerTime % 10}";

            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator Countdown()
    {
        for (int i = 5; i > 0; i--)
        {
            UIManager.CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        UIManager.CountDownText.text = "Start!";
        carController.enabled = true;
        StartCoroutine(Timer());
        yield return new WaitForSeconds(1);
        UIManager.CountDownText.enabled = false;

        yield break;
    }
}
