/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

using System;
using System.Data;
using MSTech.Data.Common;
using MSTech.GestaoEscolar.Entities;
using MSTech.GestaoEscolar.DAL.Abstracts;

namespace MSTech.GestaoEscolar.DAL
{	
	/// <summary>
	/// 
	/// </summary>
    public class ACA_CurriculoTurnoDAO : Abstract_ACA_CurriculoTurnoDAO
    {
        /// <summary>
        /// Retorna um datatable contendo todos os tipos de turnos do curriculo/curso
        /// que não foram excluídos logicamente, filtrados por 
        /// id do curso, id do curriculo
        /// </summary>
        /// <param name="cur_id">Id da tabela ACA_Curso do bd</param>
        /// <param name="crr_id">Id da tabela ACA_Curriculo do bd</param>
        /// <param name="paginado">Indica se o datatable será paginado ou não</param>
        /// <param name="currentPage">Página atual do grid</param>
        /// <param name="pageSize">Total de registros por página do grid</param>
        /// <param name="totalRecords">Total de registros retornado na busca</param>
        /// <returns>DataTable com os turnos do curriculo</returns>
        public DataTable SelectBy_cur_id_crr_id
        (
            int cur_id
            , int crr_id
            , bool paginado
            , int currentPage
            , int pageSize
            , out int totalRecords
        )
        {            
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_ACA_CurriculoTurno_SelectBy_cur_id_crr_id", _Banco);
            try
            {
                #region PARAMETROS

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@cur_id";
                Param.Size = 4;
                if (cur_id > 0)
                    Param.Value = cur_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@crr_id";
                Param.Size = 4;
                if (crr_id > 0)
                    Param.Value = crr_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                #endregion

                if (paginado)
                    totalRecords = qs.Execute(currentPage, pageSize);
                else
                {
                    qs.Execute();
                    totalRecords = qs.Return.Rows.Count;
                }

                return qs.Return;
            }
            catch
            {
                throw;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        public DataTable SelectBy_cur_id_crr_id_esc_id
        (
            int cur_id
            , int crr_id
            , int esc_id
            , int uni_id
            , bool paginado
            , int currentPage
            , int pageSize
            , out int totalRecords
        )
        {            
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_ACA_CurriculoTurno_SelectBy_cur_id_crr_id_esc_id", _Banco);
            try
            {
                #region PARAMETROS

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@cur_id";
                Param.Size = 4;
                if (cur_id > 0)
                    Param.Value = cur_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@crr_id";
                Param.Size = 4;
                if (crr_id > 0)
                    Param.Value = crr_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@esc_id";
                Param.Size = 4;
                if (esc_id > 0)
                    Param.Value = esc_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@uni_id";
                Param.Size = 4;
                if (uni_id > 0)
                    Param.Value = uni_id;
                else
                    Param.Value = DBNull.Value;
                qs.Parameters.Add(Param);

                #endregion

                if (paginado)
                    totalRecords = qs.Execute(currentPage, pageSize);
                else
                {
                    qs.Execute();
                    totalRecords = qs.Return.Rows.Count;
                }

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        public DataTable SelectBy_esc_id_uni_id
        (
           int esc_id
           , int uni_id
           , out int totalRecords
        )
        {
            QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("NEW_ACA_CurriculoTurno_SelectBy_esc_id_uni_id", _Banco);
            try
            {
                #region PARAMETROS

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@esc_id";
                Param.Size = 4;
                Param.Value = esc_id;
                qs.Parameters.Add(Param);

                Param = qs.NewParameter();
                Param.DbType = DbType.Int32;
                Param.ParameterName = "@uni_id";
                Param.Size = 4;
                Param.Value = uni_id;
                qs.Parameters.Add(Param);

                #endregion
               
                qs.Execute();
                totalRecords = qs.Return.Rows.Count;

                return qs.Return;
            }
            finally
            {
                qs.Parameters.Clear();
            }
        }

        /// <summary>
        /// Parâmetros para efetuar a inclusão preservando a data de criação
        /// </summary>
        /// <param name="qs"></param>
        /// <param name="entity"></param>
        protected override void ParamInserir(QuerySelectStoredProcedure qs, ACA_CurriculoTurno entity)
        {
            base.ParamInserir(qs, entity);

            qs.Parameters["@crt_dataCriacao"].Value = DateTime.Now;
            qs.Parameters["@crt_dataAlteracao"].Value = DateTime.Now;
        }

        /// <summary>
        /// Parâmetros para efetuar a alteração preservando a data de criação
        /// </summary>
        protected override void ParamAlterar(QueryStoredProcedure qs, ACA_CurriculoTurno entity)
        {
            base.ParamAlterar(qs, entity);

            qs.Parameters.RemoveAt("@crt_dataCriacao");
            qs.Parameters["@crt_dataAlteracao"].Value = DateTime.Now;
        }

        /// <summary>
        /// Método alterado para que o update não faça a alteração da data de criação
        /// </summary>
        /// <param name="entity"> Entidade ACA_CurriculoTurno</param>
        /// <returns>true = sucesso | false = fracasso</returns> 
        protected override bool Alterar(ACA_CurriculoTurno entity)
        {
            __STP_UPDATE = "NEW_ACA_CurriculoTurno_UPDATE";
            return base.Alterar(entity);
        }

        /// <summary>
        /// Parâmetros para efetuar a exclusão lógica.
        /// </summary>
        protected override void ParamDeletar(QueryStoredProcedure qs, ACA_CurriculoTurno entity)
        {
            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@cur_id";
            Param.Size = 4;
            Param.Value = entity.cur_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@crr_id";
            Param.Size = 4;
            Param.Value = entity.crr_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@esc_id";
            Param.Size = 4;
            Param.Value = entity.esc_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@uni_id";
            Param.Size = 4;
            Param.Value = entity.uni_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@ces_id";
            Param.Size = 4;
            Param.Value = entity.ces_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@crt_id";
            Param.Size = 4;
            Param.Value = entity.crt_id;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.Int32;
            Param.ParameterName = "@crt_situacao";
            Param.Size = 1;
            Param.Value = 3;
            qs.Parameters.Add(Param);

            Param = qs.NewParameter();
            Param.DbType = DbType.DateTime;
            Param.ParameterName = "@crt_dataAlteracao";
            Param.Size = 8;
            Param.Value = DateTime.Now;
            qs.Parameters.Add(Param);
        }

        /// <summary>
        /// Método alterado para que o delete não faça exclusão física e sim lógica (update).
        /// </summary>
        /// <param name="entity"> Entidade ACA_CurriculoTurno</param>
        /// <returns>true = sucesso | false = fracasso</returns>   
        public override bool Delete(ACA_CurriculoTurno entity)
        {
            __STP_DELETE = "NEW_ACA_CurriculoTurno_Update_Situacao";
            return base.Delete(entity);
        }

        ///// <summary>
        ///// Método alterado para que o delete não faça exclusão física e sim lógica (update).
        ///// </summary>
        ///// <param name="entity"> Entidade ACA_CurriculoTurno</param>
        ///// <returns>true = sucesso | false = fracasso</returns>        
        ///// <summary>
        ///// Inseri os valores da classe em um registro ja existente
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem modificados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        ///// <summary>
        ///// Inseri os valores da classe em um novo registro
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem inseridos</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //protected override bool Inserir(ACA_CurriculoTurno entity)
        //{
        //    return base.Inserir(entity);
        //}
        ///// <summary>
        ///// Carrega um registro da tabela usando os valores nas chaves
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem carregados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Carregar(ACA_CurriculoTurno entity)
        //{
        //    return base.Carregar(entity);
        //}
        ///// <summary>
        ///// Exclui um registro do banco
        ///// </summary>
        ///// <param name="entity">Entidade com os dados a serem apagados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Delete(ACA_CurriculoTurno entity)
        //{
        //    return base.Delete(entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Alterar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        ///// <summary>
        ///// Configura os parametros do metodo de Carregar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamCarregar(QuerySelectStoredProcedure qs, ACA_CurriculoTurno entity)
        //{
        //    base.ParamCarregar(qs, entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Deletar
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamDeletar(QueryStoredProcedure qs, ACA_CurriculoTurno entity)
        //{
        //    base.ParamDeletar(qs, entity);
        //}
        ///// <summary>
        ///// Configura os parametros do metodo de Inserir
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados para preenchimento dos parametros</param>
        //protected override void ParamInserir(QuerySelectStoredProcedure qs, ACA_CurriculoTurno entity)
        //{
        //    base.ParamInserir(qs, entity);
        //}
        ///// <summary>
        ///// Salva o registro no banco de dados
        ///// </summary>
        ///// <param name="entity">Entidade com os dados para preenchimento para inserir ou alterar</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //public override bool Salvar(ACA_CurriculoTurno entity)
        //{
        //    return base.Salvar(entity);
        //}
        ///// <summary>
        ///// Realiza o select da tabela
        ///// </summary>
        ///// <returns>Lista com todos os registros da tabela</returns>
        //public override IList<ACA_CurriculoTurno> Select()
        //{
        //    return base.Select();
        //}
        ///// <summary>
        ///// Realiza o select da tabela com paginacao
        ///// </summary>
        ///// <param name="currentPage">Pagina atual</param>
        ///// <param name="pageSize">Tamanho da pagina</param>
        ///// <param name="totalRecord">Total de registros na tabela original</param>
        ///// <returns>Lista com todos os registros da p�gina</returns>
        //public override IList<ACA_CurriculoTurno> Select_Paginado(int currentPage, int pageSize, out int totalRecord)
        //{
        //    return base.Select_Paginado(currentPage, pageSize, out totalRecord);
        //}
        ///// <summary>
        ///// Recebe o valor do auto incremento e coloca na propriedade 
        ///// </summary>
        ///// <param name="qs">Objeto da Store Procedure</param>
        ///// <param name="entity">Entidade com os dados</param>
        ///// <returns>True - Operacao bem sucedida</returns>
        //protected override bool ReceberAutoIncremento(QuerySelectStoredProcedure qs, ACA_CurriculoTurno entity)
        //{
        //    return base.ReceberAutoIncremento(qs, entity);
        //}
        ///// <summary>
        ///// Passa os dados de um datatable para uma entidade
        ///// </summary>
        ///// <param name="dr">DataRow do datatable preenchido</param>
        ///// <param name="entity">Entidade onde ser�o transferidos os dados</param>
        ///// <returns>Entidade preenchida</returns>
        //public override ACA_CurriculoTurno DataRowToEntity(DataRow dr, ACA_CurriculoTurno entity)
        //{
        //    return base.DataRowToEntity(dr, entity);
        //}
        ///// <summary>
        ///// Passa os dados de um datatable para uma entidade
        ///// </summary>
        ///// <param name="dr">DataRow do datatable preenchido</param>
        ///// <param name="entity">Entidade onde ser�o transferidos os dados</param>
        ///// <param name="limparEntity">Indica se a entidade deve ser limpada antes da transferencia</param>
        ///// <returns>Entidade preenchida</returns>
        //public override ACA_CurriculoTurno DataRowToEntity(DataRow dr, ACA_CurriculoTurno entity, bool limparEntity)
        //{
        //    return base.DataRowToEntity(dr, entity, limparEntity);
        //}
    }
}