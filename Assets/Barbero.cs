using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Barbero : MonoBehaviour {

    public bool duerme;
    public bool onetime = true;
    int estado = 0;
    int max;
    [SerializeField]
    private GameObject globe;
    MonitorPeluqueria monitor;
    [SerializeField]
    Slider slider;
    // Use this for initialization
    void Start () {
        monitor = GameObject.Find("Control").GetComponent<MonitorPeluqueria>();
        duerme = true;
        max = Random.Range(500, 2000);
        slider.maxValue = max;
    }

    // Update is called once per frame
    void Update() {
        if (!duerme && GameObject.FindGameObjectsWithTag("cliente").Length == 0)
        {
            duerme = true;
        }
        globe.SetActive(duerme);
        if (!duerme && !monitor.sillaBarbero && onetime)
        {
            monitor.SiguienteCliente();
            onetime = false;
        }
        if (monitor.sillaBarbero && !monitor.saliocliente)
        {
            
            if (estado < max)
            {
                estado++;
                slider.value = estado;
            }
            if (estado ==  max && !monitor.finalizocorte)
            {
                monitor.SalirCliente();
                monitor.finalizocorte = true;
            }
        }
        
    }


    public void reset()
    {
        slider.value = 0;
        estado = 0;
        max = Random.Range(500, 2000);
        slider.maxValue = max;
    }

}
