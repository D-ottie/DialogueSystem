using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject m_dialoguePanelGO;
    public GameObject m_continueButtonGO;
    public TextMeshProUGUI m_dialogueText;
    public int m_index = -1;
    private float m_wordSpeed = 0.05f;


    public IEnumerator Typing()
    {
        foreach(char letter in dialogue.dialogues[m_index].ToCharArray())
        {
            m_dialogueText.text += letter;
            yield return new WaitForSeconds(m_wordSpeed);
        }

        if(m_dialogueText.text == dialogue.dialogues[m_index])
        {
            m_continueButtonGO.SetActive(true);
        }
    }

    public void GoToNextLine()
    {
        m_continueButtonGO.SetActive(false);
        if(m_index < dialogue.dialogues.Length-1)
        {
            m_index++;
            m_dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ResetDialogue();
        }
    }

    public void ResetDialogue()
    {
        m_dialogueText.text = "";
        m_index = -1;
        m_dialoguePanelGO.SetActive(false);
    }
    
}
