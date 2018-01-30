using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {
    [SerializeField]
    public GameObject cliente;
    public static int ai;
    [SerializeField]
    GameObject silla;
    public List<GameObject> sillas = new List<GameObject>();
    public List<bool> dispo = new List<bool>();
    MonitorPeluqueria monitor;
    // Use this for initialization
    [SerializeField]
    public static Transform entrada;
    [SerializeField]
    public static Transform salida;
    [SerializeField]
    Slider slider;
    void Start() {
        monitor = GetComponent<MonitorPeluqueria>();
        entrada = GameObject.Find("Entrada").transform;
        salida = GameObject.Find("Salida").transform;

    }

    // Update is called once per frame
    void Update() {

    }

    public static int getAi()
    {
        ai++;
        return ai;
    }

    public void CrearSillas() {
        int cant = (int)slider.value;
        int porfila = 4;
        int fila = 0;
        Vector3 pos = new Vector3(0.5f, 0, -3);
        for (int i = 0; i < cant; i++)
        {
            if (fila == porfila)
            {
                pos.z = pos.z + 2f;
                pos.x = 0.5f;
                fila = 0;
            }
            GameObject s = (GameObject)Instantiate(silla, pos, Quaternion.Euler(-90, 0, 0));
            s.name = "silla" + (i);
            sillas.Add(s);
            dispo.Add(true);
            pos.x = pos.x - 1.5f;
            fila++;
        }

        monitor.sillas = sillas;
        monitor.cant_sillas = sillas.Count;
    }

    public void crear_cliente()
    {
        //if (monitor.SillasDisponibles() > 0)
            Instantiate(cliente, entrada.position, Quaternion.identity);
    }

    public int get_primera_silla()
    {
        for (int i = 0; i < dispo.Count;i++)
        {
            if (dispo[i])
            {
                dispo[i] = false;
                return i;
            }
        }
        return 0;
    }

    public void liberarsilla(int i)
    {
        dispo[i] = true;
    }

    public void Apagar()
    {
        Application.Quit();
    }

    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
