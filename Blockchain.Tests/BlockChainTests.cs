using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Blockchain.Core;
using Blockchain.Tests.Base;
using SharpTestsEx;
using Xunit;

namespace Blockchain.Tests
{
    public class BlockChainTests
    {
        [Fact]
        public void Should_create_with_genesis_block()
        {
            var blockChain = new BlockChain(2);
            var genesis = blockChain.Chain.First();
            genesis.Should().Not.Be.Null();
            genesis.Data.Serialize().Should().Be.EqualTo(null);
        }

        [Fact]
        public void Should_add_new_block_and_stay_valid()
        {
            var blockChain = new BlockChain<TestData>(2);
            var data = new TestData("ABC1234", 2020);
            blockChain.Add(new Block(DateTime.UtcNow, data));
            blockChain.Chain.Last().Data.Should().Be.EqualTo(data);
            blockChain.IsValid().Should().Be.True();
        }

        [Fact]
        public void Should_be_invalid_if_block_data_is_corrupted()
        {
            var blockChain = new BlockChain<TestData>(2);
            var data = new TestData("ABC1234", 2020);
            blockChain.Add(new Block(DateTime.UtcNow, data));

            (blockChain.Chain.Last().Data as TestData).Year = 2019;

            blockChain.IsValid().Should().Be.False();
        }

        [Fact]
        public void Should_be_invalid_if_blocks_chain_is_corrupted()
        {
            var blockChain = new BlockChain<TestData>(2);
            var data1 = new TestData("AAA000", 2020);
            var data2 = new TestData("AAA001", 2020);
            var block1 = new Block(DateTime.UtcNow, data1);
            var block2 = new Block(DateTime.UtcNow, data2);
            blockChain.Add(block1);
            blockChain.Add(block2);

            var newChain = new List<Block> { block2, block1 };
            blockChain.ForceSet(newChain);

            blockChain.IsValid().Should().Be.False();
        }

        [Fact]
        public void Should_mine_block_when_adding_it_and_match_the_difficulty_provided()
        {
            var difficulty = 3;
            var blockChain = new BlockChain<TestData>(difficulty);
            var block = new Block(DateTime.UtcNow, new TestData("123", 2020));

            blockChain.Add(block);

            block.Hash.Substring(0, difficulty).Should().Be.EqualTo("000");
        }
    }

    internal static class BlockChainTestExtensions
    {
        public static void ForceSet<TData>(this BlockChain<TData> original, IList<Block> chain) where TData : IData
        {
            var field = original.GetType().GetField("_chain", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(original, chain);
        }
    }
}
