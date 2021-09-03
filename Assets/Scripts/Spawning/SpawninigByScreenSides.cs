using System;
using UnityEngine;
using BaseObjects;
using UnityEngine.Events;

namespace Spawning
{
    /// <summary>
    /// Генерация с разных сторон игровой области
    /// </summary>
    public class SpawninigByScreenSides : ISpawning
    {        
        private float _topBorder;
        private float _bottomBorder;
        private float _leftBorder;
        private float _rightBorder;
        private ITypeSelection _enemyTypeSelector;
        private ICooldown _cooldownController;
        private Action _cooldownCompleted;             
        private System.Random _randomizer;

        public Action<SpawnParameters> OnSpawnEvent;

        private enum SpawnMode
        {
            top = 0,
            bottom = 1,
            left = 2,
            right = 3
        }

        public SpawninigByScreenSides(float spawningCooldown, MovementRestriction borders)
        {
            _randomizer = new System.Random();
            _enemyTypeSelector = new RandomEnemyTypeSelection();

            InitializeBorderValues(borders);

            double cooldownInMilliseconds = spawningCooldown * 1000;
            double cooldownStepInMilliseconds = 10;

            _cooldownController = new CooldownByStep(cooldownInMilliseconds, cooldownStepInMilliseconds);

            _cooldownCompleted = Spawn;
            _cooldownController.CooldownCompletedEvent += _cooldownCompleted;            
        }

        public void StartSpawning()
        {
            _cooldownController.StartCooldown();            
        }

        public void StopSpawning()
        {
            _cooldownController.StopCooldown();
        }

        private void InitializeBorderValues(MovementRestriction borders)
        {
            Collider2D bordersCollider = borders.GetComponent<Collider2D>();
            if (bordersCollider == null) throw new Exception("Borders does not contain Collider2D!");

            _topBorder = bordersCollider.bounds.max.y;
            _bottomBorder = bordersCollider.bounds.min.y;
            _leftBorder = bordersCollider.bounds.min.x;
            _rightBorder = bordersCollider.bounds.max.x;
        }

        private SpawnParameters GetSpawnParameters()
        {
            SpawnParameters parameters = new SpawnParameters();

            parameters.PrefabType = _enemyTypeSelector.SelectType();

            SpawnMode spawnMode = GetSpawnMode();
            double spawnX = 0;
            double spawnY = 0;
            float angle = 0;

            switch (spawnMode)
            {
                case SpawnMode.top:
                    spawnY = _topBorder;
                    spawnX = _randomizer.NextDouble() * (_rightBorder - _leftBorder) + _leftBorder;
                    if (spawnX > 0) angle = 135; else angle = -135;
                    break;
                case SpawnMode.bottom:
                    spawnY = _bottomBorder;
                    spawnX = _randomizer.NextDouble() * (_rightBorder - _leftBorder) + _leftBorder;
                    if (spawnX > 0) angle = 45; else angle = -45;
                    break;
                case SpawnMode.left:
                    spawnX = _leftBorder;
                    spawnY = _randomizer.NextDouble() * (_topBorder - _bottomBorder) + _bottomBorder;
                    if (spawnY > 0) angle = -135; else angle = -45;
                    break;
                case SpawnMode.right:
                    spawnX = _rightBorder;
                    spawnY = _randomizer.NextDouble() * (_topBorder - _bottomBorder) + _bottomBorder;
                    if (spawnY > 0) angle = 135; else angle = 45;
                    break;
            }

            parameters.Position = new Vector2((float)spawnX, (float)spawnY);
            parameters.RotationAngle = angle;

            return parameters;
        }

        private SpawnMode GetSpawnMode()
        {
            return (SpawnMode)Enum.GetValues(typeof(SpawnMode)).GetValue(_randomizer.Next(0, 4));
        }

        private void Spawn()
        {
            OnSpawnEvent?.Invoke(GetSpawnParameters());
            _cooldownController.StartCooldown();
        }

        ~SpawninigByScreenSides()
        {
            StopSpawning();
        }
    }
}