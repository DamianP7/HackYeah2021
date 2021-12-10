using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class POIObject : POI
{
    [Header("Action")]
    public ActionId action;
    public float actionTime;
    public Animator objectAnimator;
    public bool disableWhenFinish;

    [Tooltip("If true character will disable/fix it after some time")]
    public bool canBeDisabledAfterTime;
    public float disableTime;

    [Header("Reactions")]
    public AnimTrigger characterAnimTrigger;
    public AnimTrigger objectAnimTriggerAction;
    public AnimTrigger objectAnimTriggerDisable;

    public bool clickable = false;


    Character character;
    float timer;
    bool isTurnOn;

    public override void Execute(Character character)
    {
        this.character = character;

        clickable = true;
        character.animator.SetTrigger(characterAnimTrigger.ToString());
        objectAnimator.SetTrigger(objectAnimTriggerAction.ToString());

        StartCoroutine(FinishAction());
    }

    private void Update()
    {
        if (canBeDisabledAfterTime)
            timer -= Time.deltaTime;
    }

    IEnumerator FinishAction()
    {
        yield return new WaitForSeconds(actionTime);

        if (disableWhenFinish)
        {
            DisableObject();
            clickable = false;
        }

        character.ExecuteNextAction();
    }

    void DisableObject()
    {
        objectAnimator.SetTrigger(objectAnimTriggerDisable.ToString());
    }

    private void OnMouseDown()
    {
        if (!clickable)
            return;

        DisableObject();
    }

}