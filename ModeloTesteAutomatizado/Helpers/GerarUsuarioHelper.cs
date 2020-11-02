using ModeloTesteAutomatizado.Data;

namespace ModeloTesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe responsável por gerênciar a criação de dados para uso no sistema.
    /// </summary>
    public static class GerarUsuarioHelper
    {
        public static Usuario GerarUsuario()
        {
            return new Usuario().UsuarioPadrao();
        }
    }
}