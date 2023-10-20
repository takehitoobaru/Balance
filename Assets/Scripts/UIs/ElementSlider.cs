using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [Tooltip("テキスト")]
    [SerializeField]
    private TextMeshProUGUI _text = default;
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
                InGameManager.Instance.OnCarbohydreatPercentChanged += ChangeText;
                break;
            case ElementType.Meat:
                InGameManager.Instance.OnMeatPercentChanged += ChangeSlider;
                InGameManager.Instance.OnMeatPercentChanged += ChangeText;
                break;
            case ElementType.Fish:
                InGameManager.Instance.OnFishPercentChanged += ChangeSlider;
                InGameManager.Instance.OnFishPercentChanged += ChangeText;
                break;
            case ElementType.Vegetable:
                InGameManager.Instance.OnVegetablePercentChanged += ChangeSlider;
                InGameManager.Instance.OnVegetablePercentChanged += ChangeText;
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

    private void ChangeText(float percent)
    {
        var amount = percent * 100;
        _text.text = amount.ToString("F1");
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
