using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public Camera camara;
    public float velocidad = 1f;

    public GameObject bar1;
    public GameObject bar3;
   
    public Button botonIzquierda;   
    public Button botonDerecha;    

    void Start()
    {
        botonIzquierda.onClick.AddListener(MoverIzquierda);
        botonDerecha.onClick.AddListener(MoverDerecha);

      
    }

 

    public void MoverIzquierda()
    {
        Vector3 pos = camara.transform.position;
        pos.x -= velocidad;
        pos.x = Mathf.Clamp(pos.x, bar1.transform.position.x, bar3.transform.position.x);
        camara.transform.position = pos;
    }

    public void MoverDerecha()
    {
        Vector3 pos = camara.transform.position;
        pos.x += velocidad;
        pos.x = Mathf.Clamp(pos.x, bar1.transform.position.x, bar3.transform.position.x);
        camara.transform.position = pos;
    }
}
