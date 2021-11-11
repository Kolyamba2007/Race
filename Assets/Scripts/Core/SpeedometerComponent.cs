using TMPro;
using UnityEngine;

public class SpeedometerComponent : MonoBehaviour
{
    [SerializeField]
    private RCC_CarControllerV3 _player;
    [SerializeField]
    private TMP_Text _speedText;
    
    private void Update()
    {
        if (_player.speed == 0) return;

        _speedText.text = $"{Mathf.RoundToInt(_player.speed)} km/h";
    }
}
