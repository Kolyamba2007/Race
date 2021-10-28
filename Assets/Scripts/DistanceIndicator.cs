using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour
{
    [SerializeField]
    private RCC_CarControllerV3 _player;

    [Header("UI")]
    [SerializeField]
    private RectTransform _currentPath;
    [SerializeField]
    private RectTransform _car;
    [SerializeField]
    private TMP_Text _distanceText;

    [Header("Options")]
    [SerializeField]
    private List<Transform> _points = new List<Transform>();

    private float width;
    private double distance;
    private byte currentPoint;

    private void Awake()
    {
        width = _currentPath.rect.width;
        distance = CalculateDistance();
        SetDistanceFactor(0f);
    }
    private void Update()
    {
        if (_player.speed == 0) return;

        //float distance = (_points[currentPoint].position - _player.transform.position).sqrMagnitude;
    }

    private double CalculateDistance()
    {
        float result = 0;
        for (int i = 0; i < _points.Count - 1; i++) result += Vector3.Distance(_points[i].position, _points[i + 1].position);
        return Math.Round(result, 1);
    }
    public void SetDistanceFactor(float factor)
    {
        float width = this.width * factor;
        _currentPath.sizeDelta = new Vector2(-this.width + width, 0);
        _currentPath.anchoredPosition = new Vector2(-(this.width - width) / 2, 0);
        _car.anchoredPosition = new Vector2(width, 0);

        double distance = Math.Round(this.distance - this.distance * factor, 1);
        _distanceText.text = $"{distance} m";
    }
}
