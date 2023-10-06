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
    #region serialize
    [Tooltip("移動スピード")]
    [SerializeField]
    private float _moveSpeed = 1;
    #endregion

    #region private
    /// <summary>コライダーのサイズの半分</summary>
    private float _colHalfSize;
    /// <summary>剛体</summary>
    private Rigidbody2D _rb;
    /// <summary>コライダー</summary>
    private BoxCollider2D _col;
    #endregion

    #region unity methods
    private void Awake()
    {
        //コンポーネント取得
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        //コライダーの半分のサイズを取得
        _colHalfSize = _col.size.x / 2;
    }

    private void Update()
    {
        MovePlayer();
    }
    #endregion

    #region private method
    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void MovePlayer()
    {
        //左右キーの入力
        float key = Input.GetAxisRaw("Horizontal");
        //ベロシティ設定
        _rb.velocity = new Vector2(_moveSpeed * key, _rb.velocity.y);
        //移動可能範囲の制限
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
                                                     GameManager.Instance.ScreenLeftBottom.x + _colHalfSize,
                                                     GameManager.Instance.ScreenRightTop.x - _colHalfSize), 
                                                     transform.position.y);
    }
    #endregion
}
