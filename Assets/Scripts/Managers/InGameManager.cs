using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム本編の管理
/// </summary>
public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public bool CanPlay => _canPlay;
    #endregion

    #region serialize
    #endregion

    #region private
    /// <summary>スコア</summary>
    private int _score = 0;
    /// <summary>属性値の合計</summary>
    private float _elementSum = 0;
    /// <summary>炭水化物属性値</summary>
    private float _carbohydrateAmount = 0;
    /// <summary>肉属性値</summary>
    private float _meatAmount = 0;
    /// <summary>魚属性値</summary>
    private float _fishAmount = 0;
    /// <summary>野菜属性値</summary>
    private float _vegetableAmount = 0;
    /// <summary>炭水化物割合</summary>
    private float _carbohydreatPercent = 0;
    /// <summary>肉割合</summary>
    private float _meatPercent = 0;
    /// <summary>魚割合</summary>
    private float _fishPercent = 0;
    /// <summary>野菜割合</summary>
    private float _vegetablePercent = 0;
    /// <summary>操作できるかどうか</summary>
    private bool _canPlay = true;
    #endregion

    #region Constant
    /// <summary>炭水化物値の初期値</summary>
    private float CARBOHYDRATE_BASE = 25;
    /// <summary>肉値の初期値</summary>
    private float MEAT_BASE = 25;
    /// <summary>魚値の初期値</summary>
    private float FISH_BASE = 25;
    /// <summary>野菜値の初期値</summary>
    private float VEGETABLE_BASE = 25;
    #endregion

    #region Event
    /// <summary>
    /// 炭水化物値変化イベントのデリゲート
    /// </summary>
    /// <param name="carbohydreatPercent">炭水化物の割合</param>
    public delegate void CarbohydreatPercentEventHandler(float carbohydreatPercent);
    public event CarbohydreatPercentEventHandler OnCarbohydreatPercentChanged;

    /// <summary>
    /// 肉値変化イベントのデリゲート
    /// </summary>
    /// <param name="meatPercent">肉の割合</param>
    public delegate void MeatPercentEventHandler(float meatPercent);
    public event MeatPercentEventHandler OnMeatPercentChanged;

    /// <summary>
    /// 魚値変化イベントのデリゲート
    /// </summary>
    /// <param name="fishPercent">魚の割合</param>
    public delegate void FishPercentEventHandler(float fishPercent);
    public event FishPercentEventHandler OnFishPercentChanged;

    /// <summary>
    /// 野菜値変化イベントのデリゲート
    /// </summary>
    /// <param name="vegetablePercent">野菜の割合</param>
    public delegate void VegetablePercentEventHandler(float vegetablePercent);
    public event VegetablePercentEventHandler OnVegetablePercentChanged;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        //属性値初期化
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
    }
    #endregion

    #region public method
    /// <summary>
    /// スコア増加
    /// </summary>
    /// <param name="amount">増加値</param>
    public void AddScore(int amount)
    {
        _score += amount;
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
        //炭水化物値
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;

        //肉値
        _meatAmount += meat;
        _elementSum += meat;

        //魚値
        _fishAmount += fish;
        _elementSum += fish;

        //野菜値
        _vegetableAmount += vegetable;
        _elementSum += vegetable;

        ElementPercentage();
    }

    /// <summary>
    /// 属性値の割合算出
    /// </summary>
    public void ElementPercentage()
    {
        //炭水化物
        _carbohydreatPercent = _carbohydrateAmount / _elementSum;
        //イベント
        if (OnCarbohydreatPercentChanged != null)
        {
            OnCarbohydreatPercentChanged.Invoke(_carbohydreatPercent);
        }

        //肉
        _meatPercent = _meatAmount / _elementSum;
        //イベント
        if (OnMeatPercentChanged != null)
        {
            OnMeatPercentChanged.Invoke(_meatPercent);
        }

        //魚
        _fishPercent = _fishAmount / _elementSum;
        //イベント
        if (OnFishPercentChanged != null)
        {
            OnFishPercentChanged.Invoke(_fishPercent);
        }

        //野菜
        _vegetablePercent = _vegetableAmount / _elementSum;
        //イベント
        if (OnVegetablePercentChanged != null)
        {
            OnVegetablePercentChanged.Invoke(_vegetablePercent);
        }
    }

    /// <summary>
    /// 操作可能かどうかを切り替える
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
