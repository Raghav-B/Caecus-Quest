using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    private static Animator gameStateMachine;
    
    public GameObject Target;
    public float spellWaitTimer = 2f;
    
    private DeckController deckController;
    private int cardIDExecute;
    private float spellEffectTimer;

    public static GameController Instance { get { return instance; } }
    public static Animator GameStateMachine { get { return gameStateMachine; } }

    public GameObject winScreen;
    private Color origWinScreenColor;
    private Vector3 origWinScreenPos;
    public GameObject lossScreen;
    private Color origLossScreenColor;
    private Vector3 origLossScreenPos;
    public GameObject missedScreen;
    private Color origMissedScreenColor;
    private Vector3 origMissedScreenPos;

    public GameObject[] EnemiesList;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        gameStateMachine = GetComponent<Animator>();

        deckController = GetComponent<DeckController>();

        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;

        origWinScreenColor = winScreen.GetComponent<Image>().color;
        origWinScreenPos = winScreen.transform.position;
        origLossScreenColor = lossScreen.GetComponent<Image>().color;
        origLossScreenPos = lossScreen.transform.position;
        origMissedScreenColor = missedScreen.GetComponent<Image>().color;
        origMissedScreenPos = missedScreen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            showLossAnimation();
        }
    }

    public void SetCardIDExecute(int id) {
        cardIDExecute = id;
    }

    public  void GenerateLevel() {
        int[] constraints = TargettedTileController.Instance.GetGameLimits();
        int maxEnemies = Random.Range(5, 20);
        for (int i = 0; i < maxEnemies; i++) {
            int xPos = Random.Range(constraints[0], constraints[1] + 1);
            int yPos = Random.Range(constraints[2], constraints[3] + 1);

            Object.Instantiate(EnemiesList[0], new Vector3(xPos, 0.5f, yPos), Quaternion.identity);
        }

        gameStateMachine.SetTrigger("CardPicked");
    }

    public void ApplyEffects() {
        List<CardEffect> effectsList = deckController.GetCardEffects(cardIDExecute);
        foreach(CardEffect effect in effectsList) {
            //Debug.Log("Radius:" + effect.radius);
            Collider[] colliders = Physics.OverlapSphere(Target.transform.position, effect.radius);
            //Debug.Log("colliders:" + colliders.Length);
            effect.ExecuteEffect(colliders);

            effect.CreateSpellEffect();
        }

        spellEffectTimer = Time.time;
    }

    public bool PollSpellEffect() {
        if (Time.time < spellEffectTimer + spellWaitTimer) return false;
        spellEffectTimer = Time.time;
        return true;
    }

    public void RetargetMarker() {
        Target.GetComponent<TargettedTileController>().changeRandomPos();
    }

    public void showWinAnimation() {
        StartCoroutine(PopUpAnimation(winScreen, 1.5f));
    }
    public void showLossAnimation() {
        StartCoroutine(PopUpAnimation(lossScreen, 1.5f));
    }
    public void showMissAnimation() {
        StartCoroutine(PopUpAnimation(missedScreen, 0.5f));
    }

    IEnumerator PopUpAnimation(GameObject objectToPop, float hoverSeconds) {
        objectToPop.SetActive(true);
        objectToPop.transform.localScale = new Vector3(0, 0, 0);

        if (objectToPop.Equals(winScreen)) {
            objectToPop.GetComponent<Image>().color = origWinScreenColor;
            objectToPop.transform.position = origWinScreenPos;
        } else if (objectToPop.Equals(lossScreen)) {
            objectToPop.GetComponent<Image>().color = origLossScreenColor;
            objectToPop.transform.position = origLossScreenPos;
        } else if (objectToPop.Equals(missedScreen)) {
            objectToPop.GetComponent<Image>().color = origMissedScreenColor;
            objectToPop.transform.position = origMissedScreenPos;
        }

        while (objectToPop.transform.localScale.x < 1f &&
                    objectToPop.transform.localScale.y < 1f &&
                    objectToPop.transform.localScale.z < 1f) {
            objectToPop.transform.localScale = new Vector3(
                    objectToPop.transform.localScale.x + 0.03f,
                    objectToPop.transform.localScale.y + 0.03f,
                    objectToPop.transform.localScale.z + 0.03f);
            yield return new WaitForSeconds(0.005f);
        }

        float timeRemaining = hoverSeconds;
        while (timeRemaining > 0) {
            objectToPop.transform.position = new Vector3(
                    objectToPop.transform.position.x,
                    objectToPop.transform.position.y + 1,
                    objectToPop.transform.position.z);
            timeRemaining -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(FadeAnimation(objectToPop));
        SceneManager.LoadScene(0);
    }

    IEnumerator FadeAnimation(GameObject objectToFade) {   
        while (objectToFade.GetComponent<Image>().color.a > 0) {
            objectToFade.GetComponent<Image>().color = new Color(
                    objectToFade.GetComponent<Image>().color.r,
                    objectToFade.GetComponent<Image>().color.g,
                    objectToFade.GetComponent<Image>().color.b,
                    objectToFade.GetComponent<Image>().color.a - 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
