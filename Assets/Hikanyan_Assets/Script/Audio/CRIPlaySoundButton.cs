using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRIPlaySoundButton : MonoBehaviour
{
    [SerializeField] int _playName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickPlay);
    }

    public void ClickPlay()
    {
        CRIAudioManager.instance.CRIPlayBGM(_playName);
    }
}
