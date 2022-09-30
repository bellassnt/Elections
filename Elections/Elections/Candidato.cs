namespace Elections
{
    public class Candidato
    {
        public string Nome { get; set; }
        public int Votos { get; set; }

        public Candidato(string nome)
        {
            Nome = nome;
            Votos = 0;
        }

        public int AdicionarVoto()
        {
            return Votos++;
        }

        public int RetornarVotos()
        {
            return Votos;
        }
    }
}