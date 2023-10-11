using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̊Ǘ�
/// </summary>
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    #region property
    public AudioClip EnterSE => _enterSE;
    public AudioClip CountDownSE => _countDownSE;
    public AudioClip ScoreUpSE => _scoreUpSE;
    public AudioClip ScoreDownSE => _scoreDownSE;
    public AudioClip TitleBGM => _titleBGM;
    public AudioClip InGameBGM => _inGameBGM;
    public AudioClip ResultBGM => _resultBGM;
    #endregion

    #region serialize
    [Tooltip("���艹")]
    [SerializeField]
    private AudioClip _enterSE = default;

    [Tooltip("�J�E���g�_�E����")]
    [SerializeField]
    private AudioClip _countDownSE = default;

    [Tooltip("�X�R�A�A�b�v��")]
    [SerializeField]
    private AudioClip _scoreUpSE = default;

    [Tooltip("�X�R�A�_�E����")]
    [SerializeField]
    private AudioClip _scoreDownSE = default;

    [Tooltip("�^�C�g��BGM")]
    [SerializeField]
    private AudioClip _titleBGM = default;

    [Tooltip("�C���Q�[��BGM")]
    [SerializeField]
    private AudioClip _inGameBGM = default;

    [Tooltip("���U���gBGM")]
    [SerializeField]
    private AudioClip _resultBGM = default;

    [Tooltip("�I�[�f�B�I�\�[�X")]
    [SerializeField]
    private AudioSource _audioSource;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion

    #region public method
    /// <summary>
    /// SE�̍Đ�
    /// </summary>
    /// <param name="clip">�Đ�����N���b�v</param>
    public void PlaySE(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// BGM�̍Đ�
    /// </summary>
    /// <param name="clip">�Đ�����N���b�v</param>
    public void PlayBGM(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    /// <summary>
    /// BGM���~�߂�
    /// </summary>
    public void StopBGM()
    {
        _audioSource.Stop();
    }
    #endregion
}
