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
		s1.translationSpeedX = 5;
		s1.translationSpeedY = 7;
		s1.rotationSpeed = 10f;
		s1.scalingSpeed = 0.010f;
		stars[0] = s1;

		Star s2 = Instantiate(star).GetComponent<Star>();
		s2.translationSpeedX = 8;
		s2.translationSpeedY = 10;
		s2.rotationSpeed = 7f;
		s2.scalingSpeed = 0.010f;
		stars[1] = s2;
	}
}
