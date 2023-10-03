/// <summary>
/// シーンの名前を管理するクラス
/// </summary>
public class SceneName
{
    #region property
    public static string TitleScene => _titleScene;
    public static string InGameScene => _inGameScene;
    public static string ResultScene => _resultScene;
    #endregion

    #region private
    private static string _titleScene = "TitleScene";
    private static string _inGameScene = "InGameScene";
    private static string _resultScene = "ResultScene";
    #endregion
}
