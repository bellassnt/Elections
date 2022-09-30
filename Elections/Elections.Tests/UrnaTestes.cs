using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Elections.Tests
{
    public class UrnaTestes
    {
        [Fact]
        public void InicializacaoConstrutorUrna()
        {
            // Arrange
            var urna = new Urna();

            var urnaReferencia = new Urna
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            // Act
            var resultado = urna == urnaReferencia;

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void InicializacaoOuFinalizacaoEleicao()
        {
            // Arrange
            var urna = new Urna();
            var statusEleicao = urna.EleicaoAtiva;

            // Act
            urna.IniciarEncerrarEleicao();
            var statusEleicaoAposInicializacaoOuFinalizacao = urna.EleicaoAtiva;

            // Assert
            Assert.NotEqual(statusEleicao, statusEleicaoAposInicializacaoOuFinalizacao);
        }

        [Fact]
        public void NomeUltimoCandidatoRegistrado()
        {
            // Arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Isabella");

            // Act
            var ultimoCandidatoRegistrado = urna.Candidatos!.Last().Nome;
            
            // Assert
            Assert.Equal("Isabella", ultimoCandidatoRegistrado);
        }

        [Theory]
        [InlineData("Isabella", true)]
        [InlineData("Caio", false)]
        public void VotacaoComCandidatoValidoOuInvalido(string candidato, bool resultadoEsperado)
        {
            // Arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Isabella");

            // Act
            var resultado = urna.Votar(candidato);

            // Arrange
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData("Isabella", 20, "Caio", 15, true)]
        [InlineData("Isabella", 15, "Caio", 20, false)]
        public void ResultadoEleicao(string candidatoVencedor, 
            int votosCandidatoVencedor,
            string candidatoPerdedor, 
            int votosCandidatoPerdedor,
            bool resultadoEleicoes)
        {
            // Arrange
            var urna = new Urna();

            urna.CadastrarCandidato(candidatoVencedor);
            urna.CadastrarCandidato(candidatoPerdedor);

            for (int i = 0; i < votosCandidatoVencedor; i++)
                urna.Votar(candidatoVencedor);

            for (int i = 0; i < votosCandidatoPerdedor; i++)
                urna.Votar(candidatoPerdedor);

            // Act
            var resultadoEleicoesMetodo = urna.MostrarResultadoEleicao();
            var resultadoEleicoesEsperado = $"Nome vencedor: {candidatoVencedor}. Votos: {votosCandidatoVencedor}";
            var resultadoTeste = resultadoEleicoesMetodo == resultadoEleicoesEsperado;

            // Assert
            Assert.Equal(resultadoTeste, resultadoEleicoes);
        }
    }
}