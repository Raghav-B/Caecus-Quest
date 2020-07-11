using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMouseBehaviour : MonoBehaviour, 
    IPointerClickHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler
{
    private GameController gameController = GameController.Instance;

    private int siblingIndex;
    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Pointer enter");
        RectTransform rT = GetComponent<RectTransform>();
        siblingIndex = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x * 1.4f, rT.sizeDelta.y * 1.4f);
        //rT.anchoredPosition = new Vector2(rT.anchoredPosition.x, transform.localPosition.y * 1.4f);
    }

    public void OnPointerExit(PointerEventData eventData) {
       // Debug.Log("Pointer exit");
        transform.SetSiblingIndex(siblingIndex);
        RectTransform rT = GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(rT.sizeDelta.x / 1.4f, rT.sizeDelta.y / 1.4f);
        //rT.anchoredPosition = new Vector2(rT.anchoredPosition.x, transform.localPosition.y / 1.4f);
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("Pointer Click");
        if (GameController.GameStateMachine.GetCurrentAnimatorStateInfo(0).IsName("Card Pick")) {
            CardDisplay cardDisp = gameObject.GetComponent<CardDisplay>();
            Card card = cardDisp.card;
            GameController.Instance.SetCardIDExecute(card.cardID);
            GameController.GameStateMachine.SetTrigger("CardPicked");
            GetComponent<CardDisplay>().toggleTransparency();
        }
    }
}
