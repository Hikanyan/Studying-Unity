using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEventTest : MonoBehaviour
{
    [SerializeField] HitControllerTest hitControllerTest;
    private void Start()
    {
        hitControllerTest.hitEvent += ChengeColler;
    }
    void ChengeColler()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitControllerTest.hitEvent();
    }
}
