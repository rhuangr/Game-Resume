using System.Collections;
using UnityEngine;
using TMPro;
public class MenuInstructions : MonoBehaviour
{
    TextMeshProUGUI instructions;
    Color color;

  
    [SerializeField] float blinkDelay;

    [SerializeField] float removeDelay;
    void Start(){   
        instructions = GetComponent<TextMeshProUGUI>();
        Invoke("showInstructions", 3);
        // color = instructions.color;
        // StartCoroutine(blinkText());

    }
        

    private void showInstructions(){
        instructions.text = "Walk up to the door and press f to begin";
    }

    private void removeInstructions(){
        instructions.text = "";
    }

    IEnumerator blinkText(){

        while(true){
            showInstructions();
            yield return new WaitForSeconds(blinkDelay);
            removeInstructions();
            yield return new WaitForSeconds(removeDelay);

        }
    }
}
