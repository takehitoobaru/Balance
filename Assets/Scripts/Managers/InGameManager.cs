using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���{�҂̊Ǘ�
/// </summary>
public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public bool CanPlay => _canPlay;
    #endregion

    #region serialize
    #endregion

    #region private
    /// <summary>�X�R�A</summary>
    private int _score = 0;
    /// <summary>�����l�̍��v</summary>
    private float _elementSum = 0;
    /// <summary>�Y�����������l</summary>
    private float _carbohydrateAmount = 0;
    /// <summary>�������l</summary>
    private float _meatAmount = 0;
    /// <summary>�������l</summary>
    private float _fishAmount = 0;
    /// <summary>��ؑ����l</summary>
    private float _vegetableAmount = 0;
    /// <summary>�Y����������</summary>
    private float _carbohydreatPercent = 0;
    /// <summary>������</summary>
    private float _meatPercent = 0;
    /// <summary>������</summary>
    private float _fishPercent = 0;
    /// <summary>��؊���</summary>
    private float _vegetablePercent = 0;
    /// <summary>����ł��邩�ǂ���</summary>
    private bool _canPlay = true;
    #endregion

    #region Constant
    /// <summary>�Y�������l�̏����l</summary>
    private float CARBOHYDRATE_BASE = 25;
    /// <summary>���l�̏����l</summary>
    private float MEAT_BASE = 25;
    /// <summary>���l�̏����l</summary>
    private float FISH_BASE = 25;
    /// <summary>��ؒl�̏����l</summary>
    private float VEGETABLE_BASE = 25;
    #endregion

    #region Event
    /// <summary>
    /// �Y�������l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="carbohydreatPercent">�Y�������̊���</param>
    public delegate void CarbohydreatPercentEventHandler(float carbohydreatPercent);
    public event CarbohydreatPercentEventHandler OnCarbohydreatPercentChanged;

    /// <summary>
    /// ���l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="meatPercent">���̊���</param>
    public delegate void MeatPercentEventHandler(float meatPercent);
    public event MeatPercentEventHandler OnMeatPercentChanged;

    /// <summary>
    /// ���l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="fishPercent">���̊���</param>
    public delegate void FishPercentEventHandler(float fishPercent);
    public event FishPercentEventHandler OnFishPercentChanged;

    /// <summary>
    /// ��ؒl�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="vegetablePercent">��؂̊���</param>
    public delegate void VegetablePercentEventHandler(float vegetablePercent);
    public event VegetablePercentEventHandler OnVegetablePercentChanged;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        //�����l������
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
    }
    #endregion

    #region public method
    /// <summary>
    /// �X�R�A����
    /// </summary>
    /// <param name="amount">�����l</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// �����l����
    /// </summary>
    /// <param name="carbohydreat">�Y������</param>
    /// <param name="meat">��</param>
    /// <param name="fish">��</param>
    /// <param name="vegetable">���</param>
    public void AddElement(int carbohydreat, int meat, int fish, int vegetable)
    {
        //�Y�������l
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;

        //���l
        _meatAmount += meat;
        _elementSum += meat;

        //���l
        _fishAmount += fish;
        _elementSum += fish;

        //��ؒl
        _vegetableAmount += vegetable;
        _elementSum += vegetable;

        ElementPercentage();
    }

    /// <summary>
    /// �����l�̊����Z�o
    /// </summary>
    public void ElementPercentage()
    {
        //�Y������
        _carbohydreatPercent = _carbohydrateAmount / _elementSum;
        //�C�x���g
        if (OnCarbohydreatPercentChanged != null)
        {
            OnCarbohydreatPercentChanged.Invoke(_carbohydreatPercent);
        }

        //��
        _meatPercent = _meatAmount / _elementSum;
        //�C�x���g
        if (OnMeatPercentChanged != null)
        {
            OnMeatPercentChanged.Invoke(_meatPercent);
        }

        //��
        _fishPercent = _fishAmount / _elementSum;
        //�C�x���g
        if (OnFishPercentChanged != null)
        {
            OnFishPercentChanged.Invoke(_fishPercent);
        }

        //���
        _vegetablePercent = _vegetableAmount / _elementSum;
        //�C�x���g
        if (OnVegetablePercentChanged != null)
        {
            OnVegetablePercentChanged.Invoke(_vegetablePercent);
        }
    }

    /// <summary>
    /// ����\���ǂ�����؂�ւ���
    /// </summary>
    public void ChangeCanPlay()
    {
        if (_canPlay == true)
        {
            _canPlay = false;
        }
        else
        {
            _canPlay = true;
        }
    }
    #endregion
}
