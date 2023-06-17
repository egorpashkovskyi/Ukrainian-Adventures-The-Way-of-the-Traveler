using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQest : MonoBehaviour
{
	[SerializeField] GameObject Dialog;
	[SerializeField] private GameObject BG;
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Dialog.SetActive(true);
			BG.SetActive(true);
		}
	}
}
