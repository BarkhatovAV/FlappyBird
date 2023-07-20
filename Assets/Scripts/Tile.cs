using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Food _foodTemplate;
    [SerializeField] private NextTileTrigger _nextTrigger;
    [Space(10)]
    [SerializeField] private float _width;
    [SerializeField] private float _heigh;
    [SerializeField] private int _maxEnemy;
    [SerializeField] private int _maxFood;

    private List<Enemy> _enemies = new List<Enemy>();

    public event Action<Tile> NextTriggered;

    private void OnEnable()
    {
        _nextTrigger.Triggered += OnTriggered;
    }

    private void OnDisable()
    {
        _nextTrigger.Triggered -= OnTriggered;
    }

    public void Init()
    {
        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);


        for (var i = 0; i < Random.Range(1, _maxEnemy + 1); i++)
        {
            Enemy enemy = GetAvailableEnemy();
            enemy.gameObject.SetActive(true);
            
        }

        for (var i = 0; i < Random.Range(1, _maxFood + 1); i++)
        {
            float x = Random.Range(-_width / 2, _width / 2);
            float y = Random.Range(-_heigh / 2, _heigh / 2);
            var position = transform.position + new Vector3(x, y);

            Instantiate(_foodTemplate, position, Quaternion.identity, this.transform);
        }
    }

    private Enemy GetAvailableEnemy()
    {
        Enemy enemy = _enemies.FirstOrDefault(enemy => enemy.gameObject.activeSelf == false);

        if (enemy == null)
        {
            float x = Random.Range(-_width / 2, _width / 2);
            float y = Random.Range(_heigh / 2, _heigh);
            var position = transform.position + new Vector3(x, y);
            enemy = Instantiate(_enemyTemplate, transform);
            enemy.transform.position = position;
            enemy.StartMove();
            _enemies.Add(enemy);
        }

        return enemy;
    }

    private void OnTriggered()
    {
        NextTriggered?.Invoke(this);
    }
}
