using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
	public Material material;
	public float x;
	public float y;
	public bool moving = false;
	public bool shouldMove = false;

	private Mesh mesh;
	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshCollider>();

		mesh = GetComponent<MeshFilter>().mesh;

		GetComponent<MeshRenderer>().material = material;
		renderSquare();
	}

	public void renderSquare()
	{
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

		Vector3[] vertices = mesh.vertices;
		Matrix3x3 translate = IGB283Transform.Translate(x, y);

		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = translate.MultiplyPoint(vertices[i]);
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
	}
}