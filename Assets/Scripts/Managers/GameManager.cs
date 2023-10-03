using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̂̊Ǘ�
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public Vector2 ScreenLeftBottom => _screenLeftBottom;
    public Vector2 ScreenRightTop => _screenRightTop;
    #endregion

    #region private
    /// <summary>�X�R�A</summary>
    private int _score = 0;
    /// <summary>�n�C�X�R�A</summary>
    private int _highScore = 0;
    /// <summary>�����l�̍��v</summary>
    private int _elementSum = 0;
    /// <summary>�Y�����������l</summary>
    private int _carbohydrateAmount = 0;
    /// <summary>�������l</summary>
    private int _meatAmount = 0;
    /// <summary>�������l</summary>
    private int _fishAmount = 0;
    /// <summary>��ؑ����l</summary>
    private int _vegetableAmount = 0;
    /// <summary>��ʍ���</summary>
    private Vector2 _screenLeftBottom;
    /// <summary>��ʉE��</summary>
    private Vector2 _screenRightTop;
    #endregion

    #region Constant
    private int CARBOHYDRATE_BASE = 25;
    private int MEAT_BASE = 25;
    private int FISH_BASE = 25;
    private int VEGETABLE_BASE = 25;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        SetUp();
    }

    private void Start()
    {
        _screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        _screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void Update()
    {

    }
    #endregion

    #region public method
    /// <summary>
    /// ������
    /// </summary>
    public void SetUp()
    {
        //�����l������
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
        //�X�R�A������
        _score = 0;
    }

    /// <summary>
    /// �X�R�A����
    /// </summary>
    /// <param name="amount">�����l</param>
    public void AddScore(int amount)
    {
        _score += amount;

        Debug.Log("Score:" + _score);
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
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;
        Debug.Log("�Y������:" + _carbohydrateAmount);

        _meatAmount += meat;
        _elementSum += meat;
        Debug.Log("��:" + _meatAmount);

        _fishAmount += fish;
        _elementSum += fish;
        Debug.Log("��:" + _fishAmount);

        _vegetableAmount += vegetable;
        _elementSum += vegetable;
        Debug.Log("���:" + _vegetableAmount);

        Debug.Log("�������v:" + _vegetableAmount);
    }
    #endregion

    #region private method
    #endregion
}
