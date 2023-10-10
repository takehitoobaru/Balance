using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 落下物のベースクラス
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class FallObjectBase : MonoBehaviour, IGetable
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

    [Tooltip("落下速度")]
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
        //各値をデータから取得
        _scoreAmount = _objectData.ScoreAmount;
        _carbohydreatAmount = _objectData.Carbohydreat;
        _meatAmount = _objectData.MeatAmount;
        _fishAmount = _objectData.FishAmount;
        _vegetableAmount = _objectData.VegetableAmount;

        //コンポーネント取得
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //プレイ可能でないならプールに戻る
        if(InGameManager.Instance.CanPlay == false)
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに接触したら
        if (collision.CompareTag("Player"))
        {
            Get(ScoreAmount, CarbohydreatAmount, MeatAmount, FishAmount, VegetableAmount);
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
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
        InGameManager.Instance.AddScore(scoreAmount);
        InGameManager.Instance.AddElement(carbohydreatAmount, meatAmount, fishAmount, vegetableAmount);
    }
    #endregion
}
