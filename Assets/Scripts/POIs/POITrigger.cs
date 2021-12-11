using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class POITrigger : POI
{
	public bool OnAndOff = false;

	public GameObject lightMask;

	public override void Execute(Character character)
	{
		bool active = lightMask.activeSelf;

		if (!active || OnAndOff)
			lightMask.SetActive(!active);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Execute(null);
	}
}