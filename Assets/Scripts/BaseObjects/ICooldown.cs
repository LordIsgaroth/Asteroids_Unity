using System;
using UnityEngine.Events;

namespace BaseObjects
{
    public interface ICooldown
    {
        public void StartCooldown();
        public void StopCooldown();
        public float GetCurrentCooldown();

        public event Action CooldownCompletedEvent;        
    }
}