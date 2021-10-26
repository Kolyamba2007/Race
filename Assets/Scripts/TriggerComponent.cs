using System;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private Collider blockCollider;

    public event Action СrossedFinish;
    
    private void OnTriggerEnter(Collider other)
    {
        blockCollider.enabled = false;
        СrossedFinish?.Invoke();
    }
}
