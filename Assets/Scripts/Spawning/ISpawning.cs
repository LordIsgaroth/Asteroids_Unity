using System;

namespace Spawning
{
    /// <summary>
    /// ��������� ��������� ��������
    /// </summary>
    public interface ISpawning
    {
        public void StartSpawning();
        public void StopSpawning();

        public event Action<SpawnParameters> OnSpawnEvent;
    }
}