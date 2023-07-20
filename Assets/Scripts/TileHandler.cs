using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private float _tileWidth;

    private List<Tile> _tiles = new List<Tile>();

    private void OnEnable()
    {
        for (int i = 0; i < 2; i++)
        {
            Tile tile = Instantiate(_tilePrefab, transform);
            tile.NextTriggered += OnNextTriggered;
            tile.gameObject.SetActive(false);
            _tiles.Add(tile);
        }
    }

    private void OnDisable()
    {
        foreach (var tile in _tiles)
        {
            tile.NextTriggered -= OnNextTriggered;
        }
    }

    private void Start()
    {
        Tile tile = _tiles.FirstOrDefault(tile => tile.gameObject.activeSelf == false);
        tile.gameObject.SetActive(true);
        tile.transform.position = new Vector3(_tileWidth, 0, 0);
        tile.Init();
    }

    private void OnNextTriggered(Tile currentTile)
    {
        Tile tile = _tiles.FirstOrDefault(tile => tile != currentTile);
        tile.gameObject.SetActive(true);
        tile.transform.position = currentTile.transform.position + new Vector3(_tileWidth, 0, 0);
        tile.Init();
    }





























    //private void Start()
    //{

    //    tiles[2] = Instantiate(tilePrefab, tiles[1].transform.transform.position + new Vector3(tileWidth, 0, 0),
    //        Quaternion.identity, this.transform);
    //}

    //private void OnNextTriggered()
    //{
    //    Generate();
    //}

    //public void Generate()
    //{
    //    //if (tiles[0] != null) Destroy(tiles[0]);
    //    tiles[0] = tiles[1];
    //    tiles[1] = tiles[2];
    //    tiles[2] = Instantiate(tilePrefab, tiles[1].transform.transform.position + new Vector3(tileWidth, 0, 0),
    //        Quaternion.identity, this.transform);
    //}
}
