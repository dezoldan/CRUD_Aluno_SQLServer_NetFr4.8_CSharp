using System;

namespace ObjetoTransferencia
{
    /// <summary>
    /// Modelo básico de uma entidade Aluno para uma escola de educação infantil, 
    /// De 01 até 04 anos de idade
    /// Exemplo para iniciantes em programação
    /// </summary>
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Sobrenome { get; set; }        
        public int DiaDoNascimento { get; set; }
        public int MesDoNascimento { get; set; }
        public int AnoDoNascimento { get; set; }
        public int MaeAlunoID { get; set; }
        public DateTime DataCreate { get; set; }
        /// <summary>
        /// 0 para inativo, 1 para ativo
        /// </summary>
        public int AlunoStatus { get; set; }
    }
}
