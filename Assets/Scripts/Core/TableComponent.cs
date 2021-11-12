using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableComponent : MonoBehaviour
{
    List<float> _table = new List<float>(10);

    public void AddItem(string timeText)
    {
        if (_table.Count == 10) return;
        var time = gameObject.transform.GetChild(_table.Count + 1).Find("Time").GetComponent<TMP_Text>();
        time.text = timeText;
    }
    public void AddItem(int index, string timeText)
    {
        if (_table.Count == 10) return;
        var time = gameObject.transform.GetChild(index + 1).Find("Time").GetComponent<TMP_Text>();
        time.text = timeText;
    }
    public void Clear()
    {
        _table.Clear();
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            var time = gameObject.transform.GetChild(i).Find("Time").GetComponent<TMP_Text>();
            time.text = "-";
        }
    }
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
