using Newtonsoft.Json;

namespace ModeloTesteAutomatizado.Helpers
{
    public static class ConversorJsonHelper<T> where T : class
    {
        public static T JsonParaEntidade(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public static string EntidadeParaJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}