using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public string	previousHit;
	public WordManager wordManager;


	private void Update()
	{
		RaycastHit2D	hit;
		Debug.DrawRay(transform.position, transform.right * 10, Color.red); //initialisation du raycast
		hit = Physics2D.Raycast(transform.position, transform.right, 10);
		if (hit && previousHit != hit.transform.name)
		{
			wordManager.AddWord();
			previousHit = hit.transform.name;
		}
	}
}
