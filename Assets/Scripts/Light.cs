using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
	[SerializeField] GameObject lightEffect;

	private void Awake()
	{
		TurnOff();
	}

	public void TurnOn()
	{
		lightEffect.SetActive(true);
	}

	public void TurnOff()
	{
		lightEffect.SetActive(false);
	}

	public void Switch(bool active)
	{
		lightEffect.SetActive(active);
	}
}
