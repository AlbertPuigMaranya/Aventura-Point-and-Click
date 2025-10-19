using UnityEngine;

public class TvProperties : Interactable
{
    [Header("Estado de la TV")]
    public bool isActive = false;
    public bool mandoEncontrado = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError($"No hay Animator en {gameObject.name}");
        }
    }


    protected override void OnMirar()
    {
        string texto;
        
        if (!mandoEncontrado)
        {
            texto = "Aquí hay una televisión. Está Pausada . Necesitaré el mando para encenderla.";
        }
   
        else
        {
            texto = "La televisión está encendida. Se ve las Noticias Por la Pantalla .";
        }
        
        MostrarDialogo(texto);
        Debug.Log($"Mirando TV: Estado={isActive}");
    }

    protected override void OnUsar()
    {
        if (!mandoEncontrado)
        {
            MostrarDialogo("No tengo el mando a distancia. Debería buscarlo por el bar.");
            return;
        }

        if (!isActive)
        {
            // Encender la TV
            isActive = true;
            
            if (animator != null)
            {
                animator.SetBool("isUsed", true);
            }
            
            MostrarDialogo("¡He Reanudao la televisión con el mando! Ahora puedo ver las Noticias.");
            Debug.Log("TV encendida");
        }
        else
        {
            MostrarDialogo("La televisión ya está encendida. Estoy viendo las Noticias.");
        }
    }

    protected override void OnCoger()
    {
        MostrarDialogo("No puedo llevarme la televisión. Es demasiado grande y pesada.");
    }

    protected override void OnBeber()
    {
        MostrarDialogo("No puedo beber una televisión... ¿En qué estaba pensando?");
    }

    // Método público para cuando se encuentra el mando
    public void EncontrarMando()
    {
        mandoEncontrado = true;
        Debug.Log("¡Mando encontrado! Ahora puedo usar la TV");
    }
}