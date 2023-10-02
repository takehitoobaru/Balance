using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの管理
/// </summary>
public class SceneController : SingletonMonoBehaviour<SceneController>
{
    #region property
    #endregion

    #region serialize
    #endregion

    #region private
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
    #endregion

    #region public method
    /// <summary>
    /// シーンを切り替える
    /// </summary>
    /// <param name="currentScene">現在のシーン</param>
    /// <param name="nextScene">次のシーン</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        //シーンをロードしてアクティブに切り替え
        var next = SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive);
        next.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
        //現在のシーンを削除
        SceneManager.UnloadSceneAsync(currentScene);
    }
    #endregion

    #region private method
    #endregion
}
