using System.Linq;
using Xunit;

namespace Elections.Tests
{
    public class CandidatoTestes
    {
        [Fact]
        public void NumeroVotosZeroAposRegistroCandidato()
        {
            // Arrange
            var urna = new Urna();

            // Act
            urna.CadastrarCandidato("Isabella");
            var numeroVotosUltimocandidatoCadastrado = urna.Candidatos!.Last().Votos;

            // Act
            Assert.Equal(0, numeroVotosUltimocandidatoCadastrado);
        }

        [Fact]
        public void MaisUmVotoAposVoto()
        {
            // Arrange
            var candidato = new Candidato("Isabella");
            var numeroVotosAntesDeReceberUmVoto = candidato.Votos;

            // Act
            candidato.AdicionarVoto();
            var numeroVotosAposReceberUmVoto = candidato.Votos;
            var diferencaVotosAntesEAposReceberUmVoto = numeroVotosAposReceberUmVoto - numeroVotosAntesDeReceberUmVoto;

            // Assert
            Assert.Equal(1, diferencaVotosAntesEAposReceberUmVoto);
        }

        [Theory]
        [InlineData("Isabella", "Isabella")]
        [InlineData("Caio", "Oiac")]
        public void NomeCorretoCandidatoAposRegistroCandidato(string nomeCandidato, string resultadoEsperado)
        {
            // Arrange
            var urna = new Urna();
            urna.CadastrarCandidato(nomeCandidato);

            // Act
            var resultado = urna.Candidatos!.Last().Nome;

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}