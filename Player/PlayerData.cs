using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static float CoinCount = 0;
    public static float MaxHealth = 100;
    public static float HealthPoint = 100;
    public static float LiveCount = 3;
    public static float MinDmg = 15;
    public static float MaxDmg = 25;
    public static float AttakSpeed = 7;
    public static float AttakInSecond = AttakSpeed / 2f;
    public static float MixturesCount = 3;
    public static float Score = 0;

    public static float WeaponUpLvl = 0;
    public static float DmgUp;

    public static int PlayerSkin = 0;
    public static int WeaponType = 0;

    public static int Quest_1 = 0;

    public static float SoundVolume = 0.5f;
    public static float MusicVolume = 0.5f;

    public static int MapActiv = 1;
    private void Update()
    {
        
        if (MaxHealth >= HealthPoint)
        {
            MaxHealth = HealthPoint;
        }
        
        if (LiveCount >= 3)
        {
            LiveCount = 3;
        }

        if (Quest_1 == 1)
        {
            MaxHealth += 50;

            MinDmg += 5;
            MaxDmg += 10;
        }
    }
}
