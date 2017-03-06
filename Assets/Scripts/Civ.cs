using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civ : MonoBehaviour
{
	[SerializeField]
	private List<City> cities;

	public Civ()
	{
		cities = new List<City>();
	}

	public List<City> GetCities()
	{
		return cities;
	}
}
