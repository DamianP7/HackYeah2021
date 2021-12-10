public class POIStairs : POI
{
    public override void Execute(Character character)
    {
        if (POIType == POIType.StairsUp)
            character.transform.position = LevelManager.Instance.stairsDown.placeOfAction;
        else
            character.transform.position = LevelManager.Instance.stairsUp.placeOfAction;
    }
}


