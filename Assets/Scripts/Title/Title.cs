using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// タイトル画面での処理
/// </summary>
public class Title : MonoBehaviour
{
    #region serialize
    [Tooltip("ハイスコアテキスト")]
    [SerializeField]
    private TextMeshProUGUI _highScoreText = default;
    #endregion

    #region unity methods
    private void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.Instance.TitleBGM);
        _highScoreText.text = "HighScore:" + GameManager.Instance.HighScore.ToString();
    }

    private void Update()
    {
        //何か入力されたら
        if (Input.anyKeyDown)
        {
            StartCoroutine(ChangeSceneCoroutine());
        }
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// シーン切り替え用のコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeSceneCoroutine()
    {
        //SE再生
        AudioManager.Instance.PlaySE(AudioManager.Instance.EnterSE);

        //SE再生終了を待つ
        float time = AudioManager.Instance.EnterSE.length;
        yield return new WaitForSeconds(time);

        //BGMストップ
        AudioManager.Instance.StopBGM();

        //InGameシーンへ
        SceneController.Instance.ChangeScene(SceneName.TitleScene, SceneName.InGameScene);
    }
    #endregion
}
