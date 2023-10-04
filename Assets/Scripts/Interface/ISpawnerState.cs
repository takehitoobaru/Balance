/// <summary>
/// スポナーのStateインターフェース
/// </summary>
public interface ISpawnerState
{
    #region property
    SpawnerState SpawnerState { get; }
    #endregion

    #region public method
    /// <summary>
    /// 状態開始時に実行
    /// </summary>
    public void Entry();

    /// <summary>
    /// フレームごとに実行
    /// </summary>
    public void Update();

    /// <summary>
    /// 状態終了時に実行
    /// </summary>
    public void Exit();
    #endregion
}

/// <summary>
/// スポナーの状態
/// </summary>
public enum SpawnerState
{
    /// <summary>待機</summary>
    Idle,
    /// <summary>食物をスポーン</summary>
    FoodSpawn,
    /// <summary>食物以外をスポーン</summary>
    NotFoodSpawn
}
