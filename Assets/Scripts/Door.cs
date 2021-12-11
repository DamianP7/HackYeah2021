using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
	public Sprite openedDoor;
	public Sprite closedDoor;

	SpriteRenderer spriteRenderer;

	[SerializeField]
	int leftRoom, rightRoom;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			spriteRenderer.sprite = openedDoor;

		LevelManager.Instance.playerRoom = collision.transform.position.x > transform.position.x ? leftRoom : rightRoom;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
			spriteRenderer.sprite = closedDoor;
	}
}
