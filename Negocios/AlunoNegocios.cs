using AcessoBancoDeDados;
using ObjetoTransferencia;
using System;
using System.Data;

namespace Negocios
{
    public class AlunoNegocios
    {
        readonly AcessoDadosSQLServer acessosqlserver = new AcessoDadosSQLServer();

        /// <summary>
        /// Exemplo de como inserir um aluno
        /// O método utiliza uma procedure criada no SGBD SqlServer
        /// </summary>

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

        /// <summary>
        /// Exemplo de como consultar todos os alunos, sem passar parâmetros
        /// Num ambiente real, o parâmetro é necessário para filtrar os dados e não 
        /// sobrecarregar a consulta
        /// /// O método utiliza procedure criada no SGBD SqlServer
        /// </summary>
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

        /// <summary>
        /// Exemplo de como consular alunos passando um parametro, 
        /// por exemplo, o primeiro nome do aluno.
        /// O método utiliza uma procedure criada no SGBD SqlServer
        /// </summary>
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
        /// <summary>
        /// Exemplo de como fazer um Update utilizando o atributo PrimeiroNome da entidade Aluno
        /// O método utiliza uma procedure criada no SGBD SqlServer
        /// </summary>        

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

        /// <summary>
        /// Exemplo de como excluir um aluno
        /// Num ambiente real não é necessário excluir o aluno,
        /// bastando utilizar um flag de marcação para ativo ou inativo, por exemplo.
        /// O método utiliza uma procedure criada no SGBD SqlServer
        /// </summary>
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
