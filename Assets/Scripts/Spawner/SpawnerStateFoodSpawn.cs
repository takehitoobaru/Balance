using UnityEngine;

/// <summary>
/// 食物生成状態
/// </summary>
public class SpawnerStateFoodSpawn : ISpawnerState
{
    #region property
    public SpawnerState SpawnerState => SpawnerState.FoodSpawn;
    #endregion

    #region private
    private Spawner _spawner;
    #endregion

    #region public method
    public SpawnerStateFoodSpawn(Spawner spawner) => _spawner = spawner;

    public void Entry()
    {
        //生成位置決定
        _spawner.SetSpawnPos();
        //生成
        int rand = Random.Range(0, _spawner.FoodPrefabs.Length);
        ObjectPool.Instance.GetGameObject(_spawner.FoodPrefabs[rand], _spawner.SpawnPos);
    }

    public void Update()
    {
        _spawner.Idle();
    }
    #endregion
}
