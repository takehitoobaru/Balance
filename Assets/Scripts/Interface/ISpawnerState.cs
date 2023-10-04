/// <summary>
/// �X�|�i�[��State�C���^�[�t�F�[�X
/// </summary>
public interface ISpawnerState
{
    #region property
    SpawnerState SpawnerState { get; }
    #endregion

    #region public method
    /// <summary>
    /// ��ԊJ�n���Ɏ��s
    /// </summary>
    public void Entry();

    /// <summary>
    /// �t���[�����ƂɎ��s
    /// </summary>
    public void Update();

    /// <summary>
    /// ��ԏI�����Ɏ��s
    /// </summary>
    public void Exit();
    #endregion
}

/// <summary>
/// �X�|�i�[�̏��
/// </summary>
public enum SpawnerState
{
    /// <summary>�ҋ@</summary>
    Idle,
    /// <summary>�H�����X�|�[��</summary>
    FoodSpawn,
    /// <summary>�H���ȊO���X�|�[��</summary>
    NotFoodSpawn
}
