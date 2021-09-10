using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// �������� ������� ���������
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