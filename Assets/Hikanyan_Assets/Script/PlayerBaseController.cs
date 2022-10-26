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
}
