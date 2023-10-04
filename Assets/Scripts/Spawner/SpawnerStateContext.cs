using System.Collections.Generic;

public class SpawnerStateContext
{
    #region private
    /// <summary>現在の状態</summary>
    private ISpawnerState _currentState;
    /// <summary>直前の状態</summary>
    private ISpawnerState _previousState;
    /// <summary>状態のテーブル</summary>
    private Dictionary<SpawnerState, ISpawnerState> _stateTable;
    #endregion

    #region public method
    public void Init(Spawner spawner,SpawnerState initState)
    {
        if (_stateTable != null) return;

        Dictionary<SpawnerState, ISpawnerState> table = new()
        {
            { SpawnerState.Idle, new SpawnerStateIdle(spawner) },
            { SpawnerState.FoodSpawn, new SpawnerStateFoodSpawn(spawner) },
            { SpawnerState.NotFoodSpawn, new SpawnerStateNotFoodSpawn(spawner) },
        };
        _stateTable = table;
        _currentState = _stateTable[initState];
        ChangeState(initState);
    }

    public void ChangeState(SpawnerState next)
    {
        if (_stateTable == null) return;
        if (_currentState == null || _currentState.SpawnerState == next) return;
        var nextState = _stateTable[next];
        _previousState = _currentState;
        _previousState?.Exit();
        _currentState = nextState;
        _currentState.Entry();
    }

    public void Update()
    {
        _currentState?.Update();
    }
    #endregion
}
