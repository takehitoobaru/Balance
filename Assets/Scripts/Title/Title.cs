using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面での処理
/// </summary>
public class Title : MonoBehaviour
{
    #region unity methods
    private void Update()
    {
        //何か入力されたら
        if (Input.anyKeyDown)
        {
            //InGameシーンへ
            SceneController.Instance.ChangeScene(SceneName.TitleScene, SceneName.InGameScene);
        }
    }
    #endregion
}
