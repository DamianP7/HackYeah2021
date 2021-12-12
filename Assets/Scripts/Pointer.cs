using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Animator handAnimator;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 10;
            handAnimator.transform.position = pos;
            handAnimator.SetTrigger("Start");
        }
    }
}
