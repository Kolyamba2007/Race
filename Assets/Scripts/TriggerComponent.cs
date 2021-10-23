using System;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private Collider blockCollider;

    public static event Action OnEndedGame;
    
    private void OnTriggerEnter(Collider other)
    {
        blockCollider.enabled = false;
        OnEndedGame?.Invoke();
    }
}
