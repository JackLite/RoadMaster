using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RoadCreatorAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    [SerializeField]
    private GameObject _roadPrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new RoadCreatorComponent()
        {
            prefab = conversionSystem.GetPrimaryEntity(_roadPrefab)
        };

        dstManager.AddComponentData(entity, data);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(_roadPrefab);
    }
}
