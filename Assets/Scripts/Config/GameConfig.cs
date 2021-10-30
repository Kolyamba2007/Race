using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configuration/Game Config")]
public class GameConfig : ScriptableObject, IConfig
{
    [Header("Game Options")]
    [SerializeField]
    private string _nickname;

    public string Nickname { set => _nickname = value; get => _nickname; }
}
