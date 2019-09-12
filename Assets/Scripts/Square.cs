using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
	public Material material;
	public float x;
	public float y;
	private bool moving = false;
	private bool shouldMove = false;
	private Mesh mesh;
	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshCollider>();
		renderSquare();
	}

	public void renderSquare()
	{
		resetMesh();

		Vector3[] vertices = mesh.vertices;
		Matrix3x3 translate = IGB283Transform.Translate(x, y);

		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = translate.MultiplyPoint(vertices[i]);
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
	}

	void Update()
	{
		MouseClickAction();
		Move();
	}
	void Move()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (moving)
		{
			resetMesh();

			Vector3[] vertices = mesh.vertices;
			Matrix3x3 translate = IGB283Transform.Translate(mousePosition.x, mousePosition.y);
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = translate.MultiplyPoint(vertices[i]);
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds();
		}
	}
	void MouseClickAction()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		shouldMove = (x - 0.5f < mousePosition.x && mousePosition.x < x + 0.5f)
		&& (y - 0.5f < mousePosition.y && mousePosition.y < y + 0.5f);

		if (Input.GetMouseButtonDown(0))
		{
			if (shouldMove)
			{
				moving = true;
			}

		}
		else if (Input.GetMouseButtonUp(0))
		{
			moving = false;
			x = mousePosition.x;
			y = mousePosition.y;
		}
	}

	void resetMesh()
	{
		mesh = GetComponent<MeshFilter>().mesh;

		GetComponent<MeshRenderer>().material = material;

		mesh.Clear();

		mesh.vertices = new Vector3[]
		{
						new Vector3(-0.5f, -0.5f, 0),
						new Vector3(-0.5f, 0.5f, 0),
						new Vector3(0.5f, 0.5f, 0),
						new Vector3(0.5f, -0.5f, 0)
		};

		mesh.colors = new Color[]
		{
							new Color(1.0f, 0, 0, 1.0f),
							new Color(1.0f, 0, 0, 1.0f),
							new Color(1.0f, 0, 0, 1.0f),
							new Color(1.0f, 0, 0, 1.0f),
		};

		mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
	}
}