using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBaseController : MonoBehaviour
{
    [Header("�v���C���[�̐ݒ�")]
    [Tooltip("�L�����N�^�[�̕����ړ����x(m/s)")]
    [SerializeField] float _moveSpeed = 3.0f;

    [Tooltip("�L�����N�^�[�̑���ړ����x(m/s)")]
    [SerializeField] float _sprintSpeed = 10.0f;

    [Tooltip("�L�����N�^�[�̈ړ������ւ̌������葬�x")]
    [Range(0.0f, 0.5f)]
    [SerializeField] float _rotationSmoothSpeed = 0.01f;

    [Tooltip("�����x�E�����x")]
    [Range(0.0f, 0.5f)]
    [SerializeField] float _speedChangeRate = 0.01f;

    [SerializeField] Vector3 _velocity;

    [Tooltip("�v���C���[���W�����v�ł��鍂��")]
    [SerializeField] float _jumpHeight = 2.0f;

    [Tooltip("�v���C���[�ɂ�����d��")]
    [SerializeField] float _gravity = -9.81f;

    [Tooltip("�ĂуW�����v�ł���悤�ɂȂ�܂ł̌o�ߎ���")]
    [SerializeField] float _JumpTimeout = 0.5f;

    [Tooltip("������ԂɂȂ�܂ł̌o�ߎ���")]
    [SerializeField] float _fallTimeout = 0.12f;

    [Tooltip("�W�����v�񐔂̐���")]
    [SerializeField] int _jumpLimit;

    [Tooltip("�ᑬ���")]
    [SerializeField] float _playerSpeedOffset = -0.1f;

    [Tooltip("�n�ʂƂ��Ĕ��肷�郌�C���[")]
    [SerializeField] LayerMask _groundLayers;

    // player
    private PlayerInput _playerInput;
    private Rigidbody _rb;
    private bool _jump;
    private bool _sprint;
    private int _jumpCount;
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
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Jump();
        }
    }

    void PlayerMove()
    {
        //���鑬�x�ݒ�
        float targetSpeed = _sprint ? _sprintSpeed : _moveSpeed;

        // �I�u�W�F�N�g�ړ�
        transform.position += targetSpeed * _velocity * Time.deltaTime;
    }
    void PlayerAnimation()
    {

    }
    void Jump()
    {
        float distance = 0.2f;
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.0f,0.0f);
        Ray ray = new Ray(rayPosition,Vector3.down);
        bool isGround = Physics.Raycast(ray, distance);
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.green);
        if( isGround || _jumpLimit > _jumpCount)
        {
            _jumpCount++;
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
            _rb.velocity = Vector3.zero;//�{�^���A�ł����ۂɁA��C�ɏオ���Ă����Ȃ��悤��
            if (isGround)
            {
                _jumpCount = 0;
            }
        }
    }

    private void OnMove(InputValue value)
    {
        // MoveAction�̓��͒l���擾
        var axis = value.Get<Vector2>();

        // �ړ����x��ێ�
        _velocity = new Vector3(axis.x, 0, axis.y);
        Debug.Log(_velocity);
    }
}
