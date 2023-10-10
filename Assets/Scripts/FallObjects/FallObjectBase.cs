using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������̃x�[�X�N���X
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class FallObjectBase : MonoBehaviour, IGetable
{
    #region property
    public int ScoreAmount => _scoreAmount;
    public int CarbohydreatAmount => _carbohydreatAmount;
    public int MeatAmount => _meatAmount;
    public int FishAmount => _fishAmount;
    public int VegetableAmount => _vegetableAmount;
    #endregion

    #region serialize
    [Tooltip("�I�u�W�F�N�g�f�[�^")]
    [SerializeField]
    private ObjectData _objectData = default;

    [Tooltip("�������x")]
    [SerializeField]
    protected int _fallSpeed = 10;
    #endregion

    #region protected
    /// <summary>�X�R�A�l</summary>
    protected int _scoreAmount;
    /// <summary>�Y�������l</summary>
    protected int _carbohydreatAmount;
    /// <summary>���l</summary>
    protected int _meatAmount;
    /// <summary>���l</summary>
    protected int _fishAmount;
    /// <summary>��ؒl</summary>
    protected int _vegetableAmount;
    /// <summary>�R���C�_�[</summary>
    protected BoxCollider2D _col;
    /// <summary>����</summary>
    protected Rigidbody2D _rb;
    #endregion

    #region unity methods
    protected virtual void Awake()
    {
        //�e�l���f�[�^����擾
        _scoreAmount = _objectData.ScoreAmount;
        _carbohydreatAmount = _objectData.Carbohydreat;
        _meatAmount = _objectData.MeatAmount;
        _fishAmount = _objectData.FishAmount;
        _vegetableAmount = _objectData.VegetableAmount;

        //�R���|�[�l���g�擾
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //�v���C�\�łȂ��Ȃ�v�[���ɖ߂�
        if(InGameManager.Instance.CanPlay == false)
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ɐڐG������
        if (collision.CompareTag("Player"))
        {
            Get(ScoreAmount, CarbohydreatAmount, MeatAmount, FishAmount, VegetableAmount);
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// �擾
    /// </summary>
    /// <param name="scoreAmount">�X�R�A�l</param>
    /// <param name="carbohydreatAmount">�Y�������l</param>
    /// <param name="meatAmount">���l</param>
    /// <param name="fishAmount">���l</param>
    /// <param name="vegetableAmount">��ؒl</param>
    public void Get(int scoreAmount, int carbohydreatAmount, int meatAmount, int fishAmount, int vegetableAmount)
    {
        InGameManager.Instance.AddScore(scoreAmount);
        InGameManager.Instance.AddElement(carbohydreatAmount, meatAmount, fishAmount, vegetableAmount);
    }
    #endregion
}
