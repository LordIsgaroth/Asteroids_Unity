using UnityEngine;

namespace Spawning
{
    /// <summary>
    /// Параметры генерации объекта
    /// </summary>
    public struct SpawnParameters
    {
        public string PrefabType { get; set; }
        public Vector2 Position { get; set; }
        public float RotationAngle { get; set; }
    }
}