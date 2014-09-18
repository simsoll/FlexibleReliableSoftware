﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using NUnit.Framework;

namespace Exercise5._2
{
    [TestFixture]
    public class TestPayStation
    {
        private IPayStation _ps;

        [SetUp]
        public void Init()
        {
            _ps = new PayStation();
        }

        [TearDown]
        public void CleanUp()
        {
        }

        [Test]
        [ExpectedException(typeof (IllegalCoinException))]
        public void ShouldFailOnIllegalCoinInsert()
        {
            _ps.AddPayment(7);
        }

        [TestCase(new[] {5}, 2)]
        [TestCase(new[] {25}, 10)]
        [TestCase(new[] {5, 10}, 6)]
        [TestCase(new[] {5, 10, 25}, 16)]
        public void ShouldDisplayCorrectlyAfterCoinInserts(int[] coins, int minutes)
        {
            foreach (var coin in coins)
            {
                _ps.AddPayment(coin);
            }
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(minutes));
        }

        [TestCase(new[] {5}, 2)]
        [TestCase(new[] {25}, 10)]
        [TestCase(new[] {5, 10}, 6)]
        [TestCase(new[] {5, 10, 25}, 16)]
        public void ShouldProduceValidReceiptWhenBuying(int[] coins, int minutes)
        {
            foreach (var coin in coins)
            {
                _ps.AddPayment(coin);
            }
            IReceipt receipt = _ps.Buy();
            Assert.That(receipt, Is.Not.Null);
            Assert.That(receipt.Value(), Is.EqualTo(minutes));
        }

        [Test]
        public void ShouldResetDisplayWhenBuying()
        {
            _ps.AddPayment(25);
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(10));
            IReceipt receipt = _ps.Buy();
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(0));
            Assert.That(receipt.Value(), Is.EqualTo(10));
        }

        [Test]
        public void ShouldResetDisplayWhenCancel()
        {
            _ps.AddPayment(25);
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(10));
            _ps.Cancel();
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(0));
            _ps.AddPayment(5);
            Assert.That(_ps.ReadDisplay(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnCoinsOnCancel()
        {
            _ps.AddPayment(25);
            _ps.AddPayment(25);
            _ps.AddPayment(5);
            IDictionary<int, int> returnedCoins = _ps.Cancel();
            Assert.That(returnedCoins[25], Is.EqualTo(2));
            Assert.That(returnedCoins[5], Is.EqualTo(1));
        }

        [Test]
        public void ShouldReturnCoinsAndResetOnCancel()
        {
            _ps.AddPayment(10);
            _ps.AddPayment(25);
            _ps.AddPayment(5);
            _ps.AddPayment(5);
            _ps.AddPayment(5);
            IDictionary<int, int> returnedCoins = _ps.Cancel();
            Assert.That(returnedCoins[25], Is.EqualTo(1));
            Assert.That(returnedCoins[10], Is.EqualTo(1));
            Assert.That(returnedCoins[5], Is.EqualTo(3));
            IDictionary<int, int> returnedCoinsAfterCancel = _ps.Cancel();
            Assert.That(returnedCoinsAfterCancel.Count, Is.EqualTo(0));
        }

    }
}