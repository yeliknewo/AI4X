using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2 : MonoBehaviour
{
	[SerializeField]
	private short _x;
	[SerializeField]
	private short _y;

	public int x
	{
		get
		{
			return _x;
		}
		private set
		{
			_x = (short)value;
		}
	}

	public int y
	{
		get
		{
			return _y;
		}
		private set
		{
			_y = (short)value;
		}
	}

	public void SetX(int x)
	{
		this.x = (short)x;
	}

	public void SetY(int y)
	{
		this.y = (short)y;
	}

	public void Set(int x, int y)
	{
		SetX(x);
		SetY(y);
	}

	public Point2(int x, int y)
	{
		Set(x, y);
	}

	public Vector2 ToVector2()
	{
		return new Vector2(x, y);
	}

	public Point2 FromVector2(Vector2 vec)
	{
		return new Point2(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y));
	}

	public static float Distance(Point2 a, Point2 b)
	{
		return Vector2.Distance(a.ToVector2(), b.ToVector2());
	}

	public static Point2 operator *(Point2 a, int b)
	{
		return new Point2(a.x * b, a.y * b);
	}

	public static Point2 operator /(Point2 a, int b)
	{
		return new Point2((int)(a.x / (float)b), (int)(a.y / (float)b));
	}

	public static Point2 operator !(Point2 a)
	{
		return new Point2(-a.x, -a.y);
	}

	public static Point2 operator +(Point2 a, int b)
	{
		return new Point2(a.x + b, a.y + b);
	}

	public static Point2 operator -(Point2 a, int b)
	{
		return new Point2(a.x - b, a.y - b);
	}

	public static Point2 operator +(Point2 a, Point2 b)
	{
		return new Point2(a.x + b.x, a.y + b.y);
	}

	public static Point2 operator -(Point2 a, Point2 b)
	{
		return new Point2(a.x - b.x, a.y - b.y);
	}

	public static bool operator ==(Point2 a, Point2 b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Point2 a, Point2 b)
	{
		return !(a == b);
	}

	public override int GetHashCode()
	{
		return x << 16 + y;
	}

	public override bool Equals(object obj)
	{
		Point2 other = (Point2)obj;
		if (other == null)
		{
			return false;
		}

		return other.x == x && other.y == y;
	}
}
