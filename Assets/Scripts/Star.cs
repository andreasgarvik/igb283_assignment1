using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
	public Material material;
	public float angle;
	public float speed;
	public bool movingRight;
	public bool movingUp;


	private Mesh mesh;
	private float minX = -6.25f;
	private float maxX = 6.25f;
	private float minY = -4.75f;
	private float maxY = 4.75f;
	private float bigger = 1.005f;
	private float smaller = 0.995f;

	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();

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
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
		};

		mesh.triangles = new int[] { 0, 1, 2, 0, 3, 4, 0, 5, 6, 0, 7, 8 };

	}
	void Update()
	{

		Vector3[] vertices = mesh.vertices;
		Matrix3x3 translate;
		Matrix3x3 scale;
		Matrix3x3 rotate = IGB283Transform.Rotate(angle * Time.deltaTime);
		//mesh.recalcutatebound()
		//Venctor 3 m = mesh.bound.right

		if (movingRight)
		{
			if (movingUp)
			{
				translate = IGB283Transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime);
				movingUp = vertices[7].y <= maxY;
			}
			else
			{
				translate = IGB283Transform.Translate(speed * Time.deltaTime, -speed * Time.deltaTime);
				movingUp = vertices[3].y <= minY;
			}
			movingRight = vertices[5].x <= maxX;
			scale = IGB283Transform.Scale(bigger, bigger);
		}
		else
		{
			if (movingUp)
			{
				translate = IGB283Transform.Translate(-speed * Time.deltaTime, speed * Time.deltaTime);
				movingUp = vertices[7].y <= maxY;
			}
			else
			{
				translate = IGB283Transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime);
				movingUp = vertices[3].y <= minY;
			}
			movingRight = vertices[1].x <= minX;
			scale = IGB283Transform.Scale(smaller, smaller);
		}

		for (int i = 0; i < vertices.Length; i++)
		{
			// M = TRS
			//
			// M = T-1RT
			vertices[i] = scale.MultiplyPoint(vertices[i]);
			vertices[i] = rotate.MultiplyPoint(vertices[i]);
			vertices[i] = translate.MultiplyPoint(vertices[i]);
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();



	}
}

