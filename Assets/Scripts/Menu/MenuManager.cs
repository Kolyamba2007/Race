using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private GameConfig _gameConfig;
    [SerializeField]
    private TMP_Text _nicknameText;

    private bool IsNullOrEmpty(string text)
    {
        if (string.IsNullOrEmpty(text)) return true;

        string _text = _nicknameText.text;
        int index = _text.IndexOf((char)8203);
        while (index >= 0)
        {
            _text = _text.Remove(index, 1);
            index = _text.IndexOf((char)8203);
        }
        return _text.Length == 0;
    }

    public void StartRace_UnityEditor()
    { 
        if (IsNullOrEmpty(_nicknameText.text))
        {
            Debug.LogWarning("Player's nickname can't be null/empty!");
            return;
        }               
        _gameConfig.Nickname = _nicknameText.text;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Quit_UnityEditor()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
