using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : BaseButton
{
    public override void Execute(GameObject obj)
    {
        isPushed = false;
        obj.GetComponent<PlayerStatus>().Attack();
    }
}
