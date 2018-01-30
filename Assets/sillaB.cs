using UnityEngine;
using System.Collections;

public class sillaB : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("En silla ewewewe");
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().sillaBarbero = true;
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().saliocliente = false;
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().clientesEspera--;
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().sillas_ocupadas--;
        GameObject.Find("Control").GetComponent<MonitorPeluqueria>().finalizocorte = false;
    }
}
