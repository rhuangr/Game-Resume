using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    [Header("Text")]
    [SerializeField] GameObject textBox;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Color32 textColor;
    // int wordCount;
    [SerializeField] AllDialogues dialogueBank;
    [SerializeField] float delayOnCharacter;

    [SerializeField] float delayOnPeriod;

    [Header("Dog")]
    [SerializeField] GameObject MC;

    
    [SerializeField] int jumpHeight;

    [SerializeField] float delayDog;

    [Header("DialogueBox")]

    [SerializeField] GameObject dialogueBox;

    private RectTransform dialogueBoxTransform;

    [Header("DescriptionBox")]

    [SerializeField] GameObject descriptionBox;

    // private RectTransform descriptionBoxTransform;

    [SerializeField] float appearSpeed;

    [SerializeField] float changeRate;

    private String currentRoom;

    private TextMeshProUGUI roomText;

    private Coroutine currentCoroutineText;
    private Coroutine currentCoroutineDog;

    private Vector3 currentPosition;

    bool isWriting;
    string currentText;
    void Start()
    {
        dialogueBoxTransform = dialogueBox.GetComponent<RectTransform>();
        dialogueBoxTransform.anchoredPosition = new Vector2(0, -400);

        roomText = descriptionBox.GetComponentInChildren<TextMeshProUGUI>();
        currentRoom = "Living Room";
        roomText.text = currentRoom;

        currentPosition = MC.transform.localPosition;

        isWriting = false;
        currentText = "";
        dialogueBank = FindObjectOfType<AllDialogues>();
        dogSpeak(dialogueBank.entrance);
    }

    public void showRoom(String room){
        if (currentRoom == room){
            return;
        }
        descriptionBox.GetComponentInChildren<TextMeshProUGUI>().text = room;
        currentRoom = room;
    }
   
    public void dogSpeak(string text){
        
        if (currentCoroutineText != null){
            StopCoroutine(currentCoroutineText);
        }
        StartCoroutine(adjustDialogueBox(dialogueBoxTransform, 40, appearSpeed));
        currentText = "";
        textBox.SetActive(true);
        currentCoroutineText = StartCoroutine(textLoop(text));
        currentCoroutineDog = StartCoroutine(animateDog());
       
    }

    public void closeDialogue(){
        if (!isWriting){
            StartCoroutine(adjustDialogueBox(dialogueBoxTransform, -400, -appearSpeed));
        }
    }

    IEnumerator textLoop(string s){
        isWriting = true;
        bool inTag = false;
        text.color = textColor;
       
        foreach (char c in s){
            currentText += c;
            if (c == '<'){
                inTag = true;
            }
            if (c == '>'){
                inTag = false;
            }
            text.text = currentText;

            if (!inTag){
                yield return new WaitForSeconds(delayOnCharacter);
            }
            if (c == '.'){
                currentText = "";
                yield return new WaitForSeconds(delayOnPeriod);
            }
        }
        isWriting = false;
    }

    IEnumerator animateDog(){
        if (currentCoroutineDog != null){
            StopCoroutine(currentCoroutineDog);
        }
        
        MC.transform.localPosition = currentPosition;
        while(isWriting){

            for (int i = 0; i < jumpHeight; i ++){
                
                MC.transform.position += new Vector3(0,0.2f,0);
                yield return new WaitForSeconds(delayDog);
            }

            for (int i = 0; i < jumpHeight; i ++){
               
                MC.transform.position += new Vector3(0,-0.2f,0);
                yield return new WaitForSeconds(delayDog);
            }
        }
    }

    IEnumerator adjustDialogueBox(RectTransform boxTransform, int stopInt, float rateDirection){
        while ( boxTransform.anchoredPosition.y != stopInt){
            boxTransform.anchoredPosition += new Vector2(0, rateDirection);
            yield return new WaitForSeconds(changeRate);
        }
    }

}
