using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Core
{
    public class BlockChain : BlockChain<IData>
    {
        public BlockChain(int difficulty) : base(difficulty)
        {
        }
    }

    public class BlockChain<TData> where TData : IData
    {
        private readonly IList<Block> _chain;
        private readonly int _difficulty;

        public BlockChain(int difficulty)
        {
            _difficulty = difficulty;
            _chain = new List<Block>
            {
                new Block(DateTime.UtcNow, new GenesisData()).AddToChain(0, null, _difficulty)
            };
        }

        public IEnumerable<Block> Chain => _chain;
        private Block LastBlock => _chain.Last();

        public BlockChain<TData> Add(Block block)
        {
            var last = LastBlock;
            var nextIndex = (last.Index ?? throw new InvalidOperationException("Blockchain is corrupted")) + 1;

            _chain.Add(block.AddToChain(nextIndex, last.Hash, _difficulty));
            return this;
        }

        public bool IsValid()
        {
            if (_chain.Count < 1)
                return true;

            for (var i = 1; i < _chain.Count; i++)
            {
                var current = _chain[i];
                var previous = _chain[i - 1];

                var valid = current.IsValid() && current.PreviousHash.Equals(previous.Hash);
                if (!valid)
                    return false;
            }

            return true;
        }

        private class GenesisData : IData
        {
            public string Serialize() => null;
        }
    }
}
