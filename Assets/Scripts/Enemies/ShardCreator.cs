using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Создание осколка астероида
    /// </summary>
    public class ShardCreator : AsteroidCreator
    {
        public ShardCreator(Vector3 spawnPosition, float rotationAngle)
            : base(spawnPosition, rotationAngle)
        {
            _prefabName = "Shard";
        }
    }
}