using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class BaseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool isPushed;

    private void Start()
    {
        isPushed = false;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " is Pushed!");
        isPushed = true;
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " is Released!");
        isPushed = false;
    }

    public abstract void Execute(GameObject obj);
}

public abstract class AttackButton : BaseButton { [HideInInspector] public bool IsInteract; }