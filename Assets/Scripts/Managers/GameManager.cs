using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の管理
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public Vector2 ScreenLeftBottom => _screenLeftBottom;
    public Vector2 ScreenRightTop => _screenRightTop;
    #endregion

    #region private
    /// <summary>ハイスコア</summary>
    private int _highScore = 0;
    /// <summary>画面左下</summary>
    private Vector2 _screenLeftBottom;
    /// <summary>画面右上</summary>
    private Vector2 _screenRightTop;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
        _screenRightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
