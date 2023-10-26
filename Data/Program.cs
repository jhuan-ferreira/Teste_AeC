using System;
using Data.Api;
using Data.Entity;
using Data.Busines;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {

        ExecutaNovamente:;
            try
            {
                Console.WriteLine("Para consultar a previsão meteorológica de uma determinada CIDADE digite: 1");

                Console.WriteLine("Para consultar a previsão meteorológica de um determinado AEROPORTO digite: 2");

                var comandoSolicitado = Console.ReadLine();

                if (comandoSolicitado == "1")
                {
                    Console.WriteLine("Digite o código da cidade da qual você deseja saber a previsão meteorológica.");
                    var codigoCidade = Console.ReadLine();

                    var dadosClimaticosCidade = new BuscaClimaCidade().Buscar(codigoCidade);

                    Console.WriteLine("Localidade: " + dadosClimaticosCidade.CidadeNome + "/" + dadosClimaticosCidade.Estado.ToUpper() + " Condição Climática: " + dadosClimaticosCidade.ClimaCidade.CondicaoDescricao + " Ultima Atualização: " + dadosClimaticosCidade.ClimaCidade.UltimaAtualizacao.ToString().Substring(0, 10));

                    new ClimaCidadeBusines().InsertRequisicao(dadosClimaticosCidade);
                }
                else if (comandoSolicitado == "2")
                {
                    Console.WriteLine("Digite o código do aeroporto do qual você deseja saber a previsão meteorológica.");
                    var codigoAeroporto = Console.ReadLine();

                    var daodsClimaticosAeroporto = new BuscaClimaAeroporto().Buscar(codigoAeroporto);

                    Console.WriteLine("Aeroporto: " + daodsClimaticosAeroporto.CodigoIcao + " Condição Climática: " + daodsClimaticosAeroporto.CondicaoDescricao + " Ultima Atualização: " + daodsClimaticosAeroporto.UltimaAtualizacao.ToString().Substring(0, 10));

                    new ClimaAeroportoBusines().InsertRequisicao(daodsClimaticosAeroporto);
                }
                else
                {
                    Console.WriteLine("Comando não identificado");
                }

                Console.WriteLine("Tecle qualquer letra para consultar a previsão meteorológica novamente");

                Console.ReadKey();
                Console.Clear();

                goto ExecutaNovamente;
            }
            catch (Exception ex)
            {
                var logErro = new LogErro();

                logErro.Data = DateTime.Now;
                logErro.Erro = ex.Message;

                new LogErroBusines().InsertRequisicao(logErro);

                Console.WriteLine("Houve o seguinte erro: " + ex.Message);

                Console.WriteLine("Tecle qualquer letra para consultar a previsão meteorológica novamente");

                Console.ReadKey();
                Console.Clear();

                goto ExecutaNovamente;

            }

        }   
    }
}
