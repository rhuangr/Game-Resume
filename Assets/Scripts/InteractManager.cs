using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractManager : MonoBehaviour
{

    MusicManager myMM;

    [Header("Friction")]
    [SerializeField] float frictionFactor;
    [SerializeField] float frictionRate;

    private bool SHUTUP = false;
    private List<string> interactables = new List<string>(){"Computer", "Door", "Phone", "Piano"};
    private void Start() {
        myMM = FindObjectOfType<MusicManager>();
        DontDestroyOnLoad(gameObject);
        // rb = GameObject.Find("balltest").GetComponent<Rigidbody2D>();
    }

    public void interact(string Interactable){
        
        if (Interactable == "Piano"){
            myMM.playChord();
            FindObjectOfType<MenuManager>().MusicMenu();
        }

        else if (Interactable == "Door"){
            GameObject myMusicManager = GameObject.Find("SFXManager");
            SceneManager.LoadScene(1);
            myMusicManager.GetComponent<MusicManager>().playHouseJazz();
        }
        
        else if (Interactable == "Computer"){
            Application.OpenURL("https://github.com/rhuangr");
        }

        else if (Interactable == "Phone"){
            Application.OpenURL("https://linkedin.com/in/rhuangr");
        }
        else{
            return;
        }
        interactables.Remove(Interactable);
        if (interactables.Count == 0 && SHUTUP == false){
            string dialogue = FindObjectOfType<AllDialogues>().lastInteraction;
            FindObjectOfType<DialogueManager>().dogSpeak(dialogue);
            SHUTUP = true;
        }
    }

    // public void interactBall(float x, float y){
       
    //     float newX = ball.transform.position.x - x;
    //     float newY = ball.transform.position.y - y;
        
    //     rb.velocity = new Vector2(newX,newY);
     
    // }

 
}
