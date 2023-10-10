using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������
/// </summary>
public class Spawner : MonoBehaviour
{
    #region Property
    public GameObject[] FoodPrefabs => _foodPrefabs;
    public GameObject[] NotFoodPrefabs => _notFoodPrefabs;
    public bool IsWait => _isWait;
    public Vector2 SpawnPos => _spawnPos;
    #endregion

    #region serialize
    [Tooltip("�H���̃v���n�u")]
    [SerializeField]
    private GameObject[] _foodPrefabs = default;

    [Tooltip("�H���ȊO�̃v���n�u")]
    [SerializeField]
    private GameObject[] _notFoodPrefabs = default;

    [Tooltip("�X�|�[���Ԋu")]
    [SerializeField]
    private float _spawnCoolTime = 1.5f;
    #endregion

    #region private
    /// <summary>�ҋ@�����ǂ���</summary>
    private bool _isWait = false;
    /// <summary>context</summary>
    private SpawnerStateContext _context;
    /// <summary>�����ʒu</summary>
    private Vector2 _spawnPos;
    /// <summary>�ŏ������_���ʒu</summary>
    private float _minPos = -8;
    /// <summary>�ő僉���_���ʒu</summary>
    private float _maxPos = 8;
    #endregion

    #region unity methods
    private void Awake()
    {
        _context = new SpawnerStateContext();
        _context.Init(this, SpawnerState.Idle);
    }

    private void Update()
    {
        if (InGameManager.Instance.CanPlay == false) return;
        _context.Update();
    }
    #endregion

    #region public method
    /// <summary>
    /// �ҋ@
    /// </summary>
    public void Idle()
    {
        _context.ChangeState(SpawnerState.Idle);
    }

    /// <summary>
    /// �H������
    /// </summary>
    public void FoodSpawn()
    {
        _context.ChangeState(SpawnerState.FoodSpawn);
    }

    /// <summary>
    /// ��H������
    /// </summary>
    public void NotFoodSpawn()
    {
        _context.ChangeState(SpawnerState.NotFoodSpawn);
    }

    /// <summary>
    /// �҂��߂̃R���[�`�����X�^�[�g����
    /// </summary>
    public void Wait()
    {
        StartCoroutine(WaitCoolTimeCoroutine());
    }

    /// <summary>
    /// �X�|�[���|�W�V���������߂�
    /// </summary>
    public void SetSpawnPos()
    {
        float randPos = Random.Range(_minPos, _maxPos);
        _spawnPos = new Vector2(randPos, transform.position.y);
    }
    #endregion

    /// <summary>
    /// ��莞�ԑ҂�
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitCoolTimeCoroutine()
    {
        _isWait = true;
        yield return new WaitForSeconds(_spawnCoolTime);
        _isWait = false;
    }
}
