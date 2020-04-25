using System;
using Blockchain.Core;
using Blockchain.Tests.Base;
using SharpTestsEx;
using Xunit;

namespace Blockchain.Tests
{
    public class BlockTests
    {
        [Fact]
        public void Should_calculate_same_hash_when_have_same_data()
        {
            var b1 = new Block(DateTime.UtcNow, new TestData("123", 2020));
            var b2 = new Block(DateTime.UtcNow, new TestData("123", 2020));

            b1.Hash.Should().Be.EqualTo(b2.Hash);
        }

        [Fact]
        public void Should_calculate_different_hash_when_does_NOT_have_same_data()
        {
            var b1 = new Block(DateTime.UtcNow, new TestData("123", 2020));
            var b2 = new Block(DateTime.UtcNow, new TestData("456", 2019));

            b1.Hash.Should().Not.Be.EqualTo(b2.Hash);
        }
    }
}
