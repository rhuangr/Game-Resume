using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MCLogic : MonoBehaviour
{
    Vector2 inputVector;
    Rigidbody2D myRigidBody;
    
    Animator myAnimator;

    PlayerInput myInputs;

    InteractManager myInteractor;

    DialogueManager myDM;

    GameObject interactButton;
    public string currentInteract;

    private bool isFirstInteraction = true;

    private string currentAnimation;

    [SerializeField] List<String> interactables;

    int maxInteractables;
    MenuManager myMenuManager;

    
    [Header("mvmt speed")]
    [SerializeField] int walkSpeed;
    [SerializeField] int runSpeed;
    
    private void Start() {
        myMenuManager = FindObjectOfType<MenuManager>();
        myInteractor = FindObjectOfType<InteractManager>();
        myDM = FindObjectOfType<DialogueManager>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myInputs = GetComponent<PlayerInput>();
        
        currentAnimation = "isIdle";
        interactButton = transform.Find("Interact").gameObject;        
        maxInteractables = interactables.Count;
    }
    void OnMove(InputValue value){
        inputVector = value.Get<Vector2>();
        myRigidBody.velocity = new Vector2(inputVector.x * walkSpeed, inputVector.y * walkSpeed);
        if (inputVector.x < 0){
            GetComponent<SpriteRenderer>().flipX = true;
            setAnimation("isWalkingSide");
            return;
        }
        else if (inputVector.x > 0){
            GetComponent<SpriteRenderer>().flipX = false;
            setAnimation("isWalkingSide");
            return;
        }
    
        else if (inputVector.y < 0){
            setAnimation("isWalkingFront");
            return;
        }
        else if (inputVector.y > 0){
            setAnimation("isWalkingBack");
            return;
        }
        else{
            setAnimation("isIdle");
        }       
    }

    private void setAnimation(string animation){
        myAnimator.SetBool( currentAnimation, false);
        currentAnimation = animation;
        myAnimator.SetBool(animation, true);
    }

    public void enableInteract(){
        myInputs.actions.FindAction("Interact").Enable();
        interactButton.SetActive(true);
        if (isFirstInteraction){
            isFirstInteraction = false;
            if (FindObjectOfType<AllDialogues>() == null){
                return;
            }
            myDM.dogSpeak(FindObjectOfType<AllDialogues>().firstInteraction);
        }    
    }

    public void disableInteract(){
        myInputs.actions.FindAction("Interact").Disable();
        interactButton.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        myRigidBody.velocity = new Vector2(0,0);
    }

    void OnInteract(){
        myInteractor.interact(currentInteract);
        if (interactables.Contains(currentInteract)){
            interactables.Remove(currentInteract);
        }
    }

    void OnEscape(){ 
        if (myMenuManager.currentMenu != null){
            myMenuManager.back();
        }
        else{
            myMenuManager.OpenMenu();
        }
    }

    public void setFirstInteraction(){
        isFirstInteraction = true;
    }
}
