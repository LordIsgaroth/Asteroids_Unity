using System;
using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Базовое представление движения
    /// </summary>
    public abstract class MovementView : MonoBehaviour
    {
        protected float _movementSpeed = 0;

        public float MovementSpeed
        {
            get => _movementSpeed;

            set 
            {
                if (value < 0) throw new Exception("Speen cannot be negative!");

                _movementSpeed = value;
            } 
        }
    }
}
