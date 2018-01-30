using UnityEngine;
using System.Collections;
using System.Threading;

public class SillaSalida : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("En silla ewewewe");
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().SalioCliente();
    }

}
