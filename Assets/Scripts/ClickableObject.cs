using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CircleCollider2D))]
public class ClickableObject : MonoBehaviour
{
    public bool clickable = false;

    public UnityEvent onClickEvent;

    private void OnMouseDown()
    {
        if (!clickable)
            return;

        onClickEvent?.Invoke();
    }
}
