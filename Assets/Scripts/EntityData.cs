using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{
    public float headHP, torsoHP, leftArmHP, rightArmHP, leftLegHP, rightLegHP;
    public float blood;
    public bool isBleeding;

    private void Start()
    {
        blood = 1.0f;
        isBleeding = false;
    }
}
