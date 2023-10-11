using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// �Q�[���{�҂̊Ǘ�
/// </summary>
public class InGameManager : SingletonMonoBehaviour<InGameManager>
{
    #region property
    public bool CanPlay => _canPlay;
    #endregion

    #region serialize
    [Tooltip("�Q�[���I�[�o�[�ɂȂ�l�@��")]
    [SerializeField]
    private float _percentMin = 0.1f;

    [Tooltip("�Q�[���I�[�o�[�ɂȂ�l�@��")]
    [SerializeField]
    private float _percentMax = 0.7f;

    [Tooltip("�J�E���g�_�E���e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _countDownText = default;

    [Tooltip("�^�C���e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _timeText = default;

    [Tooltip("�X�R�A�e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _scoreText = default;

    [Tooltip("�Q�[���I�����̃e�L�X�g")]
    [SerializeField]
    private TextMeshProUGUI _gameEndText = default;

    [Tooltip("�p�[�Z���g���B���p�l��")]
    [SerializeField]
    private GameObject _hidePanel = default;
    #endregion

    #region private
    /// <summary>�X�R�A</summary>
    private int _score = 0;
    /// <summary>�^�C��</summary>
    private float _time = 120;
    /// <summary>�����l�̍��v</summary>
    private float _elementSum = 0;
    /// <summary>�Y�����������l</summary>
    private float _carbohydrateAmount = 0;
    /// <summary>�������l</summary>
    private float _meatAmount = 0;
    /// <summary>�������l</summary>
    private float _fishAmount = 0;
    /// <summary>��ؑ����l</summary>
    private float _vegetableAmount = 0;
    /// <summary>�Y����������</summary>
    private float _carbohydreatPercent = 0;
    /// <summary>������</summary>
    private float _meatPercent = 0;
    /// <summary>������</summary>
    private float _fishPercent = 0;
    /// <summary>��؊���</summary>
    private float _vegetablePercent = 0;
    /// <summary>����ł��邩�ǂ���</summary>
    private bool _canPlay = false;
    /// <summary>hidePanel���A�N�e�B�u�ɂ������ǂ���</summary>
    private bool _panelInit = false;
    /// <summary>�^�C���A�b�v�����������ǂ���</summary>
    private bool _timeUpInit = false;
    #endregion

    #region Constant
    /// <summary>�Y�������l�̏����l</summary>
    private float CARBOHYDRATE_BASE = 25;
    /// <summary>���l�̏����l</summary>
    private float MEAT_BASE = 25;
    /// <summary>���l�̏����l</summary>
    private float FISH_BASE = 25;
    /// <summary>��ؒl�̏����l</summary>
    private float VEGETABLE_BASE = 25;
    #endregion

    #region Event
    /// <summary>
    /// �Y�������l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="carbohydreatPercent">�Y�������̊���</param>
    public delegate void CarbohydreatPercentEventHandler(float carbohydreatPercent);
    public event CarbohydreatPercentEventHandler OnCarbohydreatPercentChanged;

    /// <summary>
    /// ���l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="meatPercent">���̊���</param>
    public delegate void MeatPercentEventHandler(float meatPercent);
    public event MeatPercentEventHandler OnMeatPercentChanged;

    /// <summary>
    /// ���l�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="fishPercent">���̊���</param>
    public delegate void FishPercentEventHandler(float fishPercent);
    public event FishPercentEventHandler OnFishPercentChanged;

    /// <summary>
    /// ��ؒl�ω��C�x���g�̃f���Q�[�g
    /// </summary>
    /// <param name="vegetablePercent">��؂̊���</param>
    public delegate void VegetablePercentEventHandler(float vegetablePercent);
    public event VegetablePercentEventHandler OnVegetablePercentChanged;
    #endregion

    #region unity methods
    protected override void Awake()
    {
        base.Awake();
        //�����l������
        _carbohydrateAmount = CARBOHYDRATE_BASE;
        _meatAmount = MEAT_BASE;
        _fishAmount = FISH_BASE;
        _vegetableAmount = VEGETABLE_BASE;
        _elementSum = _carbohydrateAmount + _meatAmount + _fishAmount + _vegetableAmount;
    }

    private void Start()
    {
        //�J�E���g�_�E��
        StartCoroutine(ThreeCountCoroutine());
    }

    private void Update()
    {
        //�c��30�b�Ȃ�
        if(_time <= 30 && _panelInit == false)
        {
            _hidePanel.SetActive(true);
            _panelInit = true;
        }

        //�^�C���A�b�v�Ȃ�
        if(_time <= 0 && _timeUpInit == false)
        {
            GamePlayEnd();
            _timeUpInit = true;
        }

        //�v���C�\�Ȃ珈�����s
        if (CanPlay == false) return;

        //�^�C���o��
        _time -= Time.deltaTime;

        //�e�L�X�g�X�V
        _timeText.text = "Time:" + _time.ToString("F0");
        _scoreText.text = "Score:" + _score.ToString();
    }
    #endregion

    #region public method
    /// <summary>
    /// �X�R�A����
    /// </summary>
    /// <param name="amount">�����l</param>
    public void AddScore(int amount)
    {
        _score += amount;
    }

    /// <summary>
    /// �����l����
    /// </summary>
    /// <param name="carbohydreat">�Y������</param>
    /// <param name="meat">��</param>
    /// <param name="fish">��</param>
    /// <param name="vegetable">���</param>
    public void AddElement(int carbohydreat, int meat, int fish, int vegetable)
    {
        //�Y�������l
        _carbohydrateAmount += carbohydreat;
        _elementSum += carbohydreat;

        //���l
        _meatAmount += meat;
        _elementSum += meat;

        //���l
        _fishAmount += fish;
        _elementSum += fish;

        //��ؒl
        _vegetableAmount += vegetable;
        _elementSum += vegetable;

        ElementPercentage();
    }

    /// <summary>
    /// �����l�̊����Z�o
    /// </summary>
    public void ElementPercentage()
    {
        //�Y������
        _carbohydreatPercent = _carbohydrateAmount / _elementSum;
        //�C�x���g
        if (OnCarbohydreatPercentChanged != null)
        {
            OnCarbohydreatPercentChanged.Invoke(_carbohydreatPercent);
        }

        //��
        _meatPercent = _meatAmount / _elementSum;
        //�C�x���g
        if (OnMeatPercentChanged != null)
        {
            OnMeatPercentChanged.Invoke(_meatPercent);
        }

        //��
        _fishPercent = _fishAmount / _elementSum;
        //�C�x���g
        if (OnFishPercentChanged != null)
        {
            OnFishPercentChanged.Invoke(_fishPercent);
        }

        //���
        _vegetablePercent = _vegetableAmount / _elementSum;
        //�C�x���g
        if (OnVegetablePercentChanged != null)
        {
            OnVegetablePercentChanged.Invoke(_vegetablePercent);
        }

        CheckPercentage();
    }

    /// <summary>
    /// ����\���ǂ�����؂�ւ���
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
    /// �Q�[���v���C�G���h��
    /// </summary>
    public void GamePlayEnd()
    {
        ChangeCanPlay();

        _gameEndText.gameObject.SetActive(true);

        //�Q�[���̏I�����ɂ���ăe�L�X�g�ύX
        if (_time <= 0)
        {
            _gameEndText.text = "TimeUp!";
        }
        else
        {
            _gameEndText.text = "GameOver";
        }
        //GameManager�ɃX�R�A��n��
        GameManager.Instance.SetScore(_score);

        StartCoroutine(PlayEndCoroutine());
    }
    #endregion

    #region private method
    /// <summary>
    /// �Q�[���I�[�o�[�l�𒴂��Ă��Ȃ����`�F�b�N
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
    /// ���U���g�ֈړ�
    /// </summary>
    private void GoResult()
    {
        SceneController.Instance.ChangeScene(SceneName.InGameScene, SceneName.ResultScene);
    }
    #endregion

    #region coroutine method
    /// <summary>
    /// �X�^�[�g�J�E���g�_�E��
    /// </summary>
    /// <returns></returns>
    private IEnumerator ThreeCountCoroutine()
    {
        //SE�Đ�
        AudioManager.Instance.PlaySE(AudioManager.Instance.CountDownSE);

        //�e�L�X�g�ύX
        _countDownText.text = "3";
        yield return new WaitForSeconds(1);
        _countDownText.text = "2";
        yield return new WaitForSeconds(1);
        _countDownText.text = "1";
        yield return new WaitForSeconds(1);
        _countDownText.text = "Start!";

        //�v���C�\��
        ChangeCanPlay();

        //BGM�Đ�
        AudioManager.Instance.PlayBGM(AudioManager.Instance.InGameBGM);

        //�����҂��ăe�L�X�g���A�N�e�B�u��
        yield return new WaitForSeconds(0.5f);
        _countDownText.gameObject.SetActive(false);
    }

    /// <summary>
    /// �҂��Ă��烊�U���g�ֈڍs
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayEndCoroutine()
    {
        yield return new WaitForSeconds(2);

        //BGM��~
        AudioManager.Instance.StopBGM();
        GoResult();
    }
    #endregion
}
