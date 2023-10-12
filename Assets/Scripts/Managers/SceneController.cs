using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの管理
/// </summary>
public class SceneController : SingletonMonoBehaviour<SceneController>
{
    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region public method
    /// <summary>
    /// タイトルシーンをアクティブにする
    /// </summary>
    public void LoadTitleScene()
    {
        var title = SceneManager.LoadSceneAsync(SceneName.TitleScene, LoadSceneMode.Additive);
        title.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName.TitleScene));
    }

    /// <summary>
    /// シーンを切り替える
    /// </summary>
    /// <param name="currentScene">現在のシーン</param>
    /// <param name="nextScene">次のシーン</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        //現在のシーンを削除
        SceneManager.UnloadSceneAsync(currentScene);
        //シーンをロードしてアクティブに切り替え
        var next = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        next.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
    }
    #endregion
}
