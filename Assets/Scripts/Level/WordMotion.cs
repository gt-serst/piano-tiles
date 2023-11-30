using UnityEngine;
using UnityEngine.UI;

public class WordMotion : MonoBehaviour
{
	public void Update()
	{
		transform.Translate(0f, (Time.deltaTime * (-1.75f)), 0f);
	}
}
