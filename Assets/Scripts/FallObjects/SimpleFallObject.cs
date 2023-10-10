using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// まっすぐ落下するオブジェクト
/// </summary>
public class SimpleFallObject : FallObjectBase
{
    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnEnable()
    {
        //落下
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    #endregion
}
