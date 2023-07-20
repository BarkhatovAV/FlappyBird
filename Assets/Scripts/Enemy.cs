using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _endValue; 
    [SerializeField] private float _duration; 

    void Start()
    {
        float delay = Random.Range(0, _duration);
        _endValue = - transform.position.y;
        transform.DOMoveY(_endValue, _duration).SetLoops(-1, LoopType.Yoyo).SetDelay(delay);
    }

    public void StartMove()
    {
        float delay = Random.Range(0, _duration);
        _endValue = - transform.position.y;
        transform.DOMoveY(_endValue, _duration).SetLoops(-1, LoopType.Yoyo).SetDelay(delay);
    }
}
