using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Создание врага
    /// </summary>
    public abstract class EnemyCreator
    {
        protected string _prefabName;
        protected Vector3 _spawnPosition;

        public EnemyCreator(Vector3 spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }

        public abstract GameObject Create();
    }
}