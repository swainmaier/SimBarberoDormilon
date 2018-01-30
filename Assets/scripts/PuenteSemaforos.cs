using UnityEngine;
using System.Collections;
using System.Threading;

public class PuenteSemaforos : MonoBehaviour {

    static Thread[] threads = new Thread[10];
    static Semaphore sem = new Semaphore(3, 3);

    static void C_sharpcorner()
    {
        Debug.Log("{0} is waiting in line..." + Thread.CurrentThread.Name);
        sem.WaitOne();
        Debug.Log("{0} enters the C_sharpcorner.com!" + Thread.CurrentThread.Name);
        Thread.Sleep(300);
        Debug.Log("{0} is leaving the C_sharpcorner.com" + Thread.CurrentThread.Name);
        sem.Release();
    }

    // Use this for initialization
    void Start () {

        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(C_sharpcorner);
            threads[i].Name = "thread_" + i;
            threads[i].Start();
        }
        Debug.Log("jajaja");
    }

    }
	

