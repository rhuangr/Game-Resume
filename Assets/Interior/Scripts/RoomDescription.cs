using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class RoomDescription : MonoBehaviour
{

    private DialogueManager myDM;

    private void Start() {
        myDM = FindAnyObjectByType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log(other.tag);
    if (other.CompareTag("Player")){
        
        myDM.showRoom(gameObject.name);
    }
}
}
