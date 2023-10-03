using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの制御
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    [Tooltip("移動スピード")]
    [SerializeField]
    private float _moveSpeed = 1;
    #endregion

    #region private
    private float _colHalfSize;
    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        _colHalfSize = _col.size.x / 2;
    }

    private void Start()
    {

    }

    private void Update()
    {
        MovePlayer();
    }
    #endregion

    #region public method
    #endregion

    #region private method
    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void MovePlayer()
    {
        float key = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveSpeed * key, _rb.velocity.y);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
                                                     GameManager.Instance.ScreenLeftBottom.x + _colHalfSize,
                                                     GameManager.Instance.ScreenRightTop.x - _colHalfSize), 
                                                     transform.position.y);
    }
    #endregion
}
