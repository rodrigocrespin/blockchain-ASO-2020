using System;
using Blockchain.Core;

namespace Blockchain.Application
{
    public class NotaTransaction : Transaction<int, string, Nota>
    {
        public NotaTransaction(Guid id, int from, string to, Nota data) : base(id, from, to, data)
        {
        }
    }
}
