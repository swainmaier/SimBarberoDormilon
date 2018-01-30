using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MonitorPeluqueria : MonoBehaviour
{
    Control control;
    float esperar = 0;
    [SerializeField]
    public int cant_sillas;
    [SerializeField]
    Barbero barbero;
    public bool saliocliente = false;
    private Cliente clienteactual;
    public bool sillaBarbero = false;
    public int clientesEspera;
    bool barberoduerme;
    public bool finalizocorte = false;
    public int sillas_ocupadas;
    [SerializeField]
    Transform sillaBpos;
    [SerializeField]
    Transform salidapos;
    Queue<Cliente> ListaEspera = new Queue<Cliente>();
    public List<GameObject> sillas = new List<GameObject>();

    [SerializeField]
    public Slider slider;
    [SerializeField]
    Animator animator;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<Control>();
        sillaBarbero = false;
        clientesEspera = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SiguienteCliente()
    {
        
        Cliente c = ListaEspera.Dequeue();
        clienteactual = c;
        Debug.Log("empieza el corte de pelo a cliente" +c.id);
        control.liberarsilla(c.id_silla);
        c.mover(sillaBpos.position);
    }


    public int SillasDisponibles()
    {
        return cant_sillas - sillas_ocupadas;
    }

    public void llega_Cliente(Cliente c)
    {
        if (SillasDisponibles() > 0)
        {
            Debug.Log("llego el cliente: "+c.id);
            ListaEspera.Enqueue(c);
            c.id_silla = control.get_primera_silla();
            Debug.Log("se le asigno la silla: " + c.id_silla);
            c.mover(sillas[c.id_silla].transform.position);
            sillas_ocupadas++;
            clientesEspera++;
            Invoke("DespertarBarbero", 10f);
        } else
        {
            //cliente se va
        }
    }

    void DespertarBarbero()
    {
        barbero.duerme = false;
    }

    public void SalirCliente()
    {
        animator.SetBool("abierta", true);
        Debug.Log("se termino el corte del cliente " + clienteactual.id);
        clienteactual.mover(salidapos.position);
    }

    public void SalioCliente()
    {
        animator.SetBool("abierta", false);
        Debug.Log("se fue el cliente " + clienteactual.id);
        barbero.onetime = true;
        barbero.reset();
        sillaBarbero = false;
        saliocliente = true;
        Destroy(clienteactual.gameObject, 3f);

    }
    /*PROCEDURE PedirCorteDePelo (VAR meAtienden : BOOLEAN);
    BEGIN
      meAtienden := TRUE;
      IF sillasLibres = 0 THEN
        meAtienden := FALSE
      ELSIF dormido  THEN
        hayCliente := TRUE;
        Continue (siesta)
      ELSE
        DEC (sillasLibres);
        Delay (clienteEsperando);
        INC (sillasLibres);
        hayCliente := TRUE
      END; (* IF *)
    END PedirCorteDePelo;
    */


}
