using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーをロックオンして落ちてくるオブジェクト
/// </summary>
public class LockOnObject : FallObjectBase
{
    #region property
    #endregion

    #region serialize
    [SerializeField]
    private float _waitTime = 4.0f;
    #endregion

    #region private
    private PlayerController _player;
    private bool _isWait = true;
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _isWait = true;
        StartCoroutine(WaitCoroutine());
    }

    private void Update()
    {
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

    #region public method
    #endregion

    #region private method

    #endregion

    #region coroutine method
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(_waitTime);
        _isWait = false;
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
    }
    #endregion
}
