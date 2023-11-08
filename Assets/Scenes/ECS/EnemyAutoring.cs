using Unity.Entities;
using UnityEngine;

namespace ECS.Step2
{
    // Authoring MonoBehaviours are regular GameObject components.
    // They constitute the inputs for the baking systems which generates ECS data.
    class EnemyAutoring : MonoBehaviour
    {
        public GameObject DisparoPrefab;
        public Transform Boquilla;
        class Baker : Baker<EnemyAutoring>
        {
            public override void Bake(EnemyAutoring authoring)
            {
                // GetEntity returns the baked Entity form of a GameObject.
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Enemy
                {
                    DisparoPrefab = GetEntity(authoring.DisparoPrefab, TransformUsageFlags.Dynamic),
                    Boquilla = GetEntity(authoring.Boquilla, TransformUsageFlags.Dynamic)
                });

                AddComponent<Shooting>(entity);
            }
        }
    }
    public struct Enemy : IComponentData
    {
        // These fields will be used in step 4.


        // This entity will reference the prefab to be instantiated when the cannon shoots.
        public Entity DisparoPrefab;

        // This entity will reference the nozzle of the cannon, where cannon balls should be spawned.
        public Entity Boquilla;
    }
    public struct Shooting : IComponentData, IEnableableComponent
    {
    }
}
