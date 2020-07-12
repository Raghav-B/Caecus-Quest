using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMouseBehaviour : MonoBehaviour, 
    IPointerClickHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler
{
    public float width = 150f;
    public float height = 210f;

    private GameController gameController = GameController.Instance;

    private int siblingIndex;
    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Pointer enter");
        if (GameController.GameStateMachine.GetCurrentAnimatorStateInfo(0).IsName("Card Pick")) {
            RectTransform rT = GetComponent<RectTransform>();
            siblingIndex = transform.GetSiblingIndex();
            transform.SetAsLastSibling();
            rT.sizeDelta = new Vector2(rT.sizeDelta.x * 1.4f, rT.sizeDelta.y * 1.4f);

            CardDisplay cardDisp = gameObject.GetComponent<CardDisplay>();
            Card card = cardDisp.card;
            float tileRadius = DeckController.Instance.GetCardEffects(card.cardID)[0].radius;
            TargettedTileController.Instance.scaleTile(tileRadius); 
        }

    }

    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log("Pointer exit");
        if (GameController.GameStateMachine.GetCurrentAnimatorStateInfo(0).IsName("Card Pick")) {
            resetSize();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("Pointer Click");
        if (GameController.GameStateMachine.GetCurrentAnimatorStateInfo(0).IsName("Card Pick")) {
            CardDisplay cardDisp = gameObject.GetComponent<CardDisplay>();
            Card card = cardDisp.card;
            GameController.Instance.SetCardIDExecute(card.cardID);
            GameController.GameStateMachine.SetTrigger("CardPicked");
            //resetSize();
            GetComponent<CardDisplay>().toggleTransparency();
        }
    }

    public void resetSize() {
        transform.SetSiblingIndex(siblingIndex);
        RectTransform rT = GetComponent<RectTransform>();
        rT.sizeDelta = new Vector2(width, height);
    }
}
