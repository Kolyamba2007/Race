using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarController carController;

    private void Awake()
    {
        carController.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        for (int i = 5; i > 0; i--)
        {
            UIManager.CountDown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        UIManager.CountDown.text = "Start!";
        carController.enabled = true;
        yield return new WaitForSeconds(1);
        UIManager.CountDown.enabled = false;

        yield break;
    }
}
