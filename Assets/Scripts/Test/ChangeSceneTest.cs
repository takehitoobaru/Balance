using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �}���`�V�[���G�f�B�e�B���O�̃e�X�g�p
/// </summary>
public class ChangeSceneTest : MonoBehaviour
{
    #region property
    #endregion

    #region serialize
    [SerializeField]
    private string _currentSceneName = "SampleScene";
    [SerializeField]
    private string _nextSceneName = "Test";

    #endregion

    #region private
    #endregion

    #region Constant
    #endregion

    #region Event
    #endregion

    #region unity methods
    private void Awake()
    {
    }

    private void Start()
    {

    }

    private void Update()
    {
        //�G���^�[�L�[�ŃV�[���؂�ւ�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneController.Instance.ChangeScene(_currentSceneName, _nextSceneName);
        }
    }
    #endregion

    #region public method
    #endregion

    #region private method
    #endregion
}
