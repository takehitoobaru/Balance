using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// リザルト
/// </summary>
public class Result : MonoBehaviour
{
    #region serialize
    [Tooltip("スコアテキスト")]
    [SerializeField]
    private TextMeshProUGUI _scoreText = default;

    [Tooltip("ハイスコアテキスト")]
    [SerializeField]
    private TextMeshProUGUI _highScoreText = default;

    [Tooltip("ボタン押下を促すテキスト")]
    [SerializeField]
    private TextMeshProUGUI _pressAnyKeyText = default;
    #endregion

    #region private
    /// <summary>シーン遷移可能かどうか</summary>
    private bool _canChangeScene = false;
    #endregion

    #region unity methods
    private void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.Instance.ResultBGM);
        StartCoroutine(ResultCoroutine());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_canChangeScene == false) return;
            AudioManager.Instance.StopBGM();
            SceneController.Instance.ChangeScene(SceneName.ResultScene, SceneName.TitleScene);
        }
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// リザルト表示用のコルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator ResultCoroutine()
    {
        //スコア表示
        _scoreText.text = "Score:" + GameManager.Instance.Score.ToString();

        yield return new WaitForSeconds(1);

        //ハイスコア表示
        _highScoreText.text = "HighScore:" + GameManager.Instance.HighScore;

        yield return new WaitForSeconds(0.5f);

        _pressAnyKeyText.gameObject.SetActive(true);

        //シーン遷移可能に
        _canChangeScene = true;
    }
    #endregion
}
