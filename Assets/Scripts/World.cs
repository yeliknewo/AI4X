using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	[SerializeField]
	private Dictionary<Point2, Tile> tiles;
	[SerializeField]
	private List<City> cities;
	[SerializeField]
	private List<Civ> civs;

	[SerializeField]
	private Point2 min;
	[SerializeField]
	private Point2 max;
	[SerializeField]
	private int cityCount;
	[SerializeField]
	private int civCount;

	private void Start()
	{
		tiles = new Dictionary<Point2, Tile>();
		cities = new List<City>();
		civs = new List<Civ>();

		GenerateWorld(min, max, cityCount, civCount);
	}

	private void GenerateWorld(Point2 min, Point2 max, int cityCount, int civCount)
	{
		GenerateTerrain(min, max);
		GenerateCities(min, max, cityCount);
		GenerateCivs(min, max, cityCount, civCount);
	}

	private void GenerateTerrain(Point2 min, Point2 max)
	{
		for (int x = min.x; x <= max.x; x++)
		{
			for (int y = min.y; y < max.y; y++)
			{
				Tile tile = new Tile();
				tiles.Add(new Point2(x, y), tile);
			}
		}
	}

	private void GenerateCities(Point2 min, Point2 max, int cityCount)
	{
		for (int currentCityNumber = 0; currentCityNumber < cityCount; currentCityNumber++)
		{
			Point2 loc = new Point2(Random.Range(min.x, max.x + 1), Random.Range(min.y, max.y + 1));
			bool good = true;
			for (int cityIndex = 0; cityIndex < cities.Count; cityIndex++)
			{
				City city = cities[cityIndex];
				if (Point2.Distance(city.GetLoc(), loc) < 2)
				{
					good = false;
					break;
				}
			}
			if(!good)
			{
				currentCityNumber--;
				break;
			}
		}
	}

	private void GenerateCivs(Point2 min, Point2 max, int cityCount, int civCount)
	{

	}

	public Tile SwapTile(Point2 loc, Tile tile)
	{
		Tile oldTile;
		tiles.TryGetValue(loc, out oldTile);
		if (oldTile != null)
		{
			tiles[loc] = tile;
		}
		else
		{
			tiles.Add(loc, tile);
		}
		return oldTile;
	}

	public Tile GetTile(Point2 loc)
	{
		Tile tile;
		tiles.TryGetValue(loc, out tile);
		return tile;
	}
}
