using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private enum Weapons{
        FIST,
        MARINE_RIFLE,
        GLADIUS,
        ZWEIHANDER,
        ABADDON
    };
    private void Attack(Weapons weapon)
    {
        switch(weapon)
        {
            case Weapons.FIST:
                break;
            case Weapons.MARINE_RIFLE:
                break;
            case Weapons.GLADIUS:
                break;
            case Weapons.ZWEIHANDER:
                break;
            case Weapons.ABADDON:
                break;
        }
    }
}
