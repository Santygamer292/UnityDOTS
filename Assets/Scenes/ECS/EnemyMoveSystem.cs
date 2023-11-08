using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


namespace ECS.Step2 
{
    public partial struct EnemyMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            // Unless we disable "automatic bootstrapping", all systems are automatically instantiated and added to the default world.
            // This RequireForUpdate call makes this system update only if at least one entity has the Step2.TurretRotation component.
            // So when we play a scene, this system will only update if this component is added to an entity in a sub scene.
            // This pattern effectively allows each scene to choose whether a system should update.
            // (In this tutorial, we only want the systems from the current step and earlier to update for a given scene,
            // e.g. when running the Step 5 scene, we only want systems from steps 1-5 to update.)
            state.RequireForUpdate<Execute.EnemyMoveSystem>();
        }

        // This system doesn't need an OnDestroy method, so it uses the default empty one defined in ISystem.

        // See note above regarding the [BurstCompile] attribute.
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var dt = SystemAPI.Time.DeltaTime;

            foreach (var (transform, entity) in
                     SystemAPI.Query<RefRW<LocalTransform>>()
                         .WithAll<Enemy>()
                         .WithEntityAccess())
            {
                var pos = transform.ValueRO.Position;

                // This does not modify the actual position of the tank, only the point at
                // which we sample the 3D noise function. This way, every tank is using a
                // different slice and will move along its own different random flow field.
                pos.y = (float)entity.Index;

                var angle = (0.5f + noise.cnoise(pos / 10f)) * 4.0f * math.PI;
                var dir = float3.zero;
                math.sincos(angle, out dir.x, out dir.z);

                transform.ValueRW.Position += dir * dt * 5.0f;
                transform.ValueRW.Rotation = quaternion.RotateY(angle);
            }
        }
    }
}
