using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�f�[�^��ScriptableObject
/// </summary>
[CreateAssetMenu(menuName = "MyScriptable/ObjectData")]
public class ObjectData : ScriptableObject
{
    #region property
    public ObjectType ObjectType => _objectType;
    public int ScoreAmount => _scoreAmount;
    public int Carbohydreat => _carbohydreatAmount;
    public int MeatAmount => _meatAmount;
    public int FishAmount => _fishAmount;
    public int VegetableAmount => _vegetableAmount;
    #endregion

    #region serialize
    [Tooltip("�I�u�W�F�N�g�̎��")]
    [SerializeField]
    private ObjectType _objectType = default;

    [Tooltip("�X�R�A�l")]
    [SerializeField]
    private int _scoreAmount = 0;

    [Tooltip("�Y�������l")]
    [SerializeField]
    private int _carbohydreatAmount = 0;

    [Tooltip("���l")]
    [SerializeField]
    private int _meatAmount = 0;

    [Tooltip("���l")]
    [SerializeField]
    private int _fishAmount = 0;

    [Tooltip("��ؒl")]
    [SerializeField]
    private int _vegetableAmount = 0;
    #endregion
}

/// <summary>
/// �I�u�W�F�N�g�̎��
/// </summary>
public enum ObjectType
{
    /// <summary>�H��</summary>
    Food,
    /// <summary>�H���ȊO</summary>
    NotFood
}
