using Unity.Entities;
using UnityEngine;


namespace ECS.Execute 
{
    public class ExecuteAutoring : MonoBehaviour
    {
        [Header("CaminarMuisca")]
        public bool MuiscWalk;

        [Header("AtacarMusica")]
        public bool MuiscAttack;

        [Header("PatrullarMuisca")]
        public bool MuiscaPatrol;
        [Header("Movimiento enemigo")]
        public bool EnemyMoveSystem;

        class Baker : Baker<ExecuteAutoring>
        {
            public override void Bake(ExecuteAutoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);

                if (authoring.MuiscWalk) AddComponent<MuiscWalk>(entity);
                if (authoring.MuiscAttack) AddComponent<MuiscAttack>(entity);
                if (authoring.MuiscaPatrol) AddComponent<MuiscaPatrol>(entity);
                if (authoring.EnemyMoveSystem) AddComponent<EnemyMoveSystem>(entity);

            }
        }
    }

    public struct MuiscWalk : IComponentData
    {
    }
    public struct MuiscAttack : IComponentData
    {
    }
    public struct MuiscaPatrol : IComponentData
    {
    }
    public struct EnemyMoveSystem : IComponentData
    {
    }
}

