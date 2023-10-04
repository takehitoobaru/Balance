using UnityEngine;

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
        _spawner.SetSpawnPos();
        int rand = Random.Range(0, _spawner.FoodPrefabs.Length);
        ObjectPool.Instance.GetGameObject(_spawner.FoodPrefabs[rand], _spawner.SpawnPos);
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
