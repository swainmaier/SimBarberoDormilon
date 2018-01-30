using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cliente : MonoBehaviour {
    public int id;
    UnityEngine.AI.NavMeshAgent agent;
    public int id_silla;
    MonitorPeluqueria monitor;
    [SerializeField]
    Text texto;
    [SerializeField]
    GameObject globo;

    // Use this for initialization
    void Start() {
        id = Control.getAi();
        texto.text = ""+id;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        monitor = GameObject.Find("Control").GetComponent<MonitorPeluqueria>();
        if (monitor.SillasDisponibles() > 0)
        {
            monitor.llega_Cliente(this);
        }
        else
        {
            globo.SetActive(true);
            Destroy(gameObject ,2f);
        }
    }


    public void mover(Vector3 pos)
    {
        agent.destination = pos;
        Debug.Log("ewewe");
    }

}
