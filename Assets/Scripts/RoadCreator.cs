using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject _roadPrefab;

    void Start()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for(var i = 0; i < 11; i++)
        {
            AddRoad(new Cell() { X = i, Y = 0 });
            AddRoad(new Cell() { X = i, Y = 10 });
        }

        for (var i = 1; i < 10; i++)
        {
            AddRoad(new Cell() { X = 0, Y = i });
            AddRoad(new Cell() { X = 10, Y = i });
        }

    }

    private void AddRoad(Cell cell)
    {
        var position = new Vector2(cell.X + 0.5f, cell.Y + 0.5f);
        Instantiate(_roadPrefab, position, Quaternion.identity, transform);
    }
}
