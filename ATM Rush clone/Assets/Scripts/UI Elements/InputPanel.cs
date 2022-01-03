using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [System.NonSerialized] public static InputPanel instance;

    #region Variables
    [System.NonSerialized] public static bool pointerMoving = false;
    float currentX, currentY;
    Vector2 _lastPosition = Vector2.zero;
    #endregion

    private void Awake()
	{
        instance = this;
	}
    
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        currentX = 0;
        pointerMoving = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _lastPosition;
        currentX = direction.x / Screen.width;
        currentY = direction.y / Screen.height;
        _lastPosition = eventData.position;
        if (LevelManager.gameState == GameState.Normal)
        {
            PlayerMovement.instance.MovementFunc(currentX, currentY);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        pointerMoving = true;
        _lastPosition = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        pointerMoving = false;
        currentX = 0;
        _lastPosition = Vector2.zero;
    }
	private void OnMouseDrag()
	{
        Debug.Log("Boktan olan drag");
	}
}
