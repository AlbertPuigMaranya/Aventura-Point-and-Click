using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Estados de los botones
    private bool mirarActive = false;
    private bool usarActive = false;
    private bool cogerActive = false;
    private bool beberActive = false;

    [Header("Referencias a los botones UI")]
    public Button buttonMirar;
    public Button buttonUsar;
    public Button buttonCoger;
    public Button buttonBeber;

    [Header("Colores para los botones")]
    public Color colorNormal = Color.white;
    public Color colorActivo = Color.yellow;

    void Start()
    {
        ResetAllButtons();
    }


    public void UseButtonMirar()
    {
        ResetAllButtons();
        mirarActive = true;
        if (buttonMirar != null)
        {
            Image img = buttonMirar.GetComponent<Image>();
            if (img != null) img.color = colorActivo;
        }
        Debug.Log("GameManager: Botón MIRAR activado");
    }

    public void UseButtonUsar()
    {
        ResetAllButtons();
        usarActive = true;
        if (buttonUsar != null)
        {
            Image img = buttonUsar.GetComponent<Image>();
            if (img != null) img.color = colorActivo;
        }
        Debug.Log("GameManager: Botón USAR activado");
    }

    public void UseButtonCoger()
    {
        ResetAllButtons();
        cogerActive = true;
        if (buttonCoger != null)
        {
            Image img = buttonCoger.GetComponent<Image>();
            if (img != null) img.color = colorActivo;
        }
        Debug.Log("GameManager: Botón COGER activado");
    }

    public void UseButtonBeber()
    {
        ResetAllButtons();
        beberActive = true;
        if (buttonBeber != null)
        {
            Image img = buttonBeber.GetComponent<Image>();
            if (img != null) img.color = colorActivo;
        }
        Debug.Log("GameManager: Botón BEBER activado");
    }


    public bool GetMirarButton()
    {
        return mirarActive;
    }

    public bool GetUsarButton()
    {
        return usarActive;
    }

    public bool GetCogerButton()
    {
        return cogerActive;
    }

    public bool GetBeberButton()
    {
        return beberActive;
    }



    private void ResetAllButtons()
    {
        mirarActive = false;
        usarActive = false;
        cogerActive = false;
        beberActive = false;

        // Resetear colores de todos los botones
        if (buttonMirar != null)
        {
            Image img = buttonMirar.GetComponent<Image>();
            if (img != null) img.color = colorNormal;
        }
        
        if (buttonUsar != null)
        {
            Image img = buttonUsar.GetComponent<Image>();
            if (img != null) img.color = colorNormal;
        }
        
        if (buttonCoger != null)
        {
            Image img = buttonCoger.GetComponent<Image>();
            if (img != null) img.color = colorNormal;
        }
        
        if (buttonBeber != null)
        {
            Image img = buttonBeber.GetComponent<Image>();
            if (img != null) img.color = colorNormal;
        }
    }

    // Método público para desactivar todos los botones después de una acción
    public void DesactivarBotones()
    {
        ResetAllButtons();
    }
}