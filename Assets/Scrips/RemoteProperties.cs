using UnityEngine;

public class RemoteProperties : Interactable
{
    [Header("Referencia a la TV")]
    public TvProperties television;

    [Header("Estado")]
    public bool yaRecogido = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sePuedeCoger = true; // El mando SÍ se puede coger
    }

    protected override void OnMirar()
    {
        if (yaRecogido)
        {
            MostrarDialogo("Ya recogí el mando.");
            return;
        }

        string texto = "¡El mando a distancia de la TV! Lo necesito para encenderla.";
        
        MostrarDialogo(texto);
    }

    protected override void OnCoger()
    {
        if (yaRecogido)
        {
            MostrarDialogo("Ya cogí el mando.");
            return;
        }

        yaRecogido = true;

        // Añadir al inventario
        if (inventario != null)
        {
            inventario.AddItem("Mando TV");
        }

        // Notificar a la TV
        if (television != null)
        {
            television.EncontrarMando();
        }

        MostrarDialogo("He cogido el mando a distancia.");

        // Desaparecer
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        Debug.Log("Mando cogido");
    }

    protected override void OnUsar()
    {
        if (yaRecogido)
        {
            MostrarDialogo("Ya cogí el mando. Debería usarlo en la TV.");
        }
        else
        {
            MostrarDialogo("Debería coger el mando primero.");
        }
    }

    protected override void OnBeber()
    {
        MostrarDialogo("No puedo beber un mando a distancia...");
    }
}