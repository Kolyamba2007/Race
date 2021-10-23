using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _countDown;

    public static Text CountDown;

    void OnEnable()
    {
        CountDown = _countDown;
    }

    void Update()
    {
        
    }
}
