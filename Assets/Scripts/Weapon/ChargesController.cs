using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargesController
{
    protected int _maxCharges;
    protected float _chargeResetCooldown;
    protected int _currentCharges;
    protected float _currentResetCooldown;

    public int CurrentCharges { get => _currentCharges; }
    public float CurrentResetCooldown  { get => _currentResetCooldown; }

    public ChargesController(int maxCharges, float chargeResetCooldown)
    {
        _maxCharges = maxCharges;
        _currentCharges = _maxCharges;
        _chargeResetCooldown = chargeResetCooldown;
        _currentResetCooldown = _chargeResetCooldown;       
    }

    public void UseCharge()
    {
        if (_currentCharges > 0) _currentCharges--;
    }

    public void ReduceCooldown(float time)
    {
        if (_currentCharges == _maxCharges) return;        

        _currentResetCooldown -= time;

        if(_currentResetCooldown <= 0)
        {
            _currentResetCooldown = _chargeResetCooldown;
            _currentCharges++;
        }
    }
}
