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
}
