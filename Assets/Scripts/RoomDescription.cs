using UnityEngine;

public class RoomDescription : MonoBehaviour
{

    private DialogueManager myDM;

    private void Start() {
        myDM = FindAnyObjectByType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            myDM.showRoom(gameObject.name);
        }
    }
}
