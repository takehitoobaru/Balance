using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : ObjectBase
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
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

    private void OnEnable()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
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
}
