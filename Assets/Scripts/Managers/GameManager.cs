using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̂̊Ǘ�
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public int Score => _score;
    public int HighScore => _highScore;
    #endregion

    #region private
    /// <summary>�X�R�A�i�[�p</summary>
    private int _score = 0;
    /// <summary>�n�C�X�R�A</summary>
    private int _highScore = 0;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SceneController.Instance.LoadTitleScene();
    }
    #endregion

    #region public method
    /// <summary>
    /// �X�R�A�i�[�A�n�C�X�R�A����
    /// </summary>
    /// <param name="score">�X�R�A</param>
    public void SetScore(int score)
    {
        _score = score;

        if(_highScore < _score)
        {
            _highScore = _score;
        }
    }
    #endregion

    #region private method
    #endregion
}
