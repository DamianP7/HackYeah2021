using System.Collections.Generic;
using UnityEngine;

// Point Of Interest 
public abstract class POI : MonoBehaviour
{
	public Vector3 placeOfAction;
	public POIType POIType;

	public abstract void Execute(Character character);

#if UNITY_EDITOR
	protected void OnValidate()
	{
		placeOfAction = transform.position;
	}

	//	protected void OnDrawGizmos()
	//	{
	//		Gizmos.color = Color.red;
	//		Gizmos.DrawSphere(transform.position, 1);
	//	}
#endif
}
