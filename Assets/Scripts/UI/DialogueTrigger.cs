using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const string DIALOGUE_BUTTON = "Fire1";

    public bool hasName;
    public string[] dialogueLines;
    
    private bool canActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetButtonDown(DIALOGUE_BUTTON) && ! DialogueManager.instance.dialogueBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialogue(dialogueLines, hasName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == PLAYER_TAG)
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == PLAYER_TAG)
        {
            canActivate = false;
        }
    }
}
