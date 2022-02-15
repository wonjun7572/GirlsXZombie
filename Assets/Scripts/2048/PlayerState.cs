using UnityEngine;
using System.Collections;

/// <summary>
/// Player state.
/// Implemented as a singleton in order to be able to access it from anywhere.
/// </summary>
public class PlayerState : MonoBehaviour {

	/// <summary>
	/// The instance private.
	/// </summary>
	private static PlayerState instance;

	/// <summary>
	/// The data, this value will store the data for the player we can modify
	/// this value and then we can save or load it.
	/// </summary>
	public PlayerData data;

	private PlayerState()
	{

	}

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static PlayerState Instance
	{
		get 
		{
			if (instance == null)
			{
				GameObject instanceObject = new GameObject("PlayerState");
				instance = instanceObject.AddComponent<PlayerState>();
				/// we load the data once we create the instance.
				instance.LoadData();

				if (instance.data == null)
				{
					instance.data = new PlayerData();
				}			
			}

			return instance;
		}

	}

	/// <summary>
	/// Part of the Unity3D singleton implementation in order to have a game object.
	/// this makes sure we don't duplicate game objects using it.
	/// </summary>
	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(this);
		}

	}

	/// <summary>
	/// Loads the data.
	/// </summary>
	public void LoadData()
	{
		data = GameSerializer.Instance.GetElement<PlayerData>("playerData");
	}

	/// <summary>
	/// Saves the data.
	/// </summary>
	public void SaveData()
	{
		GameSerializer.Instance.SaveElement<PlayerData>(data, "playerData");
	}
	
	public void AddScore( int scoreIndex, float amount)
	{
		data.AddScore(scoreIndex, amount);
		SaveData();
	}
	
}
