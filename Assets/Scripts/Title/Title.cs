using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g����ʂł̏���
/// </summary>
public class Title : MonoBehaviour
{
    #region unity methods
    private void Update()
    {
        //�������͂��ꂽ��
        if (Input.anyKeyDown)
        {
            //InGame�V�[����
            SceneController.Instance.ChangeScene(SceneName.TitleScene, SceneName.InGameScene);
        }
    }
    #endregion
}
