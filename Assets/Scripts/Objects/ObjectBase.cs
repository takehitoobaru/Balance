using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class ObjectBase : MonoBehaviour, IGetable
{
    #region property
    public int ScoreAmount => _scoreAmount;
    public int CarbohydreatAmount => _carbohydreatAmount;
    public int MeatAmount => _meatAmount;
    public int FishAmount => _fishAmount;
    public int VegetableAmount => _vegetableAmount;
    #endregion

    #region serialize
    [Tooltip("オブジェクトデータ")]
    [SerializeField]
    private ObjectData _objectData = default;

    [SerializeField]
    protected int _fallSpeed = 10;
    #endregion

    #region protected
    /// <summary>スコア値</summary>
    protected int _scoreAmount;
    /// <summary>炭水化物値</summary>
    protected int _carbohydreatAmount;
    /// <summary>肉値</summary>
    protected int _meatAmount;
    /// <summary>魚値</summary>
    protected int _fishAmount;
    /// <summary>野菜値</summary>
    protected int _vegetableAmount;
    /// <summary>コライダー</summary>
    protected BoxCollider2D _col;
    /// <summary>剛体</summary>
    protected Rigidbody2D _rb;
    #endregion

    #region unity methods
    protected virtual void Awake()
    {
        _scoreAmount = _objectData.ScoreAmount;
        _carbohydreatAmount = _objectData.Carbohydreat;
        _meatAmount = _objectData.MeatAmount;
        _fishAmount = _objectData.FishAmount;
        _vegetableAmount = _objectData.VegetableAmount;
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに接触したら
        if (collision.CompareTag("Player"))
        {
            Get(ScoreAmount, CarbohydreatAmount, MeatAmount, FishAmount, VegetableAmount);
            Destroy(gameObject);
        }
    }
    #endregion

    #region public method
    /// <summary>
    /// 取得
    /// </summary>
    /// <param name="scoreAmount">スコア値</param>
    /// <param name="carbohydreatAmount">炭水化物値</param>
    /// <param name="meatAmount">肉値</param>
    /// <param name="fishAmount">魚値</param>
    /// <param name="vegetableAmount">野菜値</param>
    public void Get(int scoreAmount, int carbohydreatAmount, int meatAmount, int fishAmount, int vegetableAmount)
    {
        GameManager.Instance.AddScore(scoreAmount);
        GameManager.Instance.AddElement(carbohydreatAmount, meatAmount, fishAmount, vegetableAmount);
    }
    #endregion

    #region private method
    #endregion
}
