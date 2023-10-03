/// <summary>
/// アイテム取得時のインターフェース
/// </summary>
public interface IGetable
{
    /// <summary>
    /// 取得時の処理
    /// </summary>
    /// <param name="scoreAmount">スコア値</param>
    /// <param name="elementAmount">属性値</param>
    public void Get(int scoreAmount, int carbohydreatAmount, int meatAmount, int fishAmount, int vegetableAmount);
}
