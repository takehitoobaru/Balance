using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�����b�N�I�����ė����Ă���I�u�W�F�N�g
/// </summary>
public class LockOnObject : FallObjectBase
{
    #region serialize
    [Tooltip("�؋󎞊�")]
    [SerializeField]
    private float _waitTime = 4.0f;
    #endregion

    #region private
    /// <summary>�v���C���[</summary>
    private PlayerController _player;
    /// <summary>�؋󒆂��ǂ���</summary>
    private bool _isWait = true;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        //�R���|�[�l���g�擾
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
        //�؋󒆂Ȃ�
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
    /// ��莞�ԑ҂��Ă��痎������
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
