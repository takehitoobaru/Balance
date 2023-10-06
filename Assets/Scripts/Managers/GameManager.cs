using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̂̊Ǘ�
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region property
    public Vector2 ScreenLeftBottom => _screenLeftBottom;
    public Vector2 ScreenRightTop => _screenRightTop;
    #endregion

    #region private
    /// <summary>�n�C�X�R�A</summary>
    private int _highScore = 0;
    /// <summary>��ʍ���</summary>
    private Vector2 _screenLeftBottom;
    /// <summary>��ʉE��</summary>
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
