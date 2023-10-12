using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の管理
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public int Score => _score;
    public int HighScore => _highScore;
    #endregion

    #region private
    /// <summary>スコア格納用</summary>
    private int _score = 0;
    /// <summary>ハイスコア</summary>
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
    /// スコア格納、ハイスコア判定
    /// </summary>
    /// <param name="score">スコア</param>
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
