using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TableDropHandler : MonoBehaviour, IDropHandler {


    public void OnDrop(PointerEventData eventData)
    {
        DragableScript.draggedObject.transform.SetParent(transform);
    }
}
