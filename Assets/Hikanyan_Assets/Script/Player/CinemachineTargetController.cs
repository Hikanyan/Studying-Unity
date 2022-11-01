using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTargetController : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("Cinemachine�̃��C���J������ݒ�")]
    /// <summary>���C���̃J������ݒ肷��</summary>
    public GameObject _cinemachineTarget;

    [Tooltip("�J��������Ɉړ��ł���p�x")]
    public float _topClamp = 70.0f;

    [Tooltip("�J���������Ɉړ��ł���p�x")]
    public float _downClamp = -30.0f;

    [Tooltip("�J�����ʒu�̔�����")]
    public float _cameraAngleOffset = 0.0f;

    [Tooltip("�J�����̃��b�N")]
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
