using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public string		previousHit;
	public	static int	previousTilesNum = 0;
	public	static int	tilesNum = 1;
	public WordManager wordManager;
	private void Update()
	{
		RaycastHit2D	hit;
		Debug.DrawRay(transform.position, transform.right * 10, Color.red); //initialisation du raycast
		hit = Physics2D.Raycast(transform.position, transform.right, 10);
		if (hit && previousHit != hit.transform.name && previousTilesNum < tilesNum)
		{
			previousTilesNum = tilesNum;
			tilesNum++;
/*
			Debug.Log("previousHit: " + previousHit);
			Debug.Log("hit.transform.name: " + hit.transform.name);
			Debug.Log("previousTilesNum: " + previousTilesNum);
			Debug.Log("tilesNum: " + tilesNum);
*/
			previousHit = hit.transform.name;
			wordManager.AddWord();
			//RaycastHitsSmthg();
		}
	}
/*
	private void RaycastHitsSmthg()
	{
		wordManager.AddWord();
	}
*/
}
