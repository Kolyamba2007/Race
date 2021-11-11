using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableComponent : MonoBehaviour
{
    List<float> _table = new List<float>(10);

    private string ParseTimeToString(float seconds)
    {
        return (seconds % 600) < 100 ? $"{seconds / 600}:0{seconds / 10 % 60}:{seconds % 10}" : $"{seconds / 600}:{seconds / 10 % 60}:{seconds % 10}";
    }

    public void AddItem(float seconds)
    {
        var time = gameObject.transform.GetChild(_table.Count + 1).Find("Time").GetComponent<TMP_Text>();
        time.text = ParseTimeToString(seconds);
    }
    public void AddItem(int index, float seconds)
    {
        var time = gameObject.transform.GetChild(index + 1).Find("Time").GetComponent<TMP_Text>();
        time.text = ParseTimeToString(seconds);
    }
    public void Clear()
    {
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            var time = gameObject.transform.GetChild(i).Find("Time").GetComponent<TMP_Text>();
            time.text = "-";
        }
    }
}
