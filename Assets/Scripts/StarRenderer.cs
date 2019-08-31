using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRenderer : MonoBehaviour
{
	public GameObject star;
	public GameObject square;

	private Star[] stars = new Star[2];
	private Square[] squares = new Square[4];
	private float minX = -8f;
	private float maxX = 8f;
	private float minY = -3.75f;
	private float maxY = 3.75f;
	void Start()
	{
		Star s1 = Instantiate(star).GetComponent<Star>();
		s1.translationSpeedX = 9;
		s1.translationSpeedY = 7;
		s1.rotationSpeed = 11f;
		s1.scalingSpeed = 0.007f;
		s1.minX = minX;
		s1.maxX = maxX;
		s1.minY = minY;
		s1.maxY = maxY;
		stars[0] = s1;

		Star s2 = Instantiate(star).GetComponent<Star>();
		s2.translationSpeedX = 7;
		s2.translationSpeedY = 9;
		s2.rotationSpeed = 7f;
		s2.scalingSpeed = 0.015f;
		s2.minX = minX;
		s2.maxX = maxX;
		s2.minY = minY;
		s2.maxY = maxY;
		stars[1] = s2;

		Square sq1 = Instantiate(square).GetComponent<Square>();
	}

	void Update()
	{

	}
}
