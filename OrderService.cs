namespace try_moq
{
    /// <summary>
    /// 注文処理を担うサービスです。
    /// </summary>
    public class OrderService
    {
        private readonly IPaymentGateway _payment;

        public OrderService(IPaymentGateway payment)
        {
            _payment = payment;
        }
        /// <summary>
        /// 発注を行います。
        /// </summary>
        /// <param name="amount">金額</param>
        /// <returns>True:成功/False:失敗</returns>
        public bool PlaceOrder(int amount)
        {
            // 外部サービスに支払いを依頼
            return _payment.Pay(amount);
        }
    }
}
