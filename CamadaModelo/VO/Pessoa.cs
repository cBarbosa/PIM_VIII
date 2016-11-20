using System;


namespace PIM_VII.VO
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public double CPF { get; set; }
        public int RG { get; set; }

        public void ValidaPessoa()
        {
            if (String.IsNullOrWhiteSpace(Nome) || Nome.Length < 5)
                throw new Exception("Nome inválido.");

            if (CPF < 1)
                throw new Exception("CPFinválido.");
        }
    }
}
