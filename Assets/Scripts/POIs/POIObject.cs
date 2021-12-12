using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class POIObject : POI
{
    [Header("Action")]
    public ActionId action;
    public float actionTime;
    public float animationDelay = 0;
    public Animator objectAnimator;
    public bool disableWhenFinish;
    [SerializeField] Collider2D collider2D;

    [Tooltip("If true character will disable/fix it after some time")]
    public bool canBeDisabledAfterTime;
    public float disableTime;

    [Header("Reactions")]
    public AnimTrigger characterAnimTrigger;
    public ObjectAnimTriggger objectAnimTriggerAction;
    public ObjectAnimTriggger objectAnimTriggerDisable;
    public float reactionTimeLimit;


    bool clickable = false;

    Character character;
    float timer;
    float reactionTimer;
    bool isTurnOn;

    private void Start()
    {
        if (collider2D == null)
            collider2D = GetComponent<Collider2D>();
    }

    public override void Execute(Character character)
    {
        this.character = character;

        character.animator.SetTrigger(characterAnimTrigger.ToString());
        StartCoroutine(WaitAndPlayAnimation());

        StartCoroutine(FinishAction());
    }

    IEnumerator WaitAndPlayAnimation()
    {
        yield return new WaitForSeconds(animationDelay);
        objectAnimator.SetTrigger(objectAnimTriggerAction.ToString());
    }

    private void Update()
    {
        if (canBeDisabledAfterTime)
            timer -= Time.deltaTime;
        if (clickable)
            reactionTimer -= Time.deltaTime;
    }

    IEnumerator FinishAction()
    {
        yield return new WaitForSeconds(actionTime - 1);

        if (disableWhenFinish || character.CheckHabit(action))
        {
            DisableObject();
            clickable = false;
        }
        else
        {
            clickable = true;
            reactionTimer = reactionTimeLimit;
        }

        yield return new WaitForSeconds(1);
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

        if (reactionTimer > 0)
        {
            character.ReinforceHabit(action);
            GameManager.Instance.EcoPoints++;
        }

        DisableObject();
        EcoAnimation();
    }

    void EcoAnimation()
    {
        Vector3 point = collider2D.transform.position;
        point.y += 0.5f;
        EcoPoint.Instance.SpawnOnPoint(point);
    }
}