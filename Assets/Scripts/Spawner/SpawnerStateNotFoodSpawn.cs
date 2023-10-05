using UnityEngine;

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
        _spawner.SetSpawnPos();
        int rand = Random.Range(0, _spawner.NotFoodPrefabs.Length);
        ObjectPool.Instance.GetGameObject(_spawner.NotFoodPrefabs[rand], _spawner.SpawnPos);
    }

    public void Update()
    {
        _spawner.Idle();
    }

    public void Exit()
    {

    }
    #endregion
}
