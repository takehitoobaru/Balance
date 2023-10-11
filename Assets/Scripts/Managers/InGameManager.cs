using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// ゲーム本編の管理
/// </summary>
public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public bool CanPlay => _canPlay;
    #endregion

    #region serialize
    [Tooltip("ゲームオーバーになる値　下")]
    [SerializeField]
    private float _percentMin = 0.1f;

    [Tooltip("ゲームオーバーになる値　上")]
    [SerializeField]
    private float _percentMax = 0.7f;

    [Tooltip("カウントダウンテキスト")]
    [SerializeField]
    private TextMeshProUGUI _countDownText = default;

    [Tooltip("タイムテキスト")]
    [SerializeField]
    private TextMeshProUGUI _timeText = default;

    [Tooltip("スコアテキスト")]
    [SerializeField]
    private TextMeshProUGUI _scoreText = default;

    [Tooltip("ゲーム終了時のテキスト")]
    [SerializeField]
    private TextMeshProUGUI _gameEndText = default;

    [Tooltip("パーセントを隠すパネル")]
    [SerializeField]
    private GameObject _hidePanel = default;
    #endregion

    #region private
    /// <summary>スコア</summary>
    private int _score = 0;
    /// <summary>タイム</summary>
    private float _time = 120;
    /// <summary>属性値の合計</summary>
    private float _elementSum = 0;
    /// <summary>炭水化物属性値</summary>
    private float _carbohydrateAmount = 0;
    /// <summary>肉属性値</summary>
    private float _meatAmount = 0;
    /// <summary>魚属性値</summary>
    private float _fishAmount = 0;
    /// <summary>野菜属性値</summary>
    private float _vegetableAmount = 0;
    /// <summary>炭水化物割合</summary>
    private float _carbohydreatPercent = 0;
    /// <summary>肉割合</summary>
    private float _meatPercent = 0;
    /// <summary>魚割合</summary>
    private float _fishPercent = 0;
    /// <summary>野菜割合</summary>
    private float _vegetablePercent = 0;
    /// <summary>操作できるかどうか</summary>
    private bool _canPlay = false;
    /// <summary>hidePanelをアクティブにしたかどうか</summary>
    private bool _panelInit = false;
    /// <summary>タイムアップ処理したかどうか</summary>
    private bool _timeUpInit = false;
    #endregion

    #region Constant
    /// <summary>炭水化物値の初期値</summary>
    private float CARBOHYDRATE_BASE = 25;
    /// <summary>肉値の初期値</summary>
    private float MEAT_BASE = 25;
    /// <summary>魚値の初期値</summary>
    private float FISH_BASE = 25;
    /// <summary>野菜値の初期値</summary>
    private float VEGETABLE_BASE = 25;
    #endregion

    #region Event
    /// <summary>
    /// 炭水化物値変化イベントのデリゲート
    /// </summary>
    /// <param name="carbohydreatPercent">炭水化物の割合</param>
    public delegate void CarbohydreatPercentEventHandler(float carbohydreatPercent);
    public event CarbohydreatPercentEventHandler OnCarbohydreatPercentChanged;

    /// <summary>
    /// 肉値変化イベントのデリゲート
    /// </summary>
    /// <param name="meatPercent">肉の割合</param>
    public delegate void MeatPercentEventHandler(float meatPercent);
    public event MeatPercentEventHandler OnMeatPercentChanged;

    /// <summary>
    /// 魚値変化イベントのデリゲート
    /// </summary>
    /// <param name="fishPercent">魚の割合</param>
    public delegate void FishPercentEventHandler(float fishPercent);
    public event FishPercentEventHandler OnFishPercentChanged;

    /// <summary>
    /// 野菜値変化イベントのデリゲート
    /// </summary>
    /// <param name="vegetablePercent">野菜の割合</param>
    public delegate void VegetablePercentEventHandler(float vegetablePercent);
    public event VegetablePercentEventHandler OnVegetablePercentChanged;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        //属性値初期化
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
    }

    private void Start()
    {
        //カウントダウン
        StartCoroutine(ThreeCountCoroutine());
    }

    private void Update()
    {
        //残り30秒なら
        if(_time <= 30 && _panelInit == false)
        {
            _hidePanel.SetActive(true);
            _panelInit = true;
        }

        //タイムアップなら
        if(_time <= 0 && _timeUpInit == false)
        {
            GamePlayEnd();
            _timeUpInit = true;
        }

        //プレイ可能なら処理実行
        if (CanPlay == false) return;

        //タイム経過
        _time -= Time.deltaTime;

        //テキスト更新
        _timeText.text = "Time:" + _time.ToString("F0");
        _scoreText.text = "Score:" + _score.ToString();
    }
    #endregion

    #region public method
    /// <summary>
    /// スコア増加
    /// </summary>
    /// <param name="amount">増加値</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// 属性値増加
    /// </summary>
    /// <param name="carbohydreat">炭水化物</param>
    /// <param name="meat">肉</param>
    /// <param name="fish">魚</param>
    /// <param name="vegetable">野菜</param>
    public void AddElement(int carbohydreat, int meat, int fish, int vegetable)
    {
        //炭水化物値
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;

        //肉値
        _meatAmount += meat;
        _elementSum += meat;

        //魚値
        _fishAmount += fish;
        _elementSum += fish;

        //野菜値
        _vegetableAmount += vegetable;
        _elementSum += vegetable;

        ElementPercentage();
    }

    /// <summary>
    /// 属性値の割合算出
    /// </summary>
    public void ElementPercentage()
    {
        //炭水化物
        _carbohydreatPercent = _carbohydrateAmount / _elementSum;
        //イベント
        if (OnCarbohydreatPercentChanged != null)
        {
            OnCarbohydreatPercentChanged.Invoke(_carbohydreatPercent);
        }

        //肉
        _meatPercent = _meatAmount / _elementSum;
        //イベント
        if (OnMeatPercentChanged != null)
        {
            OnMeatPercentChanged.Invoke(_meatPercent);
        }

        //魚
        _fishPercent = _fishAmount / _elementSum;
        //イベント
        if (OnFishPercentChanged != null)
        {
            OnFishPercentChanged.Invoke(_fishPercent);
        }

        //野菜
        _vegetablePercent = _vegetableAmount / _elementSum;
        //イベント
        if (OnVegetablePercentChanged != null)
        {
            OnVegetablePercentChanged.Invoke(_vegetablePercent);
        }

        CheckPercentage();
    }

    /// <summary>
    /// 操作可能かどうかを切り替える
    /// </summary>
    public void ChangeCanPlay()
    {
        if (_canPlay == true)
        {
            _canPlay = false;
        }
        else
        {
            _canPlay = true;
        }
    }

    /// <summary>
    /// ゲームプレイエンド時
    /// </summary>
    public void GamePlayEnd()
    {
        ChangeCanPlay();

        _gameEndText.gameObject.SetActive(true);

        //ゲームの終わり方によってテキスト変更
        if (_time <= 0)
        {
            _gameEndText.text = "TimeUp!";
        }
        else
        {
            _gameEndText.text = "GameOver";
        }
        //GameManagerにスコアを渡す
        GameManager.Instance.SetScore(_score);

        StartCoroutine(PlayEndCoroutine());
    }
    #endregion

    #region private method
    /// <summary>
    /// ゲームオーバー値を超えていないかチェック
    /// </summary>
    private void CheckPercentage()
    {
        if(_carbohydreatPercent <= _percentMin || _carbohydreatPercent >= _percentMax || 
            _meatPercent <= _percentMin || _meatPercent >= _percentMax ||
            _fishPercent <= _percentMin || _fishPercent >= _percentMax ||
            _vegetablePercent <= _percentMin || _vegetablePercent >= _percentMax)
        {
            GamePlayEnd();
        }
    }

    /// <summary>
    /// リザルトへ移動
    /// </summary>
    private void GoResult()
    {
        SceneController.Instance.ChangeScene(SceneName.InGameScene, SceneName.ResultScene);
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// スタートカウントダウン
    /// </summary>
    /// <returns></returns>
    private IEnumerator ThreeCountCoroutine()
    {
        //SE再生
        AudioManager.Instance.PlaySE(AudioManager.Instance.CountDownSE);

        //テキスト変更
        _countDownText.text = "3";
        yield return new WaitForSeconds(1);
        _countDownText.text = "2";
        yield return new WaitForSeconds(1);
        _countDownText.text = "1";
        yield return new WaitForSeconds(1);
        _countDownText.text = "Start!";

        //プレイ可能に
        ChangeCanPlay();

        //BGM再生
        AudioManager.Instance.PlayBGM(AudioManager.Instance.InGameBGM);

        //少し待ってテキストを非アクティブに
        yield return new WaitForSeconds(0.5f);
        _countDownText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 待ってからリザルトへ移行
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayEndCoroutine()
    {
        yield return new WaitForSeconds(2);

        //BGM停止
        AudioManager.Instance.StopBGM();
        GoResult();
    }
    #endregion
}
