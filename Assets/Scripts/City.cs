using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City: MonoBehaviour
{
	[SerializeField]
	private Point2 loc;

	public City(Point2 loc)
	{
		this.loc = loc;
	}

	public Point2 GetLoc()
	{
		return loc;
	}
}
