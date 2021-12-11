using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoPoint : Singleton<EcoPoint>
{
    [SerializeField] Animator animator;

    public void SpawnOnPoint(Vector3 point)
    {
        transform.position = point;
        animator.SetTrigger("Start");
        GameManager.Instance.EcoPoints++;
    }
}
