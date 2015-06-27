using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragableScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Camera maincam;
	public static GameObject draggedObject;
	Transform TheCanvas;
	Transform OldParent;
	Vector2 OldPosition;


	public void Start(){
		maincam = Camera.main;
		TheCanvas = GameObject.Find ("Canvas").transform;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		draggedObject = gameObject;
		OldPosition = transform.position;
		OldParent = transform.parent;
		transform.SetParent (TheCanvas);
		transform.SetAsLastSibling();
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		Debug.Log("begin drag");
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = new Vector2(maincam.ScreenToWorldPoint(Input.mousePosition).x,maincam.ScreenToWorldPoint(Input.mousePosition).y);
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == TheCanvas) {
			transform.SetParent(OldParent);
			transform.position = OldPosition;
		}
		draggedObject = null;
		Debug.Log("end drag");
	}
}

