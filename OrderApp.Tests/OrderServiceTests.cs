using Moq;
using try_moq;

namespace OrderApp.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        /// <summary>
        /// PlaceOrderメソッドは、支払いが成功した際にTrueを返す。
        /// Moqがない場合。PaymentGatewayを実装していないので、テストの前に作らないと...
        /// </summary>
        //[TestMethod]
        //public void PlaceOrder_ShouldReturnTrue_WhenPaymentSucceeds()
        //{
        //    var service = new OrderService(new PaymentGateway());
        //    var result = service.PlaceOrder(1000);

        //    Assert.IsTrue(result);
        //}

        /// <summary>
        ///  PlaceOrderメソッドは、支払いが成功した際にTrueを返す。
        /// </summary>
        [TestMethod]
        public void PlaceOrder_ShouldCallPayOnc()
        {
            // IPaymentGateway のモックを作成
            var mock = new Mock<IPaymentGateway>();

            // Pay が呼ばれたら true を返すよう設定。Mockの振る舞いを定義。
            mock.Setup(x => x.Pay(It.IsAny<int>()))
                .Returns(true);

            // 実行
            var service = new OrderService(mock.Object);
            var result = service.PlaceOrder(1000);

            //検証
            Assert.IsTrue(result);
        }

        /// <summary>
        /// PlaceOrderメソッドは、Payを1度だけ呼び出す。
        /// </summary>
        [TestMethod]
        public void PlaceOrder_ShouldReturnTrue_WhenPaymentSucceeds()
        {

            // モックを作成
            var mock = new Mock<IPaymentGateway>();
            mock.Setup(x => x.Pay(It.IsAny<int>()))
               .Returns(true);

            // 実行
            var service = new OrderService(mock.Object);
            var result = service.PlaceOrder(500);

            // Pay(500) が 1 回だけ呼ばれたことを検証
            mock.Verify(x => x.Pay(500), Times.Once);
        }

        /// <summary>
        /// Placeorderは、正しい引数でPayを呼び出す。
        /// </summary>
        [TestMethod]
        public void PlaceOrder_ShouldCallPayWithCorrectAmount() {
            // モックを作成
            var mock = new Mock<IPaymentGateway>();
            mock.Setup(x => x.Pay(It.IsAny<int>()))
               .Returns(true);

            // 実行
            var service = new OrderService(mock.Object);
            var result = service.PlaceOrder(750);

            // Pay(750) が 1 回だけ呼ばれたことを検証
            mock.Verify(x => x.Pay(750), Times.Once);
        }
    }
}