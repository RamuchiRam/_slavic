using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator interactAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        interactAnim.SetBool("interactOpen", true); 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactAnim.SetBool("interactOpen", false);
        dm.EndDialogue();
    }
}
