using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRenderer : MonoBehaviour
{

	public GameObject star;
	private Star[] stars = new Star[2];
	void Start()
	{
		for (int i = 0; i < stars.Length; i++)
		{
			Star s = Instantiate(star).GetComponent<Star>();
			stars[i] = s;

		}
	}
	void Update()
	{
		Vector3 v1 = new Vector3();
		Vector3 v2 = new Vector3();
		v1.x = stars[0].transform.position.x + -0.1f * Time.deltaTime;
		v2.x = stars[1].transform.position.x + 0.1f * Time.deltaTime;
		stars[0].transform.position = v1;
		stars[1].transform.position = v2;
	}
}
