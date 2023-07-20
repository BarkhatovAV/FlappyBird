using System;
using UnityEngine;

public class NextTrigger : MonoBehaviour
{
    public event Action Triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out FoodCollector _))
        {
            Triggered?.Invoke();
        }
    }
}
