using System;

/// <summary>
/// Интерфейс управления кулдауном
/// </summary>
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