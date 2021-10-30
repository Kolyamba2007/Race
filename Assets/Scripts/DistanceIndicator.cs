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
    private double currentPath = 0;
    private double currentDistance = 0;
    private byte currentPoint;
    private const float minDistance = 50;
    private bool arrivedToFinish;

    private void Awake()
    {
        width = _currentPath.rect.width;
        distance = CalculateDistance();
        SetDistanceFactor(0f);
        _distanceText.text = $"{Math.Round(distance, 0)} m";
        currentDistance = (_points[currentPoint].position - _player.transform.position).magnitude; ;
    }
    private void Update()
    {
        if (_player.speed < .001f || arrivedToFinish) return;

        float _distance = (_points[currentPoint].position - _player.transform.position).magnitude;
        if (_distance < minDistance)
        {
            if (currentPoint + 1 >= _points.Count) currentPoint = 0;
            else currentPoint++;
            currentDistance = (_points[currentPoint].position - _player.transform.position).magnitude;
            currentPath += (_points[currentPoint].position - _points[currentPoint - 1].position).magnitude;
        }
        else
        {
            double path = currentPath + (currentDistance - _distance);
            float factor = (float)(path / distance);
            if (factor >= 1)
            {
                arrivedToFinish = true;
                SetDistanceFactor(1f);
                _distanceText.text = $"0 m";
            }
            SetDistanceFactor((float)(path / distance));
            _distanceText.text = $"{Math.Round(distance - path, 0)} m";
        }
    }

    private double CalculateDistance()
    {
        float result = 0;
        for (int i = 0; i < _points.Count - 1; i++) result += Vector3.Distance(_points[i].position, _points[i + 1].position);
        return Math.Round(result, 1);
    }
    private double GetRemainingDistance() => currentPath;

    public void SetDistanceFactor(float factor)
    {
        float width = Mathf.Lerp(0, this.width, factor);
        _currentPath.sizeDelta = new Vector2(-this.width + width, 0);
        _currentPath.anchoredPosition = new Vector2(-(this.width - width) / 2, 0);
        _car.anchoredPosition = new Vector2(width, 0);
    }
}
