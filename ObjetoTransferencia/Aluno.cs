using System;

namespace ObjetoTransferencia
{    
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
        public int AlunoStatus { get; set; }
    }
}
