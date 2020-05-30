using System;
using Blockchain.Core;
using Newtonsoft.Json;

namespace Blockchain.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var blockchain = new BlockChain<StringData>(2);
            Console.WriteLine("Welcome to blockchain console!");

            while (true)
            {
                Console.WriteLine("Write new block value: ");
                var value = Console.ReadLine();

                blockchain.Add(new Block(DateTime.Now, new StringData(value)));
                Console.WriteLine("Block added!");

                Console.WriteLine($"Blockchain is {(blockchain.IsValid() ? "valid" : "invalid")}");
                Console.WriteLine(JsonConvert.SerializeObject(blockchain.Chain, Formatting.Indented));
            }
        }
    }

    public class StringData : IData
    {
        public StringData(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public string Serialize() => Value;
    }
}
