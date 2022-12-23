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

		Debug.DrawRay(transform.position, transform.right * 10, Color.red);
		hit = Physics2D.Raycast(transform.position, transform.right, 10);

		if (hit && hit.transform.name != previousHit)
		{
			wordManager.AddWord();
			Debug.Log("Le raycast a touché un objet !");
			previousHit = hit.transform.name;
			Debug.Log(hit.transform.name);
		}
	}
}
