using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̐���
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    #region serialize
    [Tooltip("�ړ��X�s�[�h")]
    [SerializeField]
    private float _moveSpeed = 1;
    #endregion

    #region private
    /// <summary>�R���C�_�[�̃T�C�Y�̔���</summary>
    private float _colHalfSize;
    /// <summary>����</summary>
    private Rigidbody2D _rb;
    /// <summary>�R���C�_�[</summary>
    private BoxCollider2D _col;
    #endregion

    #region unity methods
    private void Awake()
    {
        //�R���|�[�l���g�擾
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        //�R���C�_�[�̔����̃T�C�Y���擾
        _colHalfSize = _col.size.x / 2;
    }

    private void Update()
    {
        MovePlayer();
    }
    #endregion

    #region private method
    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    private void MovePlayer()
    {
        //���E�L�[�̓���
        float key = Input.GetAxisRaw("Horizontal");
        //�x���V�e�B�ݒ�
        _rb.velocity = new Vector2(_moveSpeed * key, _rb.velocity.y);
        //�ړ��\�͈͂̐���
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
                                                     GameManager.Instance.ScreenLeftBottom.x + _colHalfSize,
                                                     GameManager.Instance.ScreenRightTop.x - _colHalfSize), 
                                                     transform.position.y);
    }
    #endregion
}
