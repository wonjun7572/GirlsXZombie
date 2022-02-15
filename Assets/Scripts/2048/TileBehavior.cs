using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Tile behavior. is used to give some kind of behavior to the different tiles in the board.
/// like scaling up & down, move smoothly, etc.
/// </summary>
/// [
///
[RequireComponent(typeof(TileModels))]
public class TileBehavior : MonoBehaviour 
{

	public static TileBehavior instance;

	public int tileAmount;
	public int tileID;
	
	public int currentCol;
	public int currentRow;

    GameObject Model;

	//Text text;
	
	public float moveSpeed;
	
	public bool hasMerged;

	public bool mergePossible = true;
	
	public Vector3 startScale;

    public void Awake()
    {
		instance = this;
    }
    public void Start()
	{
		startScale = transform.localScale;
		//text = GetComponentInChildren<Text>();
		//text.text = "" + tileAmount;// + " : " + tileID;	
									//GetComponentInChildren<Renderer>().material = GameObject.Find("Materials").GetComponent<MaterialManager>().GetMaterial( tileAmount );
		iTween.PunchScale(gameObject, iTween.Hash("x", 0.6f, "z", 0.6f, "y", 0.5f, "oncomplete", "SetFinalSize"));
        SpawnModel();
	}
	
	public void MoveTo( float x, float z)
	{
		//Debug.Log("Move To: " + x + ", " + z);
		iTween.MoveTo(gameObject, iTween.Hash("x", x , "z", z, "time", 0.15f, "easetype", "linear" ));		
	}
	
	public void UpgradeTile()
	{
		if (mergePossible == true)
        {
			//Debug.Log("합성 가능 상태 입니다");
			tileAmount *= 2;
			iTween.PunchScale(gameObject, iTween.Hash("x", 0.6f, "z", 0.6f, "y", 0.5f, "oncomplete", "SetFinalSize"));
			hasMerged = true;
			//text.text = tileAmount + "";// + " : " + tileID;	
										//GetComponentInChildren<Renderer>().material = GameObject.Find("Materials").GetComponent<MaterialManager>().GetMaterial( tileAmount );

			SpawnModel(); // 다른 이미지? 머터리얼? 불러주는거
		}
        else
        {
			//Debug.Log("합성 불가상태 입니다");
        }
		
	}
	
    void SpawnModel()
    {
        GameObject.DestroyImmediate(Model);
        Model = GameObject.Instantiate(GetComponent<TileModels>().GetModel(tileAmount));
        Model.transform.SetParent(gameObject.transform);
        Model.transform.localPosition = Vector3.zero;
    }

	public void SetFinalSize()
	{
		transform.localScale = startScale;
	}
	
}
