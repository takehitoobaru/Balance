using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �G�t�F�N�g
/// </summary>
public class Effect : MonoBehaviour
{
    #region serialize
    [Tooltip("�X�R�A�A�b�v���ǂ���")]
    [SerializeField]
    private bool _isScoreUp = true;
    #endregion

    #region private method
    private PlayerController _player;
    #endregion

    #region unity methods
    private void Update()
    {
        if (InGameManager.Instance.CanPlay == true)
        {
            transform.position = _player.transform.position;
        }
        else
        {
            ObjectPool.Instance.ReleaseGameObject(gameObject);
        }
    }

    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (_isScoreUp == true)
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.ScoreUpSE);
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.ScoreDownSE);
        }
    }

    private void OnParticleSystemStopped()
    {
        ObjectPool.Instance.ReleaseGameObject(gameObject);
    }
    #endregion

    #region public method
    public void AnimEnd()
    {
        ObjectPool.Instance.ReleaseGameObject(gameObject);
    }
    #endregion
}
