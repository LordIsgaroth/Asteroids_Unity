using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToInterface : MonoBehaviour
{
    [SerializeField] private PlayerInformationUpdating _updater;
    [SerializeField] private float _interfaceUpdateTime;

    [SerializeField] private Text _playerPositionText;
    [SerializeField] private Text _playerAngleText;
    [SerializeField] private Text _playerSpeedText;
    [SerializeField] private Text _weaponChargesText;
    [SerializeField] private Text _weaponCooldownText;

    void Start()
    {
        StartCoroutine(UpdateInterface());
    }   

    private IEnumerator UpdateInterface()
    {
        yield return new WaitForSeconds(_interfaceUpdateTime);

        while (true)
        {
            Display();
            yield return new WaitForSeconds(_interfaceUpdateTime);
        }         
    }

    private void Display()
    {
        _playerPositionText.text = _updater.PlayerInformation.PositionToString();
        _playerAngleText.text = _updater.PlayerInformation.AngleToString();
        _playerSpeedText.text = _updater.PlayerInformation.SpeedToString();
        _weaponChargesText.text = _updater.PlayerInformation.WeaponChargesToString();
        _weaponCooldownText.text = _updater.PlayerInformation.WeaponCooldownToString();
    }
}
