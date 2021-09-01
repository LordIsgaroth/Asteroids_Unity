using BaseObjects;
using System.Threading.Tasks;

namespace Weapons
{
    /// <summary>
    /// Управление зарядами
    /// </summary>
    public class ChargesController
    {
        private int _maxCharges;
        private float _chargeResetCooldown;
        private int _currentCharges;       
        private ICooldown _cooldownController;
        private Task _chargesManager;

        public int CurrentCharges { get => _currentCharges; }
        public float CurrentResetCooldown { get => _cooldownController.GetCurrentCooldown(); }

        public ChargesController(int maxCharges, float chargeResetCooldown)
        {
            _maxCharges = maxCharges;
            _currentCharges = _maxCharges;
            _chargeResetCooldown = chargeResetCooldown;            

            float cooldownStep = 0.001f;
            _cooldownController = new CooldownByStep(_chargeResetCooldown, cooldownStep);

            _chargesManager = new Task(ManageCarges);
            _chargesManager.Start();
        }

        public void UseCharge()
        {
            if (_currentCharges > 0)
            {
                _currentCharges--;
                if (CurrentResetCooldown == 0) _cooldownController.StartCooldown();
            }                
        }

        private void ManageCarges()
        {
            while(true)
            {
                if (_currentCharges == _maxCharges) continue;

                if (CurrentResetCooldown == 0)
                {
                    _currentCharges++;
                    _cooldownController.StartCooldown();
                }
            }
        }
    }
}
