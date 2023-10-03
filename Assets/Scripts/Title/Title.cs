using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    #region unity methods
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneController.Instance.ChangeScene(SceneName.TitleScene, SceneName.InGameScene);
        }
    }
    #endregion
}
