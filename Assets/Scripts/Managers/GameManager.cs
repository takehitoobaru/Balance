using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の管理
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public Vector2 ScreenLeftBottom => _screenLeftBottom;
    public Vector2 ScreenRightTop => _screenRightTop;
    #endregion

    #region private
    /// <summary>スコア</summary>
    private int _score = 0;
    /// <summary>ハイスコア</summary>
    private int _highScore = 0;
    /// <summary>属性値の合計</summary>
    private int _elementSum = 0;
    /// <summary>炭水化物属性値</summary>
    private int _carbohydrateAmount = 0;
    /// <summary>肉属性値</summary>
    private int _meatAmount = 0;
    /// <summary>魚属性値</summary>
    private int _fishAmount = 0;
    /// <summary>野菜属性値</summary>
    private int _vegetableAmount = 0;
    /// <summary>画面左下</summary>
    private Vector2 _screenLeftBottom;
    /// <summary>画面右上</summary>
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
    /// 初期化
    /// </summary>
    public void SetUp()
    {
        //属性値初期化
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
        //スコア初期化
        _score = 0;
    }

    /// <summary>
    /// スコア増加
    /// </summary>
    /// <param name="amount">増加値</param>
    public void AddScore(int amount)
    {
        _score += amount;

        Debug.Log("Score:" + _score);
    }

    /// <summary>
    /// 属性値増加
    /// </summary>
    /// <param name="carbohydreat">炭水化物</param>
    /// <param name="meat">肉</param>
    /// <param name="fish">魚</param>
    /// <param name="vegetable">野菜</param>
    public void AddElement(int carbohydreat, int meat, int fish, int vegetable)
    {
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;
        Debug.Log("炭水化物:" + _carbohydrateAmount);

        _meatAmount += meat;
        _elementSum += meat;
        Debug.Log("肉:" + _meatAmount);

        _fishAmount += fish;
        _elementSum += fish;
        Debug.Log("魚:" + _fishAmount);

        _vegetableAmount += vegetable;
        _elementSum += vegetable;
        Debug.Log("野菜:" + _vegetableAmount);

        Debug.Log("属性合計:" + _vegetableAmount);
    }
    #endregion

    #region private method
    #endregion
}
