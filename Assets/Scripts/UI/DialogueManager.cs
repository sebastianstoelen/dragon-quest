using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private const string DIALOGUE_BUTTON = "Fire1";
    private const string NAME_PREFIX = "n-";
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;
    public int currentLine;

    public static DialogueManager instance;

    private bool justStarted;
    private bool speakerHasNameTag = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy && Input.GetButtonUp(DIALOGUE_BUTTON))
        {
            DisplayDialogueLines();
        }
    }

    private void DisplayDialogueLines()
    {
        
        if (! justStarted)
        {           
            AdvanceOrEndDialogue();
        }
        else
        {
            justStarted = false;
        }
                 
    }

    private void AdvanceOrEndDialogue()
    {
        currentLine++;
     
        if (currentLine >= dialogueLines.Length)
        {
            DeactivateDialogue();
        }
        else
        {
            CheckAndUpdateName();
            SetNextDialogueLine();
        }
    }

    private void DeactivateDialogue()
    {
        dialogueBox.SetActive(false);
        GameManager.instance.dialogueActive = false;
    }

    public void ShowDialogue(string[] newLines, bool speakerHasName)
    {
        dialogueLines = newLines;
        currentLine = 0;
        speakerHasNameTag = speakerHasName;
        nameBox.SetActive(speakerHasNameTag);
        ActivateDialogue();
    }

    private void ActivateDialogue()
    {
        InitializeDialogueBox();
        GameManager.instance.dialogueActive = true;
    }

    private void InitializeDialogueBox()
    {
        CheckAndUpdateName();
        SetNextDialogueLine();

        dialogueBox.SetActive(true);
        justStarted = true;
    }

    private void SetNextDialogueLine()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    private void CheckAndUpdateName()
    {
        if(speakerHasNameTag)
        {
            if (dialogueLines[currentLine].StartsWith(NAME_PREFIX))
            {
                nameText.text = dialogueLines[currentLine].Substring(NAME_PREFIX.Length);
                currentLine++;
            }
        }

    }
}
