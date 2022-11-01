using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTargetController : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("Cinemachineのメインカメラを設定")]
    /// <summary>メインのカメラを設定する</summary>
    public GameObject _cinemachineTarget;

    [Tooltip("カメラを上に移動できる角度")]
    public float _topClamp = 70.0f;

    [Tooltip("カメラを下に移動できる角度")]
    public float _downClamp = -30.0f;

    [Tooltip("カメラ位置の微調整")]
    public float _cameraAngleOffset = 0.0f;

    [Tooltip("カメラのロック")]
    public bool _lockCameraPosition = false;

    //Cinemachine
    private float _cinemachineTargetAngle;
    private float _cinemachineTargetPitch;

    private GameObject _mainCamera;

    private void Awake()
    {
        if(_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        _cinemachineTargetAngle = _cinemachineTarget.transform.position.y;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0)
        {
            Debug.Log("oku");
        }
        if (scroll < 0)
        {
            Debug.Log("temae");
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Move()
    {

    }

}
