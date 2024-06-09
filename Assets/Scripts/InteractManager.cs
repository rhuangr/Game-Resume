using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;

public class InteractManager : MonoBehaviour
{

    MusicManager myMM;

    [Header("Friction")]
    [SerializeField] float frictionFactor;
    [SerializeField] float frictionRate;

    // [SerializeField] GameObject ball;
    Rigidbody2D rb;
    private void Start() {
        myMM = FindObjectOfType<MusicManager>();
        DontDestroyOnLoad(gameObject);
        // rb = GameObject.Find("balltest").GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        
    }
    public void interact(string Interactable){
        
        if (Interactable == "Piano"){
            myMM.playChord();
            FindObjectOfType<MenuManager>().MusicMenu();
           
        }

        if (Interactable == "Door"){
            GameObject myMusicManager = GameObject.Find("SFXManager");
            
            SceneManager.LoadScene(0);
            myMusicManager.GetComponent<MusicManager>().playHouseJazz();
        }

      
    }

    // public void interactBall(float x, float y){
       
    //     float newX = ball.transform.position.x - x;
    //     float newY = ball.transform.position.y - y;
        
    //     rb.velocity = new Vector2(newX,newY);
     
    // }

 
}
