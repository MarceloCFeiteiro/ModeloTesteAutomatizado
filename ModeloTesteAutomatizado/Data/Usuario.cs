using Bogus;
using System;

namespace ModeloTesteAutomatizado.Data
{
    /// <summary>
    /// Classe reesponsável por armazenar informações de um usuário
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtém ou define Sexo.
        /// </summary>
        public char Sexo { get; set; }

        /// <summary>
        /// Obtém ou define PrimeiroNome.
        /// </summary>
        public string PrimeiroNome { get; set; }

        /// <summary>
        /// Obtém ou define UltimoNome.
        /// </summary>
        public string UltimoNome { get; set; }

        /// <summary>
        /// Obtém ou define Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Obtém ou define NomeCompleto.
        /// </summary>
        public string NomeCompleto { get { return $"{ PrimeiroNome} {UltimoNome}"; } }

        /// <summary>
        /// Obtém ou define Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define DataAniversario.
        /// </summary>
        public DateTime DataAniversario { get; set; }

        /// <summary>
        /// Obtém ou define Empresa.
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Obtém ou define EmpresaEndereco.
        /// </summary>
        public string EmpresaEndereco { get; set; }

        /// <summary>
        /// Obtém ou define Cidade.
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Obtém ou define Estado.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Obtém ou define Cep.
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Obtém ou define País.
        /// </summary>
        public string Pais { get; set; }

        /// <summary>
        /// Obtém ou define InformacaoAdicional.
        /// </summary>
        public string InformacaoAdicional { get; set; }

        /// <summary>
        /// Obtém ou define TelefoneComDDD.
        /// </summary>
        public string TelefoneComDDD { get; set; }

        /// <summary>
        /// Obtém ou define CelularComDDD.
        /// </summary>
        public string CelularComDDD { get; set; }

        /// <summary>
        /// Obtém ou define EnderecoAlternativo.
        /// </summary>
        public string EnderecoAlternativo { get; set; }

        /// <summary>
        /// Método responsável por criar um usuario para uso no sistema.
        /// </summary>
        /// <returns></returns>
        public Usuario UsuarioPadrao()
        {
            var faker = new Faker("pt_BR");
            var estadoFaker = new Bogus.DataSets.Address("en");
            var usuario = new Usuario
            {
                Sexo = faker.Random.Bool() ? 'F' : 'M',
                PrimeiroNome = faker.Name.FirstName(),
                UltimoNome = faker.Name.LastName(),
                Password = "aaa123"
            };
            usuario.Email = faker.Internet.Email(usuario.PrimeiroNome);
            usuario.DataAniversario = DateTime.Now.AddYears(-20);
            usuario.Empresa = faker.Company.CompanyName();
            usuario.EmpresaEndereco = faker.Address.StreetAddress();
            usuario.Cidade = faker.Address.City();
            usuario.Estado = estadoFaker.State();
            usuario.Cep = "12345";
            usuario.Pais = "United States";
            usuario.InformacaoAdicional = faker.Lorem.Lines();
            usuario.TelefoneComDDD = "(23)34732957";
            usuario.CelularComDDD = "(55)947345729";
            usuario.EnderecoAlternativo = faker.Random.Bool() ? "Home" : "Work";

            return usuario;
        }
    }
}