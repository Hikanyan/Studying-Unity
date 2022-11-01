using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBaseController : MonoBehaviour
{
    [Header("プレイヤーの設定")]
    [Tooltip("キャラクターの歩く移動速度(m/s)")]
    public float _moveSpeed = 3.0f;
    [Tooltip("キャラクターの走る移動速度(m/s)")]
    public float _sprintSpeed = 10.0f;
    [Tooltip("キャラクターの移動方向への向き直り速度")]
    [Range(0.0f, 0.5f)]
    public float _rotationSmoothSpeed = 0.01f;
    [Tooltip("加速度・減速度")]
    [Range(0.0f, 0.5f)]
    public float _speedChangeRate = 0.01f;


    [Tooltip("プレイヤーがジャンプできる高さ")]
    public float _jumpHeight = 2.0f;

    [Tooltip("プレイヤーにかかる重力")]
    public float _gravity = -9.81f;

    [Tooltip("再びジャンプできるようになるまでの経過時間")]
    public float _JumpTimeout = 0.5f;

    [Tooltip("落下状態になるまでの経過時間")]
    public float _fallTimeout = 0.12f;

    [Tooltip("設置判定")]
    public bool _isGround = false;

    [Tooltip("低速状態")]
    public float _playerSpeedOffset = -0.1f;

    [Tooltip("地面として判定するレイヤー")]
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
        //走る速度設定
        float targetSpeed = _sprint ? _sprintSpeed : _moveSpeed;
        
    }
    void PlayerAnimation()
    {

    }

}
