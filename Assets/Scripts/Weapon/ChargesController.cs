using BaseObjects;
using System;

namespace Weapons
{
    /// <summary>
    /// Управление зарядами
    /// </summary>
    public class ChargesController
    {
        private int _maxCharges;        
        private int _currentCharges;       
        private ICooldown _cooldownController;        
        private Action _cooldownCompleted;

        public int CurrentCharges => _currentCharges;
        public float CurrentResetCooldown => _cooldownController.GetCurrentCooldown()/1000;

        public ChargesController(int maxCharges, float chargeResetCooldown)
        {
            _maxCharges = maxCharges;
            _currentCharges = _maxCharges;            

            double cooldownInMilliseconds = chargeResetCooldown * 1000;
            double cooldownStepInMilliseconds = 10;

            _cooldownController = new CooldownByStep(cooldownInMilliseconds, cooldownStepInMilliseconds);

            _cooldownCompleted = RestoreCarge;
            _cooldownController.CooldownCompletedEvent += _cooldownCompleted;
        }

        public void UseCharge()
        {
            if (_currentCharges > 0)
            {
                _currentCharges--;
                if (CurrentResetCooldown == 0) _cooldownController.StartCooldown();
            }                
        }

        private void RestoreCarge()
        {            
            _currentCharges++;

            if (_currentCharges < _maxCharges) _cooldownController.StartCooldown();            
        }
    }
}
