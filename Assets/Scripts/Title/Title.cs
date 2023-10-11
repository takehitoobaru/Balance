using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// �^�C�g����ʂł̏���
/// </summary>
public class Title : MonoBehaviour
{
    #region serialize
    [Tooltip("�n�C�X�R�A�e�L�X�g")]
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
        //�������͂��ꂽ��
        if (Input.anyKeyDown)
        {
            StartCoroutine(ChangeSceneCoroutine());
        }
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// �V�[���؂�ւ��p�̃R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeSceneCoroutine()
    {
        //SE�Đ�
        AudioManager.Instance.PlaySE(AudioManager.Instance.EnterSE);

        //SE�Đ��I����҂�
        float time = AudioManager.Instance.EnterSE.length;
        yield return new WaitForSeconds(time);

        //BGM�X�g�b�v
        AudioManager.Instance.StopBGM();

        //InGame�V�[����
        SceneController.Instance.ChangeScene(SceneName.TitleScene, SceneName.InGameScene);
    }
    #endregion
}
