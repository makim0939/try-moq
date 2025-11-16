namespace try_moq
{
    /// <summary>
    /// Paymentサービスが支払いを依頼する際の抽象的な窓口です。
    /// </summary>
    public interface IPaymentGateway
    {
        /// <summary>
        /// 支払いを実行します。
        /// </summary>
        /// <param name="amount">金額</param>
        /// <returns>True:成功/False:失敗</returns>
        bool Pay(int amount);
    }
}
