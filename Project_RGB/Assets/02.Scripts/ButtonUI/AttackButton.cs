using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : BaseButton
{
    public bool IsInteract { get; set; }

    private void Start()
    {
        IsInteract = false;
    }

    public override void Execute(GameObject obj)
    {
        isPushed = false;
        if (IsInteract)
            obj.GetComponent<PlayerStatus>().Interact();
        else
            obj.GetComponent<PlayerStatus>().Attack();
    }
}
