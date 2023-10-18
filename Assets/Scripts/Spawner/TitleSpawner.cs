using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpawner : MonoBehaviour
{
    #region serialize
    [Tooltip("�������̃v���n�u")]
    [SerializeField]
    private GameObject[] _prefabs = default;

    [Tooltip("�����ʒu�̍ŏ�")]
    [SerializeField]
    private float _minPos = -8;

    [Tooltip("�����ʒu�̍ő�")]
    [SerializeField]
    private float _maxPos = 8;

    [Tooltip("�҂�����")]
    [SerializeField]
    private float _waitTime = 2f;
    #endregion

    #region unity methods
    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
    #endregion

    #region private method
    /// <summary>
    /// �����ʒu�����߂�
    /// </summary>
    /// <returns>�����ʒu</returns>
    private Vector2 SetSpawnPos()
    {
        float rand = Random.Range(_minPos, _maxPos);
        Vector2 pos = new Vector2(rand, transform.position.y);
        return pos;
    }

    /// <summary>
    /// �������̐���
    /// </summary>
    private void Spawn()
    {
        Vector2 spawnPos = SetSpawnPos();
        int rand = Random.Range(0, _prefabs.Length);
        ObjectPool.Instance.GetGameObject(_prefabs[rand], spawnPos);
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// ���������X�|�[��������R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_waitTime);
        }
    }
    #endregion
}
