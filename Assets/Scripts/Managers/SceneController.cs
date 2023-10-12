using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���̊Ǘ�
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
    /// �^�C�g���V�[�����A�N�e�B�u�ɂ���
    /// </summary>
    public void LoadTitleScene()
    {
        var title = SceneManager.LoadSceneAsync(SceneName.TitleScene, LoadSceneMode.Additive);
        title.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName.TitleScene));
    }

    /// <summary>
    /// �V�[����؂�ւ���
    /// </summary>
    /// <param name="currentScene">���݂̃V�[��</param>
    /// <param name="nextScene">���̃V�[��</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        //���݂̃V�[�����폜
        SceneManager.UnloadSceneAsync(currentScene);
        //�V�[�������[�h���ăA�N�e�B�u�ɐ؂�ւ�
        var next = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        next.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
    }
    #endregion
}
