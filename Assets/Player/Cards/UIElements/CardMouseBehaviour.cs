using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMouseBehaviour : MonoBehaviour, 
    IPointerClickHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler
{
    public GameController gameController;

    private int siblingIndex;
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer enter");
        RectTransform rT = GetComponent<RectTransform>();
        siblingIndex = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x * 1.4f, rT.sizeDelta.y * 1.4f);
        //rT.anchoredPosition = new Vector2(rT.anchoredPosition.x, transform.localPosition.y * 1.4f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Pointer exit");
        transform.SetSiblingIndex(siblingIndex);
        RectTransform rT = GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x / 1.4f, rT.sizeDelta.y / 1.4f);
        //rT.anchoredPosition = new Vector2(rT.anchoredPosition.x, transform.localPosition.y / 1.4f);
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Pointer Click");

        CardDisplay cardDisp = gameObject.GetComponent<CardDisplay>();
        Card card = cardDisp.card;
        int cardID = card.cardID;

        gameController.ApplyEffects(cardID);
    }
}
