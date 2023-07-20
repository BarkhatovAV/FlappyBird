using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _force = 1;
    
    private bool _isClose = false;
    private Transform player;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_isClose) 
            _rb.AddForce((player.position - transform.position) * _force);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out FoodCollector _))
        {
            _isClose = true;
            player = other.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out FoodCollector _))
        {
            _isClose = false;
        }
    }
}
