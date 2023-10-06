using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// �X���C�_�[�̃o�����[�ύX
    /// </summary>
    /// <param name="percent">�����l�̊���</param>
    private void ChangeSlider(float percent)
    {
        _slider.value = percent;
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
