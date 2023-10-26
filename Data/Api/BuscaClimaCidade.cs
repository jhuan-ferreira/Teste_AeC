using System;
using System.Net.Http;
using Data.Entity;
using Newtonsoft.Json;

namespace Data.Api
{
    class BuscaClimaCidade
    {
        public Cidade Buscar(string codigoCidade)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{codigoCidade}");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var cidade = new Cidade();

            if (response.IsSuccessStatusCode)
            {
                var dataObjectJson = response.Content.ReadAsStringAsync();
                var jsonObjectSerialized = JsonConvert.SerializeObject(dataObjectJson.Result);
                var objectDeserialized = JsonConvert.DeserializeObject<string>(jsonObjectSerialized).Replace("[", "").Replace("]", "").Split(',');


                foreach (var obj in objectDeserialized)
                {

                    if (obj.Contains("cidade"))
                    {
                        cidade.CidadeNome = obj.ToString().Replace("{", "").Replace("cidade", "").Replace(":", "").Replace('"', '*').Replace("*", null);
                    }
                    else if (obj.Contains("estado"))
                    {
                        cidade.Estado = obj.ToString().Replace("{", "").Replace("}", "").Replace("estado", "").Replace(":", "").Replace('"', '*').Replace("*", null);
                    }
                    else if (obj.Contains("atualizado_em"))
                    {
                        cidade.UltimaAtualizacao = Convert.ToDateTime(obj.ToString().Replace("{", "").Replace("atualizado_em", "").Replace(":", "").Replace('"', '*').Replace("*", null));
                    }
                    else if (obj.Contains("data") && !obj.Contains("descricao"))
                    {
                        cidade.ClimaCidade.UltimaAtualizacao = Convert.ToDateTime(obj.ToString().Replace("{", "").Replace("data", "").Replace(":", "").Replace('"', '*').Replace("*", null).Replace("clima", null));
                    }
                    else if (obj.Contains("condicao_desc"))
                    {
                        cidade.ClimaCidade.CondicaoDescricao = obj.ToString().Replace("{", "").Replace("condicao_desc", "").Replace(":", "").Replace('"', '*').Replace("*", null);
                    }
                    else if (obj.Contains("condicao"))
                    {
                        cidade.ClimaCidade.Condicao = obj.ToString().Replace("{", "").Replace("condicao", "").Replace(":", "").Replace('"', 'a').Replace("a", null);
                    }

                }

            }
            else
            {
                cidade = null;
            }

            return cidade;

        }
    }
}
