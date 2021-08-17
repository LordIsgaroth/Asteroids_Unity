using UnityEngine;

public class PlayerInformation
{   
    public Vector2 Position { get; set; }
    public float Angle { get; set; }
    public float Speed { get; set; }
    public int WeaponCharges { get; set; }
    public float ChargeCooldown { get; set; }

    public string PositionToString()
    {     
        return $"{Position.x*100:f2}; {Position.y*100:f2}";
    }

    public string AngleToString()
    {        
        return $"{Angle:f0}°";
    }

    public string SpeedToString()
    {
        return $"{Speed * 360f:f2} M/h";
    }

    public string WeaponChargesToString()
    {
        return $"{WeaponCharges}";
    }

    public string WeaponCooldownToString()
    {
        return $"{ChargeCooldown:f2} sec";
    }
}
