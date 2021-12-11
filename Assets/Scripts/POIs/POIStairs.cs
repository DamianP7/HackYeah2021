using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class POIStairs : POI
{
    [SerializeField]
    Sprite openedDoor, closedDoor;

    SpriteRenderer spriteRenderer;
    [SerializeField] float timeOpenToTeleport;
    [SerializeField] float timeTeleportToClose;

    [SerializeField]
    int roomId;

    POIStairs otherDoor;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (POIType == POIType.StairsUp)
            otherDoor = LevelManager.Instance.stairsDown;
        else
            otherDoor = LevelManager.Instance.stairsUp;
    }

    public override void Execute(Character character)
    {
        StartCoroutine(OpenAndTeleport(character));
    }

    public void SpawnHereCharacter()
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator OpenAndTeleport(Character character)
    {
        spriteRenderer.sprite = openedDoor;
        character.animator.SetTrigger(AnimTrigger.Idle.ToString());
        yield return new WaitForSeconds(timeOpenToTeleport);

        character.gameObject.SetActive(false);

        yield return new WaitForSeconds(timeTeleportToClose/2);
        spriteRenderer.sprite = closedDoor;

        otherDoor.SpawnHereCharacter();
        character.animator.SetTrigger(AnimTrigger.Walk.ToString());
        character.transform.position = otherDoor.placeOfAction;
        character.gameObject.SetActive(true);
        character.ExecuteNextAction();

        yield return new WaitForSeconds(timeTeleportToClose / 2);

    }

    IEnumerator CloseDoor()
    {
        spriteRenderer.sprite = openedDoor;
        yield return new WaitForSeconds(timeTeleportToClose / 2);
        spriteRenderer.sprite = closedDoor;

        LevelManager.Instance.playerRoom = roomId;
    }

}


