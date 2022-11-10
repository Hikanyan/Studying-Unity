using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyCallbackTest : MonoBehaviour
{
    private void Start()
    {
        MyProcess myProcess = new MyProcess();
        myProcess.myCallback += MyCallbackMethod1;
        myProcess.myCallback += MyCallbackMethod2;
        myProcess.ExeMyCallback();
    }
    public void MyCallbackMethod1(string message)
    {
        Debug.Log("��������1 : " + message);
    }
    public void MyCallbackMethod2(string message)
    {
        Debug.Log("��������2 : " + message);
    }
}

public class MyProcess
{
    public delegate void MyCallback(string message);
    public MyCallback myCallback;
    public void ExeMyCallback()
    {
        Debug.Log("�������s");

        myCallback?.Invoke("����");
    }
}