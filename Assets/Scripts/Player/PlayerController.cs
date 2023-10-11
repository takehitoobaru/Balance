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
    /// <summary>横入力の値</summary>
    private float key = 0;
    /// <summary>コライダーのサイズの半分</summary>
    private float _colHalfSize;
    /// <summary>剛体</summary>
    private Rigidbody2D _rb;
    /// <summary>コライダー</summary>
    private BoxCollider2D _col;
    /// <summary>アニメーター</summary>
    private Animator _anim;
    #endregion

    #region unity methods
    private void Awake()
    {
        //コンポーネント取得
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
        //コライダーの半分のサイズを取得
        _colHalfSize = _col.size.x / 2;
    }

    private void Update()
    {
        //左右キーの入力
        key = Input.GetAxisRaw("Horizontal");

        //パラメーターの変更
        if (key == 0)
        {
            _anim.SetBool("IsRun", false);
        }
        else
        {
            _anim.SetBool("IsRun", true);
        }

        //左右の向き
        if (key > 0)
        {
            if (transform.localScale.x > 0) return;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else if (key < 0)
        {
            if (transform.localScale.x < 0) return;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }


        //移動可能範囲の制限
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
                                                     GameManager.Instance.ScreenLeftBottom.x + _colHalfSize,
                                                     GameManager.Instance.ScreenRightTop.x - _colHalfSize),
                                                     transform.position.y);
    }

    private void FixedUpdate()
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
        if (InGameManager.Instance.CanPlay == false)
        {
            _rb.velocity = Vector2.zero;
            return;
        }

        //ベロシティ設定
        _rb.velocity = new Vector2(_moveSpeed * key, _rb.velocity.y);

    }
    #endregion
}
