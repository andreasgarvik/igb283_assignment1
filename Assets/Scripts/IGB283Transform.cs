using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IGB283Transform 
{
	public static Matrix3x3 Rotate(float angle)
	{
		Matrix3x3 matrix = new Matrix3x3();
		matrix.SetRow(0, new Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0.0f));
		matrix.SetRow(1, new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0.0f));
		matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}
	public static Matrix3x3 Translate(float dx, float dy)
	{
		Matrix3x3 matrix = new Matrix3x3();
		matrix.SetRow(0, new Vector3(1.0f, 0.0f, dx));
		matrix.SetRow(1, new Vector3(0.0f, 1.0f, dy));
		matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}
	public static Matrix3x3 Scale(float sx, float sy)
	{
		Matrix3x3 matrix = new Matrix3x3();
		matrix.SetRow(0, new Vector3(sx, 0.0f, 0.0f));
		matrix.SetRow(1, new Vector3(0.0f, sy, 0.0f));
		matrix.SetRow(2, new Vector3(0.0f, 0.0f, 1.0f));

		return matrix;
	}
}
