
namespace Weapons
{
    /// <summary>
    /// Представление оружия со снарядами
    /// </summary>
    public class WeaponWithChargesView : WeaponView
    {
        private int _currentCharges;
        private float _chargeCooldown;

        public int CurrentCharges => _currentCharges;
        public float ChargeCooldown => _chargeCooldown;

        public void UpdateCharges(int currentCharges, float chargeCooldown)
        {
            _currentCharges = currentCharges;
            _chargeCooldown = chargeCooldown;
        }
    }
}