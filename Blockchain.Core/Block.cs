using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Core
{
    public class Block
    {
        public Block(DateTime timeStamp, IData data)
        {
            TimeStamp = timeStamp;
            Data = data;
            Hash = CalculateHash();
        }

        public int? Index { get; private set; }
        public DateTime TimeStamp { get; }
        public string PreviousHash { get; private set; }
        public string Hash { get; private set; }
        public IData Data { get; }

        private string CalculateHash()
        {
            var sha256 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? string.Empty}-{Data.Serialize()}");
            var outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        internal Block AddedToChain(int index, string previousHash)
        {
            if (Index.HasValue)
                throw new Exception($"Block {Hash} was already added to chain");
            Index = index;
            PreviousHash = previousHash;
            Hash = CalculateHash();
            return this;
        }

        public bool IsValid() => Hash.Equals(CalculateHash());
    }
}
