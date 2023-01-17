using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste
{
    public class VeiculoTestes
    {

        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        puclic VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado")
            veiculo = new Veiculo();
        }

        [Fact]
        public void TesteVeiculoAcelerar()
        {
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]
        public void TesteVeiculoFrear()
        {
            //var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculos()
        {
            var carro = new Veiculo();
            carro.Proprietario = "Carlos Silva";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "ZAP-7128";
            carro.Cor = "Verde";
            carro.Modelo = "Variante";

            string dados = carro.ToString();

            Assert.Contains("Ficha do Veículo:", dados);
        }
    }
}