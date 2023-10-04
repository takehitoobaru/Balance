public class SpawnerStateIdle : ISpawnerState
{
    #region property
    public SpawnerState SpawnerState => SpawnerState.Idle;
    #endregion

    #region private
    private Spawner _spawner;
    #endregion

    #region public method
    public SpawnerStateIdle(Spawner spawner) => _spawner = spawner;
    public void Entry()
    {
        _spawner.Wait();
    }

    public void Update()
    {
        if(_spawner.IsWait == false)
        {
            _spawner.FoodSpawn();
        }
    }

    public void Exit()
    {

    }
    #endregion
}
