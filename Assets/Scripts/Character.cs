using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public List<POI> actions;
	public Animator animator;


	[SerializeField] float speed;

	POI stairsUp;
	POI stairsDown;

	[SerializeField]
	float poiDistanceTolerance;

	List<POI> actionsToDo = new List<POI>();
	Dictionary<ActionId, int> habits = new Dictionary<ActionId, int>();

	int lastAction = 0;
	Vector3 target;
	bool waitForAction = false;

	void Awake()
	{
		target = transform.position;
	}

	IEnumerator Start()
	{
		stairsDown = LevelManager.Instance.stairsDown;
		stairsUp = LevelManager.Instance.stairsUp;

		animator.SetTrigger(AnimTrigger.Idle.ToString());

		yield return new WaitForSeconds(2);

		ExecuteNextAction();	
	}

	private void Update()
	{
		if(target != transform.position)
		{
			if (transform.position.x > target.x)
				transform.localScale = new Vector3(1, 1, 1);
			else
				transform.localScale = new Vector3(-1, 1, 1);

			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		}
		else if (waitForAction)
		{
			waitForAction = false;
			ExecuteNextAction();
		}
	}

	public void ExecuteAction(POI poi)
	{
		if (!IsInPosition(poi.placeOfAction))
		{
			actionsToDo.Add(poi);

			if (Mathf.Abs(poi.placeOfAction.y - transform.position.y) > LevelManager.Instance.floorHeight)
			{
				if (poi.placeOfAction.y < transform.position.y)
					ExecuteAction(stairsDown);
				else
					ExecuteAction(stairsUp);
			}
			else
			{
				WalkTo(poi);
			}
		}
		else
		{
			if(poi.isFromRight)
				transform.localScale = new Vector3(-1, 1, 1);
			else
				transform.localScale = new Vector3(1, 1, 1);

			poi.Execute(this);
		}
	}

	public void ExecuteNextAction()
	{
		POI nextAction;
		if (actionsToDo.Count > 0)
		{
			nextAction = actionsToDo[actionsToDo.Count - 1];
			actionsToDo.RemoveAt(actionsToDo.Count - 1);
		}
		else
		{
			if (lastAction >= actions.Count)
				lastAction = 0;
			nextAction = actions[lastAction];
			lastAction++;
		}

		ExecuteAction(nextAction);
	}

	public void WalkTo(POI nextPoi, int floor = 0)
	{
		if(IsInPosition(nextPoi.placeOfAction))
		{
			return;
		}

		if (Mathf.Abs(nextPoi.placeOfAction.y - transform.position.y) > LevelManager.Instance.floorHeight)
		{
			if (nextPoi.placeOfAction.y < transform.position.y)
				WalkTo(stairsDown);
			else
				WalkTo(stairsUp);
		}
		else
		{
			animator.SetTrigger(AnimTrigger.Walk.ToString());
			target = nextPoi.placeOfAction;
			target.y = transform.position.y;
			waitForAction = true;
		}

	}

	private bool IsInPosition(Vector3 position)
	{
		if (Mathf.Abs(position.x - transform.position.x) > poiDistanceTolerance)
			return false;
		else if (Mathf.Abs(position.y - transform.position.y) > LevelManager.Instance.floorHeight)
			return false;
		else
			return true;
	}

	public void SetVisible(bool visible)
	{

	}

	public bool CheckHabit(ActionId action)
	{
		if(habits.ContainsKey(action))
		{
			if (habits[action] > 3)
				return true;
			else
				return false;
		}
		else
		{
			habits.Add(action, 0);
			return false;
		}
	}

	public void ReinforceHabit(ActionId action)
	{

		if (habits.ContainsKey(action))
		{
			habits[action]++;
		}
		else
		{
			habits.Add(action, 1);
		}
	}
}