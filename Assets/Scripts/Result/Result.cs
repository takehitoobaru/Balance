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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_canChangeScene == false) return;
            AudioManager.Instance.StopBGM();
            SceneController.Instance.ChangeScene(SceneName.ResultScene, SceneName.TitleScene);
        }
    }
    #endregion

    #region coroutine method
    private IEnumerator ResultCoroutine()
    {
        //スコア表示
        for (int i = 0; i <= GameManager.Instance.Score; i++)
        {
            _scoreText.text = "Score:" + i.ToString();
            yield return null;
        }
        yield return new WaitForSeconds(1);

        //ハイスコア表示
        _highScoreText.text = "HighScore:" + GameManager.Instance.HighScore;

        //シーン遷移可能に
        _canChangeScene = true;
    }
    #endregion
}
