using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class POITrigger : POI
{
	public bool OnAndOff = false;

	public GameObject shadowMask;
	public Light[] lights;

	public int roomId;

	SpriteRenderer spriteRenderer;
	bool isGhost = false;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (!spriteRenderer.enabled)
			isGhost = true;
	}

	public override void Execute(Character character)
	{
		bool active = shadowMask.activeSelf;

		if (active || OnAndOff)
			SetLight(active);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Execute(null);
	}

	private void OnMouseDown()
	{
		if (!shadowMask.activeSelf && roomId != LevelManager.Instance.playerRoom && !isGhost)
			SetLight(false);
	}

	void SetLight(bool active)
	{
		foreach (Light light in lights)
		{
			light.Switch(active);
		}

		shadowMask.SetActive(!active);
	}
}