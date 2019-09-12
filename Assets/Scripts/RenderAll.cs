using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderAll : MonoBehaviour
{
	public GameObject star;
	public GameObject square;

	private Star[] stars = new Star[2];
	private Square[] squares = new Square[4];
	private float minX = -4f;
	private float maxX = 4f;
	private float minY = -3.25f;
	private float maxY = 3.25f;
	void Start()
	{
		//Making the stars and setting speed om movements
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

		//Making and setting position of the squares
		Square sq1 = Instantiate(square).GetComponent<Square>();
		sq1.x = maxX + 1;
		sq1.y = maxY + 1;
		squares[0] = sq1;

		Square sq2 = Instantiate(square).GetComponent<Square>();
		sq2.x = maxX + 1;
		sq2.y = minY - 1;
		squares[1] = sq2;

		Square sq3 = Instantiate(square).GetComponent<Square>();
		sq3.x = minX - 1;
		sq3.y = maxY + 1;
		squares[2] = sq3;

		Square sq4 = Instantiate(square).GetComponent<Square>();
		sq4.x = minX - 1;
		sq4.y = minY - 1;
		squares[3] = sq4;
	}

	void Update()
	{
		for (int i = 0; i < stars.Length; i++)
		{
			float newMinX = Mathf.Min(squares[0].x, squares[1].x, squares[2].x, squares[3].x);
			float newMaxX = Mathf.Max(squares[0].x, squares[1].x, squares[2].x, squares[3].x);
			float newMinY = Mathf.Min(squares[0].y, squares[1].y, squares[2].y, squares[3].y);
			float newMaxY = Mathf.Max(squares[0].y, squares[1].y, squares[2].y, squares[3].y);

			stars[i].minX = newMinX;
			stars[i].maxX = newMaxX;
			stars[i].minY = newMinY;
			stars[i].maxY = newMaxY;
		}
	}
}
