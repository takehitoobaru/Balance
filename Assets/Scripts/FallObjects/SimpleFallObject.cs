using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �܂�������������I�u�W�F�N�g
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
        //����
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    #endregion
}
