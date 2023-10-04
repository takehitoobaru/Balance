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
    private bool _isWait = false;
    private SpawnerStateContext _context;
    private Vector2 _spawnPos;
    private float _minPos = -8;
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
        _context.Update();
    }
    #endregion

    #region public method
    public void Idle()
    {
        _context.ChangeState(SpawnerState.Idle);
    }

    public void FoodSpawn()
    {
        _context.ChangeState(SpawnerState.FoodSpawn);
    }

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
