using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToInterface : MonoBehaviour
{
    [SerializeField] private PlayerInformation _playerInformation;
    [SerializeField] private float _textUpdateTime;

    [SerializeField] private Text _playerPositionText;
    [SerializeField] private Text _playerAngleText;
    [SerializeField] private Text _playerSpeedText;
    [SerializeField] private Text _weaponChargesText;
    [SerializeField] private Text _weaponCooldownText;

    void Start()
    {
        StartCoroutine(UpdateText());
    }   

    private IEnumerator UpdateText()
    {
        yield return new WaitForSeconds(_textUpdateTime);

        while (true)
        {
            _playerPositionText.text = PositionToString();
            _playerAngleText.text = AngleToString();
            _playerSpeedText.text = SpeedToString();
            _weaponChargesText.text = WeaponChargesToString();
            _weaponCooldownText.text = WeaponCooldownToString();

            yield return new WaitForSeconds(_textUpdateTime);
        }         
    }

    private string PositionToString()
    {
        Vector2 position = _playerInformation.Position * 100;
        return $"{position.x:f2}; {position.y:f2}";
    }

    private string AngleToString()
    {
        float angle = _playerInformation.Angle;
        return $"{angle:f0}°";
    }

    private string SpeedToString()
    {
        return $"{_playerInformation.Speed * 360f:f2} M/h";
    }

    private string WeaponChargesToString()
    {        
        return $"{_playerInformation.WeaponCharges}";
    }

    private string WeaponCooldownToString()
    {
        return $"{_playerInformation.WeaponCooldown:f2} sec";
    }
}
