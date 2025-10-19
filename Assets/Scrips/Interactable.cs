using UnityEngine;
using DialogueNamespace.Dialogues;

public class Interactable : MonoBehaviour
{
    [Header("Referencias necesarias")]
    public GameManager gameManager;
    public DialogueManager dialogueManager;
    public Inventory inventario;



    public bool sePuedeCoger = false;

    public virtual void OnInteract()
    {
        if (gameManager == null)
        {
            Debug.LogError($"GameManager no asignado en {gameObject.name}");
            return;
        }

        if (gameManager.GetMirarButton())
            OnMirar();
        else if (gameManager.GetUsarButton())
            OnUsar();
        else if (gameManager.GetCogerButton())
            OnCoger();
        else if (gameManager.GetBeberButton())
            OnBeber();
    }

    protected virtual void OnMirar()
    {
        
        MostrarDialogo("");
    }

    protected virtual void OnUsar()
    {
        MostrarDialogo("");
    }

    protected virtual void OnCoger()
    {
        if (!sePuedeCoger)
        {
            
            MostrarDialogo("");
            return;
        }

        if (inventario != null)
        {
            inventario.AddItem(gameObject.name);
        }

        MostrarDialogo("");
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
        
        gameObject.SetActive(false);
    }

    protected virtual void OnBeber()
    {
       MostrarDialogo("");
    }

  

    protected void MostrarDialogo(string texto)
    {
        if (dialogueManager != null && !string.IsNullOrEmpty(texto))
        {
            dialogueManager.dialogue = new Dialogue
            {
                dialogueText = texto,
                textType = 0
            };
            dialogueManager.StartDialogue();
        }

        if (gameManager != null)
        {
            gameManager.DesactivarBotones();
        }
    }
}