using UnityEngine;

/// <summary>
/// 非食物生成状態
/// </summary>
public class SpawnerStateNotFoodSpawn : ISpawnerState
{
    #region property
    public SpawnerState SpawnerState => SpawnerState.NotFoodSpawn;
    #endregion

    #region private
    private Spawner _spawner;
    #endregion

    #region public method
    public SpawnerStateNotFoodSpawn(Spawner spawner) => _spawner = spawner;
    public void Entry()
    {
        //生成位置決定
        _spawner.SetSpawnPos();
        //生成
        int rand = Random.Range(0, _spawner.NotFoodPrefabs.Length);
        ObjectPool.Instance.GetGameObject(_spawner.NotFoodPrefabs[rand], _spawner.SpawnPos);
    }

    public void Update()
    {
        _spawner.Idle();
    }
    #endregion
}
