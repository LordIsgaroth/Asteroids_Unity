using System;

namespace Spawning
{
    /// <summary>
    /// Интерфейс генерации объектов
    /// </summary>
    public interface ISpawning
    {
        public void StartSpawning();
        public void StopSpawning();

        public event Action<SpawnParameters> OnSpawnEvent;
    }
}