using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractManager : MonoBehaviour
{

    MusicManager myMusicManager;

    MenuManager myMenuManager;

    [Header("Friction")]
    [SerializeField] float frictionFactor;
    [SerializeField] float frictionRate;

    private List<string> interactables = new List<string>(){"Computer", "Door", "Phone", "Piano", "Picture"};
    private GameObject picture;
    private bool pictureOpen = false;
    private bool pictureFirstOpened = true;
    private void Start() {
        myMusicManager = FindObjectOfType<MusicManager>();
        myMenuManager = FindObjectOfType<MenuManager>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        if (pictureOpen == true && Input.GetMouseButtonDown(0)){
            picture.SetActive(false);
            pictureOpen = false;
            myMusicManager.playPageFlip();
        }
    }
    public void interact(string Interactable){
        
        if (Interactable == "Piano"){
            myMusicManager.playChord();
            FindObjectOfType<MenuManager>().MusicMenu();
        }

        else if (Interactable == "Door"){
            GameObject myMusicManager = GameObject.Find("SFXManager");
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(1);
            myMusicManager.GetComponent<MusicManager>().playHouseJazz();
        }
        
        else if (Interactable == "Computer"){
            myMenuManager.github();
        }

        else if (Interactable == "Phone"){
            myMenuManager.linkedin();
        }

        else if (Interactable == "Picture"){
            myMusicManager.playPageFlip();
            if (picture.activeInHierarchy){
                picture.SetActive(false);
                pictureOpen = false;
            }
            else{
                picture.SetActive(true);
                pictureOpen = true;
                if (pictureFirstOpened == true){
                    string dialogue = FindObjectOfType<AllDialogues>().firstPictureClose;
                    FindObjectOfType<DialogueManager>().dogSpeak(dialogue);
                    pictureFirstOpened = false;
                }
            }
        }
        else{
            return;
        }
        if (interactables.Remove(Interactable) && interactables.Count == 0){
            FindObjectOfType<RoomDescription>().lastInteractFound = true;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            picture = GameObject.Find("BabyRichard");
            picture.SetActive(false);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
 

