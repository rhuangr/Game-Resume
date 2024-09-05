using UnityEngine;

public class MenuManager : MonoBehaviour
{
   [SerializeField] GameObject mainMenu;

   [SerializeField] GameObject musicMenu;

//    [SerializeField] TextMeshProUGUI instructions;

    public GameObject currentMenu;
    GameObject linkedinButton;
    GameObject githubButton;
    
    
    private void Start() {
        DontDestroyOnLoad(gameObject);
        GameObject menu = GameObject.Find("Menu");
        GameObject musicMenu = GameObject.Find("MusicMenu");
        linkedinButton = GameObject.Find("TopLeftMenus/linkedin");
        githubButton = GameObject.Find("TopLeftMenus/github");
        DontDestroyOnLoad(menu);
        DontDestroyOnLoad(musicMenu);
        DontDestroyOnLoad(GameObject.Find("TopLeftMenus"));
        menu.SetActive(false);
        musicMenu.SetActive(false);
        linkedinButton.SetActive(false);
        githubButton.SetActive(false);
    }
    public void OpenMenu(){
        currentMenu = mainMenu;
        currentMenu.SetActive(true);
    }
    public void MusicMenu(){
        mainMenu.SetActive(false);
        currentMenu = musicMenu;
        musicMenu.SetActive(true);
    }

    public void exit(){
        Application.Quit();
    }

    public void back(){
        currentMenu.SetActive(false);
        currentMenu = null;
    }

    public void linkedin(){
        linkedinButton.SetActive(true);
        Application.OpenURL("https://www.linkedin.com/in/rhuangr");
    }

    public void github(){
        githubButton.SetActive(true);
        Application.OpenURL("https://github.com/rhuangr");
    }

    public void mail(){
        Application.OpenURL("mailto:richardhuang197@gmail.com");
    }
}
