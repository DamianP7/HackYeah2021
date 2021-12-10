using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action
{
	public Vector3 position;
	public string AnimationTrigger;
	public string AnimationEcoTrigger;

	public Action(Vector3 position, string animationTrigger = "", string animationEcoTrigger = "")
	{
		this.position = position;

		if(animationTrigger != "")
			AnimationTrigger = animationTrigger;
		if (animationEcoTrigger != "")
			AnimationEcoTrigger = animationEcoTrigger;
	}
}

