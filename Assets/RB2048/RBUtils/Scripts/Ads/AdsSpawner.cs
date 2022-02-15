using UnityEngine;
using System.Collections;

public class AdsSpawner : MonoBehaviour {

	public bool spawnOnStartBanner;
	public bool spawnOnStartIntersticial;
	public int intersticialPossibility;

	public GameObject bannerObject;
	public GameObject intersticialObject;

	void Start()
	{
		if (spawnOnStartBanner)
		{
			SpawnBanner();
		}

		if (spawnOnStartIntersticial)
		{
			SpawnIntersticial();
		}
	}

	public void SpawnBanner()
	{
		GameObject.Instantiate( bannerObject );

	}

	public void SpawnIntersticial()
	{
		int rand = Random.Range(0, intersticialPossibility);

		if (rand == 1)
		{
			GameObject.Instantiate( intersticialObject );
		}
	}

	public void SpawnIntersticialNoRandom()
	{
		GameObject.Instantiate( intersticialObject );
	}
}
