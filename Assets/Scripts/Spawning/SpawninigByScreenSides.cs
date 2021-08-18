using System;
using UnityEngine;
using BaseObjects;

namespace Spawning
{
    /// <summary>
    /// Генерация с разных сторон игровой области
    /// </summary>
    public class SpawninigByScreenSides : ISpawning
    {
        private MovementRestriction _borders;

        private enum SpawnMode
        {
            top = 0,
            bottom = 1,
            left = 2,
            right = 3
        }

        public SpawninigByScreenSides(MovementRestriction borders)
        {
            _borders = borders;
        }

        public SpawnParameters GetSpawnParameters()
        {
            SpawnParameters parameters = new SpawnParameters();

            Collider2D bordersCollider = _borders.GetComponent<Collider2D>();

            if (bordersCollider == null) throw new Exception("Borders does not contain Collider2D!");

            float topBorder = bordersCollider.bounds.max.y;
            float bottomBorder = bordersCollider.bounds.min.y;
            float leftBorder = bordersCollider.bounds.min.x;
            float rightBorder = bordersCollider.bounds.max.x;

            SpawnMode spawnMode = GetSpawnMode();
            float spawnX = 0;
            float spawnY = 0;
            float angle = 0;

            switch (spawnMode)
            {
                case SpawnMode.top:
                    spawnY = topBorder;
                    spawnX = UnityEngine.Random.Range(leftBorder, rightBorder);
                    if (spawnX > 0) angle = 135; else angle = -135;
                    break;
                case SpawnMode.bottom:
                    spawnY = bottomBorder;
                    spawnX = UnityEngine.Random.Range(leftBorder, rightBorder);
                    if (spawnX > 0) angle = 45; else angle = -45;
                    break;
                case SpawnMode.left:
                    spawnX = leftBorder;
                    spawnY = UnityEngine.Random.Range(bottomBorder, topBorder);
                    if (spawnY > 0) angle = -135; else angle = -45;
                    break;
                case SpawnMode.right:
                    spawnX = rightBorder;
                    spawnY = UnityEngine.Random.Range(bottomBorder, topBorder);
                    if (spawnY > 0) angle = 135; else angle = 45;
                    break;
            }

            parameters.Position = new Vector2(spawnX, spawnY);
            parameters.RotationAngle = angle;

            return parameters;
        }

        private SpawnMode GetSpawnMode()
        {
            return (SpawnMode)Enum.GetValues(typeof(SpawnMode)).GetValue(UnityEngine.Random.Range(0, 4));
        }
    }

}