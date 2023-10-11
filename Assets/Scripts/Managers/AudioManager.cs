using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音の管理
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
    [Tooltip("決定音")]
    [SerializeField]
    private AudioClip _enterSE = default;

    [Tooltip("カウントダウン音")]
    [SerializeField]
    private AudioClip _countDownSE = default;

    [Tooltip("スコアアップ音")]
    [SerializeField]
    private AudioClip _scoreUpSE = default;

    [Tooltip("スコアダウン音")]
    [SerializeField]
    private AudioClip _scoreDownSE = default;

    [Tooltip("タイトルBGM")]
    [SerializeField]
    private AudioClip _titleBGM = default;

    [Tooltip("インゲームBGM")]
    [SerializeField]
    private AudioClip _inGameBGM = default;

    [Tooltip("リザルトBGM")]
    [SerializeField]
    private AudioClip _resultBGM = default;

    [Tooltip("オーディオソース")]
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
    /// SEの再生
    /// </summary>
    /// <param name="clip">再生するクリップ</param>
    public void PlaySE(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// BGMの再生
    /// </summary>
    /// <param name="clip">再生するクリップ</param>
    public void PlayBGM(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    public void StopBGM()
    {
        _audioSource.Stop();
    }
    #endregion
}
