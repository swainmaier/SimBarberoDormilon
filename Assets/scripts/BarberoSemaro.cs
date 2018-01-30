using UnityEngine;
using System.Collections;
using System.Threading;

public class BarberoSemaro : MonoBehaviour {

    static int waiting_customers = 0;
    static int N_CHAIRS = 4;

    static Thread[] hilo_clientes = new Thread[20];
    static Thread[] hilo_peluquero = new Thread[1];

    static Semaphore customers = new Semaphore(1, 1);
    static Semaphore mutex = new Semaphore(1, 1);
    static Semaphore barbers = new Semaphore(1, 1);

    static void barbero()
    {

        /*Duerme si no hay clientes */
        Debug.Log(Thread.CurrentThread.Name + " Duerme");
        customers.WaitOne();

                /* Entra en la seccion critica */
                mutex.WaitOne();
                Debug.Log(Thread.CurrentThread.Name + " se despierta");
                 /* el peluquero llama a un cliente a la silla de corte */
                 waiting_customers--;
                Debug.Log(Thread.CurrentThread.Name + " llama a un cliente a la silla");
                /* El peluquero esta listo */
                barbers.Release();

                /* sale de la seccion critica */
                mutex.Release();
                Debug.Log(Thread.CurrentThread.Name + " termina el corte de pelo");
                //corte de pelo
                //cut_hair();
    }


    static void cliente()
    {
        /* Entra en la seccion critica */
        mutex.WaitOne();
        Debug.Log(Thread.CurrentThread.Name + " llega a la peluqueria");
        /* El cliente entra si hay sillas disponibles */
        if (waiting_customers < N_CHAIRS)
        {
            waiting_customers++;

            /* Despertar al peluquero */
            customers.Release();
            /* sale de la seccion critica */
            mutex.Release();

            /* Esperar al peluquero */
            Debug.Log(Thread.CurrentThread.Name + " espera al peluquero");
            barbers.WaitOne();

            //pedir corte de pelo
            //get_haircut();
            Debug.Log(Thread.CurrentThread.Name + " se marcha de la peluqueria con el pelo cortado");
        }
        /* La peluqueria esta llena*/
        else {
            /* sale de la seccion critica */
            Debug.Log(Thread.CurrentThread.Name + " se marcha de la peluqueria por que no hay sillas");
            mutex.Release();
            //irse de la peluqueria 
            //leave_barbershop();
        }
    }

    // Use this for initialization
    void Start () {

        hilo_peluquero[0] = new Thread(barbero);
        hilo_peluquero[0].Name = "Peluquero ";
        hilo_peluquero[0].Start();

        for (int i = 0; i < 10; i++)
        {
            hilo_clientes[i] = new Thread(cliente);
            hilo_clientes[i].Name = "cliente " + i;
            hilo_clientes[i].Start();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
