﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	public Material material;
	public float rotationSpeed;
	public float translationSpeedX;
	public float translationSpeedY;
	public float scalingSpeed;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private float angle;
	private float positionX;
	private float positionY;
	private Mesh mesh;
	private float size = 1;
	private bool bigger = true;
	private bool smaller = false;
	private float minSize = 0.600f;
	private float maxSize = 1.400f;
	private float r = 1.0f;
	private float g = 1.0f;
	private float b = 1.0f;

	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();

		resetMesh(r, g, b);
	}
	void Update()
	{
		positionX = positionX >= maxX ? maxX : positionX;
		positionY = positionY >= maxY ? maxY : positionY;

		positionX = positionX <= minX ? minX : positionX;
		positionY = positionY <= minY ? minY : positionY;

		r = positionX > 0 ? 1.0f : 0;
		g = positionY > 0 ? 1.0f : 0;
		b = positionX < 0 ? 1.0f : 0;

		resetMesh(r, g, b);

		translationSpeedX = positionX < maxX && positionX > minX ? translationSpeedX : -translationSpeedX;
		translationSpeedY = positionY < maxY && positionY > minY ? translationSpeedY : -translationSpeedY;

		size = size >= maxSize ? maxSize : size;
		size = size <= minSize ? minSize : size;

		bigger = size < maxSize && !smaller;
		smaller = size > minSize && !bigger;

		size = bigger && !smaller ? size + scalingSpeed : size - scalingSpeed;

		angle += Time.deltaTime * rotationSpeed;
		positionX += Time.deltaTime * translationSpeedX;
		positionY += Time.deltaTime * translationSpeedY;
		size += Time.deltaTime * scalingSpeed;

		Vector3[] vertices = mesh.vertices;
		Matrix3x3 scale = IGB283Transform.Scale(size, size);
		Matrix3x3 rotate = IGB283Transform.Rotate(angle);
		Matrix3x3 translate = IGB283Transform.Translate(positionX, positionY);

		//Matrix3x3 transformation = TRS 
		Matrix3x3 transformation = translate * rotate * scale;

		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = transformation.MultiplyPoint(vertices[i]);
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
	}

	void resetMesh(float r, float g, float b)
	{
		mesh = GetComponent<MeshFilter>().mesh;

		GetComponent<MeshRenderer>().material = material;

		mesh.Clear();

		mesh.vertices = new Vector3[]
		{
							new Vector3(0, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0.5f, 0),
							new Vector3(0,-1, 0), new Vector3(-0.5f, 0, 0), new Vector3(1, 0, 0),
							new Vector3(0, -0.5f, 0), new Vector3(0, 1, 0), new Vector3(0.5f, 0, 0)
		};

		mesh.colors = new Color[]
		{
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
							new Color(r, g, b, 1.0f),
		};

		mesh.triangles = new int[] { 0, 1, 2, 0, 3, 4, 0, 5, 6, 0, 7, 8 };
	}
}



