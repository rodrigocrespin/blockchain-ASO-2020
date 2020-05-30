using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Core
{
    public class Block
    {
        private int _nonce;

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
            var inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? string.Empty}-{Data.Serialize()}-{_nonce}");
            var outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        private void Mine(int difficulty)
        {
            var leadingZeros = new string('0', difficulty);
            while (Hash == null || Hash.Substring(0, difficulty) != leadingZeros)
            {
                _nonce++;
                Hash = CalculateHash();
            }
        }

        internal Block AddToChain(int index, string previousHash, int difficulty)
        {
            if (Index.HasValue)
                throw new Exception($"Block {Hash} was already added to chain");
            Index = index;
            PreviousHash = previousHash;
            Mine(difficulty);
            return this;
        }

        public bool IsValid() => Hash.Equals(CalculateHash());
    }
}
