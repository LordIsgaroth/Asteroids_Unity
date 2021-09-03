using System;
using System.Timers;

namespace BaseObjects
{
    public class CooldownByStep : ICooldown
    {
        private double _cooldownValue;
        private double _cooldownStep;
        private double _currentCooldown;
        private Timer _cooldownTimer;

        public event Action CooldownCompletedEvent;        

        public CooldownByStep(double cooldown, double step)
        {
            _cooldownValue = cooldown;
            _cooldownStep = step;
            _currentCooldown = 0;

            _cooldownTimer = new Timer(_cooldownStep);
            _cooldownTimer.Elapsed += UpdateCurrentCooldown;
        }

        public void StartCooldown()
        {
            _currentCooldown = _cooldownValue;
            _cooldownTimer.Start();
        }

        public float GetCurrentCooldown()
        {
            return (float)_currentCooldown;
        }

        private void UpdateCurrentCooldown(object sender, ElapsedEventArgs e)
        {
            _currentCooldown -= _cooldownStep;

            if (_currentCooldown < 0) _currentCooldown = 0;
            if (_currentCooldown == 0)
            {
                _cooldownTimer.Stop();
                CooldownCompletedEvent?.Invoke();
            }                
        }

        public void StopCooldown()
        {
            _cooldownTimer.Stop();
            _currentCooldown = 0;
        }
    }
}