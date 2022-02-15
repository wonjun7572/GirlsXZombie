using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMoveTransition : MonoBehaviour {

	public float transitionTime;
	public Vector2 offset;
	[HideInInspector]
	public Vector2 endPosition;
	[HideInInspector]
	public Vector2 startPosition;
	public bool useScreenPercent;
	public bool useInitialStartPosition;
	public bool backToStartPositionOnSecondCall;	
	
	public GameObject target;
	
	bool initialPos;
	
	void Start()
	{
		if (target == null)
		{
			target = gameObject;
		}
		
		if (useInitialStartPosition)
		{
			startPosition = target.GetComponent<RectTransform>().position;
			
			if (useScreenPercent)
			{
				endPosition = (Vector2)target.GetComponent<RectTransform>().position + (new Vector2( Screen.width * offset.x, Screen.height * offset.y));
			}
			else
			{
				endPosition = (Vector2)target.GetComponent<RectTransform>().position + (Vector2)offset;
			}
			useInitialStartPosition = false;
		}
	}	
	
	public void Switch()
	{		
		if (!initialPos)
		{		
			MoveForward();
		}
		else
		{
			MoveReward();
		}		
	}	
	
	public void MoveForward()
	{		
		iTween.ValueTo( gameObject, iTween.Hash( "from", (Vector2)target.GetComponent<RectTransform>().position, "to", endPosition, "time", transitionTime, "onupdate", "OnTransitionUpdate"));			
		initialPos = true;
	}

	public void MoveReward()
	{
		iTween.ValueTo( gameObject, iTween.Hash( "from", (Vector2)target.GetComponent<RectTransform>().position, "to", startPosition, "time", transitionTime, "onupdate", "OnTransitionUpdate"));				
		initialPos = false;
	}	
	
	public void OnTransitionUpdate( Vector2 position)
	{
		Debug.Log(position);
		RectTransform r = target.GetComponent<RectTransform>();
		r.position = position;		
	}
}
