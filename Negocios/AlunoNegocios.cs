using AcessoBancoDeDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class AlunoNegocios
    {
        readonly AcessoDadosSQLServer acessosqlserver = new AcessoDadosSQLServer();

        public string Inserir(Aluno aluno)
        {
            try
            {

                acessosqlserver.LimparParametros();
                acessosqlserver.AdicionarParametros("@PrimeiroNome", aluno.PrimeiroNome);
                acessosqlserver.AdicionarParametros("@SegundoNome", aluno.SegundoNome);
                acessosqlserver.AdicionarParametros("@Sobrenome", aluno.Sobrenome);
                acessosqlserver.AdicionarParametros("@DiaDoNascimento", aluno.DiaDoNascimento);
                acessosqlserver.AdicionarParametros("@MesDoNascimento", aluno.MesDoNascimento);
                acessosqlserver.AdicionarParametros("@AnoDoNascimento", aluno.AnoDoNascimento);
                acessosqlserver.AdicionarParametros("@MaeAlunoID", aluno.MaeAlunoID);
                acessosqlserver.AdicionarParametros("@AlunoStatus", aluno.AlunoStatus);
                string alunoID = acessosqlserver.ExecutarManipulacao(
                    CommandType.StoredProcedure, "uspInserirAluno").ToString();
                return alunoID;
            }

            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir o aluno. Detalhes:" + ex.Message);
            }
        }

        public AlunoColecao ConsultaTodosAlunos()
        {
            try
            {
                AlunoColecao alunoColecao = new AlunoColecao();

                DataTable dataTableAluno = new DataTable();
                dataTableAluno = acessosqlserver.ExecutarConsultaSemParametros(
                    CommandType.StoredProcedure, "uspConsultaTodosAlunos");
                foreach (DataRow linha in dataTableAluno.Rows)
                {
                    Aluno aluno = new Aluno
                    {
                        AlunoID = Convert.ToInt32(linha["AlunoID"]),
                        PrimeiroNome = Convert.ToString(linha["PrimeiroNome"]),
                        SegundoNome = Convert.ToString(linha["SegundoNome"]),
                        Sobrenome = Convert.ToString(linha["Sobrenome"]),
                        DiaDoNascimento = Convert.ToInt32(linha["DiaDoNascimento"]),
                        MesDoNascimento = Convert.ToInt32(linha["MesDoNascimento"]),
                        AnoDoNascimento = Convert.ToInt32(linha["AnoDoNascimento"]),
                        MaeAlunoID = Convert.ToInt32(linha["MaeAlunoID"]),
                        DataCreate = Convert.ToDateTime(linha["DataCreate"])
                    };

                    alunoColecao.Add(aluno);
                }

                return alunoColecao;
            }

            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar todos os alunos. Detalhes:" + ex.Message);
            }

        }

        public AlunoColecao ConsultaAlunoPorPrimeiroNome(string PrimeiroNomeAluno)
        {
            try
            {

                AlunoColecao alunoColecao = new AlunoColecao();

                DataTable dataTableAluno = new DataTable();
                acessosqlserver.LimparParametros();
                acessosqlserver.AdicionarParametros("@PrimeiroNome", PrimeiroNomeAluno);
                dataTableAluno = acessosqlserver.ExecutarConsulta(
                    CommandType.StoredProcedure, "uspConsultaAlunosPorPrimeiroNome");
                foreach (DataRow linha in dataTableAluno.Rows)
                {
                    Aluno aluno = new Aluno
                    {
                        AlunoID = Convert.ToInt32(linha["AlunoID"]),
                        PrimeiroNome = Convert.ToString(linha["PrimeiroNome"]),
                        SegundoNome = Convert.ToString(linha["SegundoNome"]),
                        Sobrenome = Convert.ToString(linha["Sobrenome"]),
                        DiaDoNascimento = Convert.ToInt32(linha["DiaDoNascimento"]),
                        MesDoNascimento = Convert.ToInt32(linha["MesDoNascimento"]),
                        AnoDoNascimento = Convert.ToInt32(linha["AnoDoNascimento"]),
                        MaeAlunoID = Convert.ToInt32(linha["MaeAlunoID"]),
                        DataCreate = Convert.ToDateTime(linha["DataCreate"])
                    };

                    alunoColecao.Add(aluno);
                }

                return alunoColecao;
            }

            catch (Exception ex)
            {
                throw new Exception("Não foi possível consultar o aluno pelo primeiro nome. Detalhes:" + ex.Message);
            }

        }

        public string AlterarPrimeiroNomeAluno(Aluno aluno)
        {
            try
            {
                acessosqlserver.LimparParametros();
                acessosqlserver.AdicionarParametros("@AlunoID", aluno.AlunoID);
                acessosqlserver.AdicionarParametros("@PrimeiroNome", aluno.PrimeiroNome);
                string alunoID = acessosqlserver.ExecutarManipulacao(
                    CommandType.StoredProcedure, "uspAlterarPrimeiroNomeAluno").ToString();
                return alunoID;

            }

            catch (Exception ex)
            {
                throw new Exception("Não foi possível alterar o primeiro nome do aluno. Detalhes:" + ex.Message);
            }
        }

        public string ExcluirAluno(Aluno aluno)
        {
            try
            {
                acessosqlserver.LimparParametros();
                acessosqlserver.AdicionarParametros("@AlunoID", aluno.AlunoID);
                string alunoID = acessosqlserver.ExecutarManipulacao(
                    CommandType.StoredProcedure, "uspExcluirAluno").ToString();

                return alunoID;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir o aluno. Detalhes:" + ex.Message);
            }
        }

    }
}