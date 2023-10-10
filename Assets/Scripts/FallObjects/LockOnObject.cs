using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーをロックオンして落ちてくるオブジェクト
/// </summary>
public class LockOnObject : FallObjectBase
{
    #region serialize
    [Tooltip("滞空時間")]
    [SerializeField]
    private float _waitTime = 4.0f;
    #endregion

    #region private
    /// <summary>プレイヤー</summary>
    private PlayerController _player;
    /// <summary>滞空中かどうか</summary>
    private bool _isWait = true;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        //コンポーネント取得
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _isWait = true;
        StartCoroutine(WaitCoroutine());
    }

    protected override void Update()
    {
        base.Update();
        //滞空中なら
        if(_isWait == true)
        {
            transform.position = new Vector2(_player.transform.position.x, transform.position.y);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// 一定時間待ってから落下する
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(_waitTime);
        _isWait = false;
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
    }
    #endregion
}
