using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Material manager. is used to store a set of materials, in order to 
/// create the different colors for the cells, and to create them dynamically.
/// </summary>
public class MaterialManager : MonoBehaviour {

	public List<Material> materials;
	Dictionary<int, Material> hashed;
	
	void Awake()
	{
		hashed = new Dictionary<int, Material>();
		int cont = 2;
		int index = 0;
		while (cont < 4096)
		{
			hashed.Add( cont, materials[index % materials.Count]);
			index ++;
			cont = cont * 2;
		}
	}
	
	public Material GetMaterial( int tileValue)
	{
		return hashed[tileValue];
	}
}
