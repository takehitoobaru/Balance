using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpawner : MonoBehaviour
{
    #region serialize
    [Tooltip("落下物のプレハブ")]
    [SerializeField]
    private GameObject[] _prefabs = default;

    [Tooltip("生成位置の最小")]
    [SerializeField]
    private float _minPos = -8;

    [Tooltip("生成位置の最大")]
    [SerializeField]
    private float _maxPos = 8;

    [Tooltip("待ち時間")]
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
    /// 生成位置を決める
    /// </summary>
    /// <returns>生成位置</returns>
    private Vector2 SetSpawnPos()
    {
        float rand = Random.Range(_minPos, _maxPos);
        Vector2 pos = new Vector2(rand, transform.position.y);
        return pos;
    }

    /// <summary>
    /// 落下物の生成
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
    /// 落下物をスポーンさせるコルーチン
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
