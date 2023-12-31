using UnityEngine;

/// <summary>
/// 待機状態
/// </summary>
public class SpawnerStateIdle : ISpawnerState
{
    #region property
    public SpawnerState SpawnerState => SpawnerState.Idle;
    #endregion

    #region private
    private Spawner _spawner;
    private int _randMin = 0;
    private int _randMax = 100;
    #endregion

    #region public method
    public SpawnerStateIdle(Spawner spawner) => _spawner = spawner;
    public void Entry()
    {
        _spawner.Wait();
    }

    public void Update()
    {
        //待機状態が解けたなら
        if (_spawner.IsWait == false)
        {
            int rand = Random.Range(_randMin, _randMax);
            if (rand < 80)
            {
                _spawner.FoodSpawn();
            }
            else
            {
                _spawner.NotFoodSpawn();
            }

        }
    }
    #endregion
}
