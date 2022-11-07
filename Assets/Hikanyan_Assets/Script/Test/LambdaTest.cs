using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaTest : MonoBehaviour
{
    private System.Action<string> _eventAction;

    private void Start()
    {
        _eventAction = Test;
        _eventAction("à¯êî");
        _eventAction("neko");
        _eventAction("1000");
        _eventAction = (text) =>
        {
            Debug.Log(text);
        };
        _eventAction("neko");
    }

    private void Test(string argText)
    {
        Debug.Log(argText+"é¿çs");
    }
}
