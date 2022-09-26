using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
/* global variables to contain the created gameobjects of weapons so that instead of running an algorithm to search in the children the objects are directly refernced*/
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

/*  private variables that'll hold the data of which weapon is in the cycle. could be improved by making an array or a cycling linked list or a repeating queue*/
    GameObject currentWeapon;
    GameObject lastWeapon;
    GameObject nextWeapon;
    GameObject placeholder;

    Animator animator; //object of animator datatype to hold the component reference
    int isIdleHash; //create a simpler datatype to contain our strings by 
                    //hashing strings into an int (best practice for optimization)

    void Start()
    {
        /*getting the animator component to change the animation state and the hashing of the string and setting the weapon swapping initial cycle is done here*/
        animator = GetComponent<Animator>(); 
        isIdleHash = Animator.StringToHash("isIdle");
        Debug.Log(animator); //just to confirm if the component has been succesfully fetched
        currentWeapon = weapon1;
        nextWeapon = weapon2;
        lastWeapon = weapon3;
        placeholder = weapon1;
    }

    // Update is called once per frame
    void Update()
    {
        /*dynamically securing the code by making key inputs registered as specified boolians*/
        bool switchingAction = Input.GetKey("r");
        bool startPress =Input.GetKeyDown("r");
        bool stopPress = Input.GetKeyUp("r");
        
        /*  If condition so that the animator starts the switching animation*/
        if (startPress)
        {
            animator.SetBool(isIdleHash, false);


        /*
            currentWeapon.SetActive(false);
            nextWeapon.SetActive(true);
            Switch(ref currentWeapon,ref nextWeapon,ref lastWeapon,ref placeholder);
            StartCoroutine(ExecuteAfterTime());
        */
        } 

        /*
        if(stopPress){
            placeholder = currentWeapon;
            currentWeapon = nextWeapon;
            nextWeapon = lastWeapon;
            lastWeapon = placeholder;
        }
        */
            
        /*  If condition so that when there is no button "r" press the animation goes back to idle state*/
        if (!switchingAction)
        {
            animator.SetBool(isIdleHash, true);
            
        }

    }

    /*defunct coroutine as it did not perform the job. Left in but due to removal*/
    IEnumerator ExecuteAfterTime(){
        yield return new WaitForEndOfFrame();
            currentWeapon.SetActive(false);
            nextWeapon.SetActive(true);
    }

    /*defunct method as it did not perform the job. Left in but due to removal*/
    public void Switch(ref GameObject current,ref GameObject next,ref GameObject last,ref GameObject placeholder){

        placeholder = current;
        current = next;
        next = last;
        last = placeholder;

        current.SetActive(false);
        next.SetActive(true);
    }

    /*
        Function type: void
        Parameters:    void
        Functinoality: switches weapons
        Output:        sets the current weapon gameobject to "disabled"
                       sets the next weapon gameobject in the queue to "enabled"
    */
    public void SwitchWeaponsEvent(){
        currentWeapon.SetActive(false);
        nextWeapon.SetActive(true);
    }

    /*
        Function type: void
        Parameters:    void
        Functinoality: changes the que and sets up which weapon is currently being held and what was the last and next weapons
        Output:        current weapon will equal to the weapon being actually held 
                       the next weapon to be switched to when the button is pressed again is set 
                       the weapon that was held before the switch is registered as such
    */

    public void RouletteWeapons(){
        placeholder = currentWeapon;
        currentWeapon = nextWeapon;
        nextWeapon = lastWeapon;
        lastWeapon = placeholder;
    }
}
