using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #region unity methods
    private void OnEnable()
    {
        if(_isScoreUp == true)
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.ScoreUpSE);
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.ScoreDownSE);
        }
    }
    #endregion

    #region public method
    public void AnimEnd()
    {
        ObjectPool.Instance.ReleaseGameObject(gameObject);
    }
    #endregion
}
