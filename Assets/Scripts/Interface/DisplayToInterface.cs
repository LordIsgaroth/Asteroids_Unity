using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Movement;
using Weapons;

/// <summary>
/// Вывод информации в пользовательский интерфейс
/// </summary>
public class DisplayToInterface : MonoBehaviour
{
    [SerializeField] private MovementView _movementView;
    [SerializeField] private WeaponWithChargesView _weaponView;
    [SerializeField] private PlayerPositionView _positionView;
    
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

    //Если выводить информацию каждый кадр,
    //её трудно будет воспринимать
    //поэтому реализован вывод раз в заданный промежуток времени
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
        _playerPositionText.text = PositionToString();
        _playerAngleText.text = AngleToString();
        _playerSpeedText.text = SpeedToString();
        _weaponChargesText.text = WeaponChargesToString();
        _weaponCooldownText.text = WeaponCooldownToString();
    }

    private string PositionToString()
    {
        return $"{_positionView.CurrentPositon.x * 100:f2}; {_positionView.CurrentPositon.y * 100:f2}";
    }

    private string AngleToString()
    {
        return $"{_positionView.CurrentAngle:f0}°";
    }

    private string SpeedToString()
    {
        return $"{_movementView.MovementSpeed * 360f:f2} M/h";
    }

    private string WeaponChargesToString()
    {
        return $"{_weaponView.CurrentCharges}";
    }

    private string WeaponCooldownToString()
    {
        return $"{_weaponView.ChargeCooldown:f2} sec";
    }

    public void SetScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
