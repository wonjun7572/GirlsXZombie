using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UIScrollWorldFromUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{

	public float currentScroll;

	public float snapDistance;
	public float maxX;
	public Vector3 offset;
	
	public float scrollIntensity = 0.001f;
	
	public GameObject targetContent;
	
	// Use this for initialization
	void Start () {
				
	}
	
	
	// Update is called once per frame
	void Update () {	
		currentScroll = Mathf.Min(0, currentScroll);
		currentScroll = Mathf.Max(-maxX / snapDistance, currentScroll);
		
		float targetSnap = (int)(maxX * currentScroll / snapDistance) * snapDistance;		
			
		targetContent.transform.position = Vector3.Lerp(targetContent.transform.position , (transform.right * targetSnap) + offset, 6f * Time.deltaTime);	
		
	}
	
	public void OnValueChanged(Vector2 value)
	{
		currentScroll = -value.x;			
	}

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		currentScroll += eventData.delta.x * scrollIntensity;
	}

	#endregion

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		
		GameObject.Find("GUIManager").SendMessage("HideLevelDialog", gameObject);
		
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
	}

	#endregion
}
