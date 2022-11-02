using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBaseController : MonoBehaviour
{
    [Header("プレイヤーの設定")]
    [Tooltip("キャラクターの歩く移動速度(m/s)")]
    [SerializeField] float _moveSpeed = 3.0f;

    [Tooltip("キャラクターの走る移動速度(m/s)")]
    [SerializeField] float _sprintSpeed = 10.0f;

    [Tooltip("キャラクターの移動方向への向き直り速度")]
    [Range(0.0f, 0.5f)]
    [SerializeField] float _rotationSmoothSpeed = 0.01f;

    [Tooltip("加速度・減速度")]
    [Range(0.0f, 0.5f)]
    [SerializeField] float _speedChangeRate = 0.01f;

    [SerializeField] Vector3 _velocity;

    [Tooltip("プレイヤーがジャンプできる高さ")]
    [SerializeField] float _jumpHeight = 2.0f;

    [Tooltip("プレイヤーにかかる重力")]
    [SerializeField] float _gravity = -9.81f;

    [Tooltip("再びジャンプできるようになるまでの経過時間")]
    [SerializeField] float _JumpTimeout = 0.5f;

    [Tooltip("落下状態になるまでの経過時間")]
    [SerializeField] float _fallTimeout = 0.12f;

    [Tooltip("ジャンプ回数の制限")]
    [SerializeField] int _jumpLimit;

    [Tooltip("低速状態")]
    [SerializeField] float _playerSpeedOffset = -0.1f;

    [Tooltip("地面として判定するレイヤー")]
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
        //走る速度設定
        float targetSpeed = _sprint ? _sprintSpeed : _moveSpeed;

        // オブジェクト移動
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
            _rb.velocity = Vector3.zero;//ボタン連打した際に、一気に上がっていかないように
            if (isGround)
            {
                _jumpCount = 0;
            }
        }
    }

    private void OnMove(InputValue value)
    {
        // MoveActionの入力値を取得
        var axis = value.Get<Vector2>();

        // 移動速度を保持
        _velocity = new Vector3(axis.x, 0, axis.y);
        Debug.Log(_velocity);
    }
}
