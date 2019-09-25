using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponList
{
    public static Weapon_Sword GetWeapon_Sword(int weaponCode)
    {
        switch(weaponCode)
        {
            case 401: return new DiamondSowrd();
        }
        return null;
    }

    public static Weapon_Spear GetWeapon_Spear(int weaponCode)
    {
        switch (weaponCode)
        {
            case 501: return null;
        }
        return null;
    }

    public static Weapon_Bow GetWeapon_Bow(int weaponCode)
    {
        switch (weaponCode)
        {
            case 601: return new DefaultBow();
        }
        return null;
    }
}
