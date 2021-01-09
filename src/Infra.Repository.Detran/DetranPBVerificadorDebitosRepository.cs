using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DesignPatternSamples.Application.DTO;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranPBVerificadorDebitosRepository : DetranVerificadorDebitosRepositoryCrawlerBase
    {
        private readonly ILogger _Logger;

        public DetranPBVerificadorDebitosRepository(ILogger<DetranPBVerificadorDebitosRepository> logger)
        {
            _Logger = logger;
        }

        protected override Task<IEnumerable<DebitoVeiculo>> PadronizarResultado(string html)
        {
            _Logger.LogDebug($"Executando função PadronizarResultado para valor html = {html}");
            return Task.FromResult<IEnumerable<DebitoVeiculo>>(new List<DebitoVeiculo>() { new DebitoVeiculo() { DataOcorrencia = DateTime.UtcNow } });
        }

        protected override Task<string> RealizarAcesso(Veiculo veiculo)
        {
            this.WaitRandomTime(4000, 5000);
            _Logger.LogDebug($"Executando função RealizarAcesso para valor Veiculo = {veiculo}");
            _Logger.LogDebug($"Consultando débitos do veículo placa {veiculo.Placa} para o estado de PB.");
            return Task.FromResult("Conteúdo do site do DETRAN/PB");
        }

        private void WaitRandomTime(int min, int max)
        {
            int range = max - min;
            int delayTime = (new Random().Next() % range) + min;
            _Logger.LogDebug($"Delay time between {min}ms and {max}ms value: {delayTime}");
            Task.Delay(delayTime).Wait();
        }

    }
}
