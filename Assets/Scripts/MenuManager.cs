using UnityEngine;

public class MenuManager : MonoBehaviour
{
   [SerializeField] GameObject mainMenu;

   [SerializeField] GameObject musicMenu;

//    [SerializeField] TextMeshProUGUI instructions;

    public GameObject currentMenu;

    
    
    private void Start() {
        DontDestroyOnLoad(gameObject);
        GameObject menu = GameObject.Find("Menu");
        GameObject musicMenu = GameObject.Find("MusicMenu");
        DontDestroyOnLoad(menu);
        DontDestroyOnLoad(musicMenu);
        menu.SetActive(false);
        musicMenu.SetActive(false);
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
        Application.OpenURL("https://www.linkedin.com/in/rhuangr");
    }

    public void github(){
        Application.OpenURL("https://github.com/rhuangr");
    }

    public void mail(){
        
    }
}
