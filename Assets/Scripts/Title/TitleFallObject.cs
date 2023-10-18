using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TitleFallObject : MonoBehaviour
{
    #region serialize
    [Tooltip("—Ž‰º‘¬“x")]
    [SerializeField]
    private float _fallSpeed = 2f;
    #endregion

    #region private
    private Rigidbody2D _rb;
    #endregion

    #region unity methods
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, -_fallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
    }
    #endregion
}
