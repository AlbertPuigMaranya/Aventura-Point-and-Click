using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [Header("Estado de la Puerta")]
    public bool isOpen = false;
    public bool claveEncontrada = false;

    protected override void OnMirar()
    {
        string texto;

        if (!claveEncontrada)
        {
            texto = "Una puerta cerrada. Parece que necesito una llave para abrirla.";
        }

        else if (!isOpen)
        {
            texto = "La puerta está cerrada. Puedo usar la llave para abrirla.";
        }

        else
        {
            texto = "La puerta está abierta. Puedo pasar por ella.";
        }

        MostrarDialogo(texto);
        Debug.Log($"Mirando Puerta: Estado={isOpen}");
    }

    protected override void OnUsar()
    {
        if (!claveEncontrada && isOpen)
        {
            MostrarDialogo("No tengo la llave. Debería buscarla.");
        }

        else if (!isOpen && claveEncontrada)
        {
            // Abrir la puerta
            isOpen = true;
            Application.Quit();

        }
    }
    protected override void OnCoger()
    {
        MostrarDialogo("No puedo llevarme la puerta. Es demasiado grande y pesada.");
    }
    protected override void OnBeber()
    {
        MostrarDialogo("No puedo beber una puerta... ¿En qué estaba pensando?");
    }

    // Método público para cuando se encuentra la llave
    public void EncontrarLlave()
    {
        claveEncontrada = true;
        Debug.Log("¡Llave encontrada! Ahora puedo usar la puerta");
    }

}