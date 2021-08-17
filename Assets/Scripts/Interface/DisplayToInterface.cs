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
    [SerializeField] private Text _scoreText;

    void Start()
    {
        StartCoroutine(UpdatePlayerData());
    }   

    private IEnumerator UpdatePlayerData()
    {
        yield return new WaitForSeconds(_interfaceUpdateTime);

        while (true)
        {
            DisplayPlayerData();
            yield return new WaitForSeconds(_interfaceUpdateTime);
        }         
    }

    private void DisplayPlayerData()
    {
        _playerPositionText.text = _updater.PlayerInformation.PositionToString();
        _playerAngleText.text = _updater.PlayerInformation.AngleToString();
        _playerSpeedText.text = _updater.PlayerInformation.SpeedToString();
        _weaponChargesText.text = _updater.PlayerInformation.WeaponChargesToString();
        _weaponCooldownText.text = _updater.PlayerInformation.WeaponCooldownToString();
    }

    public void SetScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
