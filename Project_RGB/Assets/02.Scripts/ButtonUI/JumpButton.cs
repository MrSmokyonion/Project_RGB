using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : BaseButton
{
    public bool isJumping;

    private void Start()
    {
        isJumping = false;
    }

    public override void Execute(GameObject obj)
    {
        isPushed = false;
        isJumping = true;
        obj.GetComponent<ControlManager>().Move_Jump();
    }
}
