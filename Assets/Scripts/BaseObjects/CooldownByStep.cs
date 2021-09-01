using System.Timers;

namespace BaseObjects
{
    public class CooldownByStep : ICooldown
    {
        protected float _cooldownValue;
        protected float _cooldownStep;
        protected float _currentCooldown;
        protected Timer _cooldownTimer;

        public CooldownByStep(float cooldownInSeconds, float step)
        {
            _cooldownValue = cooldownInSeconds;
            _cooldownStep = step;
            _currentCooldown = 0;

            _cooldownTimer = new Timer(_cooldownStep * 1000);
            _cooldownTimer.Elapsed += UpdateCurrentCooldown;
        }

        public void StartCooldown()
        {
            _currentCooldown = _cooldownValue;
            _cooldownTimer.Start();
        }

        public float GetCurrentCooldown()
        {
            return _currentCooldown;
        }

        private void UpdateCurrentCooldown(object sender, ElapsedEventArgs e)
        {
            _currentCooldown -= _cooldownStep;

            if (_currentCooldown < 0) _currentCooldown = 0;
            if (_currentCooldown == 0) _cooldownTimer.Stop();            
        }
    }
}