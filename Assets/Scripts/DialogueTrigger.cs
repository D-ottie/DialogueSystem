using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{

    public DialogueManager dialogueManager;
    public UnityEvent onDialogueStart;
    public UnityEvent onDialogueEnd;
    public bool m_hasCollided = false;

    void Start()
    {
        onDialogueStart.AddListener(dialogueManager.GoToNextLine);
        onDialogueEnd.AddListener(dialogueManager.ResetDialogue);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!m_hasCollided)
        {
            m_hasCollided = true;
            if(other.CompareTag("Player"))
            {
                dialogueManager.m_dialoguePanelGO.SetActive(true);
                onDialogueStart.Invoke();
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_hasCollided = false;
        if(other.CompareTag("Player"))
        {
            dialogueManager.m_dialoguePanelGO.SetActive(false);
            onDialogueEnd.Invoke();
        }
    }
}
