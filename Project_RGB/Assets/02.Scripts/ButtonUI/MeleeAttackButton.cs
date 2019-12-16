using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MeleeAttackButton : AttackButton
{
    public GameObject player;

    [HideInInspector]
    public bool isSpear;

    private Image img;
    private SpriteRenderer sr;

    private void Start()
    {
        IsInteract = false;
        isSpear = false;
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (isPushed) charging += Time.deltaTime;
        else charging = 0f;

        if (isSpear)
        {
            if (charging >= 1f) img.color = Color.black;
            else img.color = Color.white;
        }
    }

    public override void Execute(GameObject obj)
    {
        sr = player.GetComponent<SpriteRenderer>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isPushed = false;
        if (IsInteract)
            player.GetComponent<PlayerStatus>().Interact();
        else if (charging >= 1f && isSpear)
            player.GetComponent<PlayerStatus>().Attack(sr.flipX ? 180 : 0, new Vector2(sr.flipX ? -1f : 1f, 0f));
        else
            player.GetComponent<PlayerStatus>().Attack();
    }
}
