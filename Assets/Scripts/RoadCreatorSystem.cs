using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

public struct RoadCreateJob : IJobForEachWithEntity<RoadCreatorComponent>
{
    public EntityCommandBuffer.Concurrent commandBuffer;

    public void Execute(Entity entity, int index, [ReadOnly] ref RoadCreatorComponent rcc)
    {
        var instance = commandBuffer.Instantiate(index, rcc.prefab);
        var position = new float3(0, 0, 0);
        commandBuffer.AddComponent(index, instance, new Translation { Value = position });

        commandBuffer.DestroyEntity(index, entity);
    }
}

public class RoadCreatorSystem : JobComponentSystem
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new RoadCreateJob()
        {
            commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer()
        };
    }

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        
    }
}
