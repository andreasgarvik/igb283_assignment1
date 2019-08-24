using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRenderer : MonoBehaviour
{
	public GameObject star;
	private Star[] stars = new Star[2];
	void Start()
	{
		Star s1 = Instantiate(star).GetComponent<Star>();
		s1.movingRight = true;
		s1.movingUp = true;
		s1.speed = 4;
		stars[0] = s1;

		Star s2 = Instantiate(star).GetComponent<Star>();
		s2.movingRight = false;
		s2.movingUp = false;
		s2.speed = 6;
		stars[0] = s2;
	}
}
