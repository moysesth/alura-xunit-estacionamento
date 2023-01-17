using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Alura.Estacionamento.Teste
{
    public class PatioTestes
    {

        [Fact]
        public void ValidaFaturamento()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Moyses Thomaz";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "FMQ-1231";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Nome 1", "ASD-1234", "cinza", "Gol")]
        [InlineData("Nome 2", "ASD-1123", "preto", "Opala")]
        [InlineData("Nome 3", "ASX-1123", "azul", "Maverick")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Nome 1", "ASD-1234", "cinza", "Gol")]
        [InlineData("Nome 2", "ASD-1123", "preto", "Opala")]
        [InlineData("Nome 3", "ASX-1123", "azul", "Maverick")]

        public void LocalizaVeiculoPatioPelaPlaca(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(placa);

            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculoDoProprioVeiculo()
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Moyses Thomaz";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "FMQ-1231";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Moyses Thomaz";
            veiculoAlterado.Placa = "FMQ-1231";
            veiculoAlterado.Cor = "Branco"; //alterado
            veiculoAlterado.Modelo = "Fusca";

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        [Theory]
        [InlineData("Nome 1", "ASD-1234", "cinza", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
                                                         string placa,
                                                         string cor,
                                                         string modelo)
        {
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(placa);

            Assert.Equal(placa, consultado.Placa);
        }
    }
}
