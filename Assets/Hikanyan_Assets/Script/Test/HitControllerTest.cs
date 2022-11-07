using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControllerTest : MonoBehaviour
{
    public Action hitEvent;
    private void Start()
    {
        hitEvent += Hit;
    }
    private void Hit()
    {
        Debug.Log("é¿çsÇµÇΩÇÁÇµÇ¢Çó");
    }
}
