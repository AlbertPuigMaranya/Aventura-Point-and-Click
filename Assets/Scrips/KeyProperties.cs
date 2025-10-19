using UnityEngine;



public class KeyProperties : Interactable
{
    [Header("Referencia a la Puerta")]
    public Door puerta; 

    [Header("Estado")]
    public bool yaRecogida = false;

    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sePuedeCoger = true; // La llave SÍ se puede coger
    }

    protected override void OnMirar()
    {
        string texto = "Aquí hay una llave. Podría abrir la puerta con ella.";
        
        MostrarDialogo(texto);
    }

    protected override void OnCoger()
    {
        yaRecogida = true;

        // Añadir al inventario
        if (inventario != null)
        {
            inventario.AddItem("Llave");
   
        }

        MostrarDialogo("He cogido la llave.");

        // Notificar a la puerta
        if (puerta != null)
        {
            puerta.EncontrarLlave();
        }

        // Desaparecer
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

    }

    protected override void OnUsar()
    {
        if (yaRecogida)
        {
            MostrarDialogo("Ya cogí la llave. Debería usarla en la puerta.");
        }
        else
        {
            MostrarDialogo("Debería coger la llave primero.");
        }
    }

    protected override void OnBeber()
    {
        MostrarDialogo("Beber una llave sería muy doloroso.");
    }

    
}