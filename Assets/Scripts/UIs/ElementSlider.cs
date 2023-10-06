using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 属性値表示用スライダーの処理
/// </summary>
[RequireComponent(typeof(Slider))]
public class ElementSlider : MonoBehaviour
{
    #region serialize
    [Tooltip("属性の種類")]
    [SerializeField]
    private ElementType _elementType = default;
    #endregion

    #region private
    private Slider _slider;
    #endregion

    #region unity methods
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        //タイプに応じたイベントに登録
        switch (_elementType)
        {
            case ElementType.Carbohydreat:
                InGameManager.Instance.OnCarbohydreatPercentChanged += ChangeSlider;
                break;
            case ElementType.Meat:
                InGameManager.Instance.OnMeatPercentChanged += ChangeSlider;
                break;
            case ElementType.Fish:
                InGameManager.Instance.OnFishPercentChanged += ChangeSlider;
                break;
            case ElementType.Vegetable:
                InGameManager.Instance.OnVegetablePercentChanged += ChangeSlider;
                break;
            default:
                break;
        }
        InGameManager.Instance.ElementPercentage();
    }
    #endregion

    #region private method
    /// <summary>
    /// スライダーのバリュー変更
    /// </summary>
    /// <param name="percent">属性値の割合</param>
    private void ChangeSlider(float percent)
    {
        _slider.value = percent;
    }
    #endregion
}

/// <summary>
/// 食物のタイプ
/// </summary>
public enum ElementType
{
    Carbohydreat,
    Meat,
    Fish,
    Vegetable
}
