using System.Collections;
using UnityEngine;

public class POIAction : POI
{
    public float actionTime;
    public bool disableWhenFinish;
    public ClickableObject clickableObject;

    Character character;

    public override void Execute(Character character)
    {
        this.character = character;

        switch (POIType)
        {
            case POIType.Goto:
                break;
            case POIType.StairsUp:
                character.transform.position = LevelManager.Instance.stairsDown.placeOfAction;
                break;
            case POIType.StarisDown:
                character.transform.position = LevelManager.Instance.stairsUp.placeOfAction;
                break;
            case POIType.Action:
                clickableObject.clickable = true;
                break;
        }


        StartCoroutine(FinishAction());
    }

    IEnumerator FinishAction()
    {
        yield return new WaitForSeconds(actionTime);

        if (disableWhenFinish)
            clickableObject.clickable = false;
        character.ExecuteNextAction();
    }

}


