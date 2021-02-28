using FastFeet.Dominio.SeedWork;
using System.Collections.Generic;

namespace FastFeet.Dominio.AggregatesModel.DestinatarioAggregate
{
    public class Endereco : ValueObject
    {
        public Endereco()
        {

        }
        public Endereco(string logradouro, string numero, string complemento, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Logradouro;
            yield return Numero;
            yield return Cidade;
            yield return Estado;
            yield return Cep;
        }
    }
}
