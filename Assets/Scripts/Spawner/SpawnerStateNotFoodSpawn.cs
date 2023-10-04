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

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
    #endregion
}
