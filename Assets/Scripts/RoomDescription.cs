using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class RoomDescription : MonoBehaviour
{
    private DialogueManager myDM;
    public bool lastInteractFound = false;
    private void Start() {
        myDM = FindAnyObjectByType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            myDM.showRoom(gameObject.name);
        }
        if (lastInteractFound){
            string dialogue = FindObjectOfType<AllDialogues>().lastInteraction;
            FindObjectOfType<DialogueManager>().dogSpeak(dialogue);
            lastInteractFound = false;
        }
    }
}
