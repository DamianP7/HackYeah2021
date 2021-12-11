using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	public float floorHeight;

	public POIStairs stairsUp, stairsDown;

	public Character character;

	public int playerRoom;
}
