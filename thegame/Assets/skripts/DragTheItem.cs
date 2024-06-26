using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/*
 This skript is what is labelled as InventoryItem in the tutorial.
 */


public class DragTheItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;

    [HideInInspector] public int count = 1;

    [HideInInspector] public Transform parentAfterDrag;

    public void InitaliseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }


    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}