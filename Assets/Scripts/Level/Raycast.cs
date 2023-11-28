using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public string		previousHit;
	public WordManager	wordManager;
	public WordSpawner	wordSpawner;
	private void Update()
	{
		RaycastHit2D	hit;
		Debug.DrawRay(transform.position, transform.right * 10, Color.red); //initialisation du raycast
		hit = Physics2D.Raycast(transform.position, transform.right, 10);
		if (hit && hit.transform.name != previousHit)
		{
			previousHit = hit.transform.name;
			wordManager.AddLetter();
		}
	}
}
