using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rabun.Oanda.Rest.Endpoints;
using Rabun.Oanda.Rest.Base;
using Rabun.Oanda.Rest.Models;

namespace Rabun.Oanda.Rest.Test.Endpoints
{
    [TestClass]
    public class OrderEndpointsTest
    {
        private readonly OrderEndpoints _orderEndpoints;
        public OrderEndpointsTest()
        {
            _orderEndpoints = new OrderEndpoints("ec89b162d4a9922c8fa40769c2453d8b-cc1fb522857d46a08a90ef09730343a6", AccountType.practice, 4905675);
        }

        #region GetOrdersTest

        [TestMethod]
        public async Task GetOrdersTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public async Task GetOrdersByInstrumentTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD");
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod]
        public async Task GetOrdersByInstrumentAndCountTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 3);
        }

        [TestMethod]
        public async Task GetOrdersByAllTest()
        {
            List<Order> orders = await _orderEndpoints.GetOrders("EUR_USD", 5, null, null);
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 3);
        } 

        #endregion

        #region GetOrderTest

        [TestMethod]
        public async Task GetOrderTest()
        {
            Order order = await _orderEndpoints.GetOrder(965436841);
            Assert.IsNotNull(order);
        }

        #endregion

        #region CreateOrderTest

        [TestMethod]
        public async Task CreateOrderTest()
        {
            OrderOpen order = await _orderEndpoints.CreateOrder("EUR_USD", 555, OandaTypes.Side.buy, OandaTypes.OrderType.market,
                null, null, null, null, null, null);
            Assert.IsNotNull(order);
        }

        #endregion
    }
}
