using UnityEngine;

namespace Spawning
{
    /// <summary>
    /// ��������� ��������� �������
    /// </summary>
    public struct SpawnParameters
    {
        public string PrefabType { get; set; }
        public Vector2 Position { get; set; }
        public float RotationAngle { get; set; }
    }
}