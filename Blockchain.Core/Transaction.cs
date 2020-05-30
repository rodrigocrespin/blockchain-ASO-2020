using System;

namespace Blockchain.Core
{
    public interface ITransaction
    {
        Guid Id { get; }
    }

    public class Transaction<TFrom, TTo, TData> : ITransaction where TData : IData
    {
        public Transaction(Guid id, TFrom from, TTo to, TData data)
        {
            Id = id;
            From = from;
            To = to;
            Data = data;
        }

        public Guid Id { get; }
        public TFrom From { get; }
        public TTo To { get; }
        public TData Data { get; }
    }
}
