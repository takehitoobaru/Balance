using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// �����l�\���p�X���C�_�[�̏���
/// </summary>
[RequireComponent(typeof(Slider))]
public class ElementSlider : MonoBehaviour
{
    #region serialize
    [Tooltip("�����̎��")]
    [SerializeField]
    private ElementType _elementType = default;

    [Tooltip("�e�L�X�g")]
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
        //�^�C�v�ɉ������C�x���g�ɓo�^
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
    /// �X���C�_�[�̃o�����[�ύX
    /// </summary>
    /// <param name="percent">�����l�̊���</param>
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
/// �H���̃^�C�v
/// </summary>
public enum ElementType
{
    Carbohydreat,
    Meat,
    Fish,
    Vegetable
}
