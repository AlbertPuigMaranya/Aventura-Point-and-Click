using UnityEngine;

public class BottleProperties : Interactable
{
    [Header("Estado de la Botella")]
    public bool yaRecogida = false;
    public bool yaBebida = false;

    private string tipoBebida;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sePuedeCoger = true; // Las botellas SÍ se pueden coger
        tipoBebida = gameObject.tag; // Usar la etiqueta del objeto como tipo de bebida
    }

    protected override void OnMirar()
    {
        if (yaRecogida)
        {
            MostrarDialogo("Ya no hay nada aquí.");
            return;
        }

        if (yaBebida)
        {
            if (gameObject.tag == "Whiskey")
            {

                MostrarDialogo("La botella de whiskey está vacía.");
            }
            else
            {
                MostrarDialogo("Ya no hay nada aquí.");
            }
            return;
        }

        string texto;
        if (gameObject.tag == "Botella")
        {
            texto = "Aquí hay una botella. Parece estar llena.";
        }
        else if (gameObject.tag == "Whiskey")
        {
            texto = "Una botella de whiskey premium. Se ve tentadora.";
        }
        else
        {
            texto = $"Aquí hay una botella de {tipoBebida}. Todavía está llena.";
        }
        
        MostrarDialogo(texto);
    }

    protected override void OnCoger()
    {

        
        // Añadir al inventario
        if (inventario != null)
        {
            inventario.AddItem($"Botella de {tipoBebida}");

            
        }

        MostrarDialogo($"Has cogido la botella de {tipoBebida}.");
        yaRecogida = true;
        
        // Desaparecer
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        Debug.Log($"Botella de {tipoBebida} cogida");
    }

    protected override void OnBeber()
    {
        if (yaBebida)
        {
            MostrarDialogo("Ya me he bebido esta botella.");
            return;
        }

        yaBebida = true;
        
        string mensaje;
        if (gameObject.tag == "Whisky")
        {
            mensaje = "*GLUP GLUP* ¡Qué Whisky tan bueno! Merece la pena.";
            
            // Ejecutar animación de botella vacía
            if (animator != null)
            {
                animator.SetBool("isFull", false);
                mensaje += " La botella ahora está vacía.";
                 
               
            }
            
        }
        else
        {
            mensaje = $"*GLUP GLUP* Me he bebido la {tipoBebida}. ¡Qué sed tenía!";
            
            // Para otras botellas, desaparecer
            if (spriteRenderer != null)
                spriteRenderer.enabled = false;
        }
        
        MostrarDialogo(mensaje);
        Debug.Log($"Botella de {tipoBebida} bebida");
    }

    protected override void OnUsar()
    {
        if (yaRecogida || yaBebida)
        {
            MostrarDialogo("Ya no puedo usar esto.");
        }
        else
        {
            MostrarDialogo("¿Usarla? Mejor la bebo o la cojo.");
        }
    }
}