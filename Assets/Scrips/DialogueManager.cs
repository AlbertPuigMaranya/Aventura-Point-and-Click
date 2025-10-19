using UnityEngine;
using System.Collections;
using TMPro;
using DialogueNamespace.Dialogues;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Referencias")]
    public TextMeshProUGUI textGame;


    [Header("Configuración")]
    public float letterDelay = 0.05f;
    public bool autoHideWhenFinished = true;
    public float autoHideDelay = 0.5f;

    [Header("Diálogo actual")]
    public Dialogue dialogue;

    private Coroutine typingCoroutine;
    private bool isTyping = false;


    private InputAction continueAction;

    private void Awake()
    {
        continueAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        continueAction.Enable();

        // Limpiar textos
        if (textGame != null) textGame.text = "";
    }

    private void OnDestroy()
    {
        continueAction?.Disable();
        continueAction?.Dispose();
    }



    public void StartDialogue()
    {
        if (dialogue == null)
        {
            Debug.LogWarning("No hay diálogo asignado");
            return;
        }

        // Detener cualquier diálogo anterior
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        

        // Iniciar escritura
        typingCoroutine = StartCoroutine(TypeDialogue());
    }

    private IEnumerator TypeDialogue()
    {
        isTyping = true;

        // Limpiar y configurar
        if (textGame != null)
        {
            textGame.text = "";
            textGame.fontStyle = (dialogue.textType == 1) ? FontStyles.Italic : FontStyles.Normal;
        }


        // Escribir letra por letra
        foreach (char letter in dialogue.dialogueText)
        {
           
            if (textGame != null)
            {
                textGame.text += letter;
            }
            yield return new WaitForSeconds(letterDelay);
        }

        isTyping = false;

        if (autoHideWhenFinished)
        {
            yield return new WaitForSeconds(autoHideDelay);
            HideDialogue();
        }
    }

    public void HideDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        isTyping = false;

        if (textGame != null) textGame.text = "";
    }


    public bool GetIsTyping() => isTyping;
}