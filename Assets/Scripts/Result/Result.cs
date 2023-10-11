using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// ���U���g
/// </summary>
public class Result : MonoBehaviour
{
    #region serialize
    [Tooltip("�X�R�A�e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _scoreText = default;

    [Tooltip("�n�C�X�R�A�e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _highScoreText = default;
    #endregion

    #region private
    /// <summary>�V�[���J�ډ\���ǂ���</summary>
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
        //�X�R�A�\��
        for (int i = 0; i <= GameManager.Instance.Score; i++)
        {
            _scoreText.text = "Score:" + i.ToString();
            yield return null;
        }
        yield return new WaitForSeconds(1);

        //�n�C�X�R�A�\��
        _highScoreText.text = "HighScore:" + GameManager.Instance.HighScore;

        //�V�[���J�ډ\��
        _canChangeScene = true;
    }
    #endregion
}
