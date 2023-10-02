using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���̊Ǘ�
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
    /// �V�[����؂�ւ���
    /// </summary>
    /// <param name="currentScene">���݂̃V�[��</param>
    /// <param name="nextScene">���̃V�[��</param>
    public void ChangeScene(string currentScene,string nextScene)
    {
        //�V�[�������[�h���ăA�N�e�B�u�ɐ؂�ւ�
        var next = SceneManager.LoadSceneAsync(currentScene, LoadSceneMode.Additive);
        next.completed += x => SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));
        //���݂̃V�[�����폜
        SceneManager.UnloadSceneAsync(currentScene);
    }
    #endregion

    #region private method
    #endregion
}
