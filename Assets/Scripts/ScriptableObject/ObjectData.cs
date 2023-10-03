using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトデータのScriptableObject
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
    [Tooltip("オブジェクトの種類")]
    [SerializeField]
    private ObjectType _objectType = default;

    [Tooltip("スコア値")]
    [SerializeField]
    private int _scoreAmount = 0;

    [Tooltip("炭水化物値")]
    [SerializeField]
    private int _carbohydreatAmount = 0;

    [Tooltip("肉値")]
    [SerializeField]
    private int _meatAmount = 0;

    [Tooltip("魚値")]
    [SerializeField]
    private int _fishAmount = 0;

    [Tooltip("野菜値")]
    [SerializeField]
    private int _vegetableAmount = 0;
    #endregion
}

/// <summary>
/// オブジェクトの種類
/// </summary>
public enum ObjectType
{
    /// <summary>食物</summary>
    Food,
    /// <summary>食物以外</summary>
    NotFood
}
