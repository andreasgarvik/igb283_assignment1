using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Star : MonoBehaviour
{
	public Material Material;

	private readonly Vector3[] Vertices = {
		new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0.5f, 0),
		new Vector3(0,-1, 0), new Vector3(0, 0, 0), new Vector3(-0.5f, 0, 0),
		new Vector3(1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, -0.5f, 0),
		new Vector3(0, 1, 0), new Vector3(0, 0, 0), new Vector3(0.5f, 0, 0)
	};

	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();

		Mesh mesh = GetComponent<MeshFilter>().mesh;

		GetComponent<MeshRenderer>().material = Material;

		mesh.Clear();

		mesh.vertices = Vertices;

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
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
						new Color(1.0f, 1.0f, 1.0f, 1.0f),
		};

		mesh.triangles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

	}

	void Update()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;

	}
}

