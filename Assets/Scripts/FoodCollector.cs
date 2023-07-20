using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Food _))
        {
            _counter.Increment();
            Destroy(other.gameObject);
        }
    }
}