using System;
using System.Net.Http;
using Data.Entity;
using Newtonsoft.Json;

namespace Data.Api
{
    class BuscaClimaAeroporto
    {
        public ClimaAeroporto Buscar(string codigoIcao)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri($"https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/{codigoIcao}");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var climaAeroporto = new ClimaAeroporto ();

            if (response.IsSuccessStatusCode)
            {
                var dataObjectJson = response.Content.ReadAsStringAsync();
                var jsonObjectSerialized = JsonConvert.SerializeObject(dataObjectJson.Result);
                var objectDeserialized = JsonConvert.DeserializeObject<string>(jsonObjectSerialized).Replace("[", "").Replace("]", "").Split(',');


                foreach (var obj in objectDeserialized)
                {

                    if (obj.Contains("codigo_icao"))
                    {
                        climaAeroporto.CodigoIcao = obj.ToString().Replace("{", "").Replace("codigo_icao", "").Replace(":", "").Replace('"', '*').Replace("*", null);
                    }
                    else if (obj.Contains("atualizado_em"))
                    {
                        climaAeroporto.UltimaAtualizacao = Convert.ToDateTime(obj.ToString().Replace("{", "").Replace("}", "").Replace("atualizado_em", "").Replace(":", "").Replace('"', '*').Replace("*", null).Substring(0,10));
                    }
                    else if (obj.Contains("pressao_atmosferica"))
                    {
                        climaAeroporto.PressaoAtmosferica = obj.ToString().Replace("{", "").Replace("pressao_atmosferica", "").Replace(":", "").Replace('"', '*').Replace("*", null);
                    }
                    else if (obj.Contains("visibilidade"))
                    {
                        climaAeroporto.Visibilidade = obj.ToString().Replace("{", "").Replace("visibilidade", "").Replace(":", "").Replace('"', '*').Replace("*", null).Replace("clima", null).Replace(">", null);
                    }
                    else if (obj.Contains("direcao_vento"))
                    {
                        climaAeroporto.DirecaoVento = int.Parse(obj.ToString().Replace("{", "").Replace("direcao_vento", "").Replace(":", "").Replace('"', 'a').Replace("a", null));
                    }
                    else if (obj.Contains("vento"))
                    {
                        climaAeroporto.Vento = int.Parse(obj.ToString().Replace("{", "").Replace("vento", "").Replace(":", "").Replace('"', '*').Replace("*", null));
                    }

                }

            }
            else
            {
                climaAeroporto = null;
            }

            return climaAeroporto;

        }
    }
}
