using System;
using Blockchain.Core;
using Newtonsoft.Json;

namespace Blockchain.Application
{
    public class Nota : IData
    {
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public Alumno Alumno { get; set; }
        public string Instancia { get; set; }
        public int CicloLectivo { get; set; }
        public string Observaciones { get; set; }

        public string Serialize() => JsonConvert.SerializeObject(this);
    }
}
