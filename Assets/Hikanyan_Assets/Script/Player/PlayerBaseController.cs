using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBaseController : MonoBehaviour
{
    [Header("�v���C���[�̐ݒ�")]
    [Tooltip("�L�����N�^�[�̕����ړ����x(m/s)")]
    public float _moveSpeed = 3.0f;
    [Tooltip("�L�����N�^�[�̑���ړ����x(m/s)")]
    public float _sprintSpeed = 10.0f;
    [Tooltip("�L�����N�^�[�̈ړ������ւ̌������葬�x")]
    [Range(0.0f, 0.5f)]
    public float _rotationSmoothSpeed = 0.01f;
    [Tooltip("�����x�E�����x")]
    [Range(0.0f, 0.5f)]
    public float _speedChangeRate = 0.01f;


    [Tooltip("�v���C���[���W�����v�ł��鍂��")]
    public float _jumpHeight = 2.0f;

    [Tooltip("�v���C���[�ɂ�����d��")]
    public float _gravity = -9.81f;

    [Tooltip("�ĂуW�����v�ł���悤�ɂȂ�܂ł̌o�ߎ���")]
    public float _JumpTimeout = 0.5f;

    [Tooltip("������ԂɂȂ�܂ł̌o�ߎ���")]
    public float _fallTimeout = 0.12f;

    [Tooltip("�ݒu����")]
    public bool _isGround = false;

    [Tooltip("�ᑬ���")]
    public float _playerSpeedOffset = -0.1f;

    [Tooltip("�n�ʂƂ��Ĕ��肷�郌�C���[")]
    public LayerMask _groundLayers;

    // player
    private PlayerInput _playerInput;
    private Rigidbody _rb;
    private bool _jump;
    private bool _sprint;
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    // timeout deltatime
    private float _jumpTimeoutDelta;
    private float _fallTimeoutDelta;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        
    }

    void PlayerMove()
    {
        //���鑬�x�ݒ�
        float targetSpeed = _sprint ? _sprintSpeed : _moveSpeed;
        
    }
    void PlayerAnimation()
    {

    }

}
