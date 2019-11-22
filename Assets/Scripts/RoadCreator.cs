using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class RoadCreator : MonoBehaviour
{
    public GameObject roadPrefab;
    void Start()
    {
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(roadPrefab, World.Active);
        var manager = World.Active.EntityManager;
        var entity = manager.Instantiate(prefab);
    }
}
