using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [Header("UI del inventario")]
    public TextMeshProUGUI inventoryText;

    private int botellas = 0;
    private bool tieneMando = false;
    private bool tieneLlave = false;

    void Start()
    {
        UpdateDisplay();
    }

    public void AddItem(string itemName)
    {
        if (itemName.Contains("Botella") || itemName.Contains("botella"))
        {
            botellas++;
        }
        else if (itemName.Contains("Mando") || itemName.Contains("mando"))
        {
            tieneMando = true;
        }
        else if (itemName.Contains("Llave") || itemName.Contains("llave"))
        {
            tieneLlave = true;
        }

        UpdateDisplay();
 
    }

    public bool HasItem(string itemName)
    {
        if (itemName.Contains("Mando") || itemName.Contains("mando"))
            return tieneMando;
        if (itemName.Contains("Llave") || itemName.Contains("llave"))
            return tieneLlave;
        return false;
    }

    public int GetBottleCount()
    {
        return botellas;
    }

    

    private void UpdateDisplay()
    {
        if (inventoryText == null) return;

        string text = "📦 Inventario:\n";
        
        if (botellas > 0)
            text += $"• Botellas: {botellas}\n";
        if (tieneMando)
            text += "• Mando TV\n";
        if (tieneLlave)
            text += "• Llave\n";

        if (botellas == 0 && !tieneMando && !tieneLlave)
            text += "Vacío";

        inventoryText.text = text.TrimEnd('\n');
    }
}