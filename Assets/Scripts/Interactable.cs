using UnityEngine;
 
public class interact : MonoBehaviour
{   
    string detectLayer = "Interactables";
    private MCLogic MC;
    [SerializeField] AudioClip clickSFX;
    [SerializeField] float glowSpeed;
    Transform child;
    SpriteRenderer sprite;
    Color color;
    private bool mouseIsOver;
    private bool playerIsNear;
    int glowDirection;
 
    private void Start() {
        child = transform.Find("Outline");
        sprite = child.gameObject.GetComponent<SpriteRenderer>();
        color = sprite.color;
        MC = FindObjectOfType<MCLogic>();
    }
    private void Update() {
        detectMouse();
        glow(playerIsNear | mouseIsOver);
    }

    private void detectMouse(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Create a layer mask to detect only objects on a specific layer
        int layerMask = LayerMask.GetMask(detectLayer);

        // Raycast to detect if the mouse is over an object on the specified layer
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);

        if (hit.collider == null){
            mouseIsOver = false;
        }
        else{
         
            mouseIsOver = true;
        }
    }
     private void glow(bool isGlowing){

        if (sprite == null){
            return;
        }
        if (color.a <= 0){
            glowDirection = 1;
        }
        else if (color.a >= 1){
            glowDirection = -1;
        }
        if (isGlowing){
            
            color.a = color.a + glowSpeed * glowDirection;
            sprite.color = color;
           
        }
        else{
            if (color.a != 0){
                color.a = 0;
                sprite.color = color;
            }
        }
        
     }

      private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            MC.currentInteract = gameObject.name;
            playerIsNear = true;
            MC.enableInteract();
        }
        
    }
       private void OnTriggerExit2D(Collider2D other) {
          if ( other.CompareTag("Player")){
            glow(false);
            MC.currentInteract = null;
            playerIsNear = false;
            MC.disableInteract();
        }
    }

}
