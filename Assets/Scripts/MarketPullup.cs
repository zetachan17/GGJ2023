using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarketPullup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool mouse_over = false;
    void Update()
    {
        if (mouse_over)
        {
            //Debug.Log("Mouse Over");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        RectTransform sayDialog = GetComponent<RectTransform>();
        var pos = sayDialog.localPosition;
        sayDialog.localPosition = new Vector3(pos.x, pos.y + 125);
        mouse_over = true;
       // Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RectTransform sayDialog = GetComponent<RectTransform>();
        var pos = sayDialog.localPosition;
        sayDialog.localPosition = new Vector3(pos.x, pos.y - 125);
        mouse_over = false;
        //Debug.Log("Mouse exit");
    }
}
