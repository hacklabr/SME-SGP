﻿using MSTech.GestaoEscolar.BLL;
using MSTech.GestaoEscolar.ObjetosSincronizacao.DTO.Entrada;
using MSTech.GestaoEscolar.ObjetosSincronizacao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoAcademica.WebApi.Controllers
{
    public class calendarios_anuaisController : ApiController
    {
        /// <summary>
        /// Seleciona todos os calendários anuais ativos.
        /// -- Utilização: URL_API/calendario_anual/?cal_ano={1}
        /// -- Parâmetros: cal_ano (Ano do calendário anual) 
        /// </summary>
        /// <param name="filtro">CalendarioAnualEntradaDTO.</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public List<ACA_CalendarioAnualDTO> GetAll(int cal_ano)
        {
            try
            {
                List<ACA_CalendarioAnualDTO> dto = ApiBO.SelecionarCalendariosAnuaisAtivos(cal_ano);

                if (dto != null && dto.Count > 0) return dto;

            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Erro: " + e.Message)
                });
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        

        /// <summary>
        /// Seleciona os dados do calendario anual por id.
        /// -- Utilização: URL_API/calendario_anual/1
        /// -- Parâmetros: id do calendario anual
        /// </summary>
        /// <param name="id">Id do calendário anual.</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public ACA_CalendarioAnualDTO Get(int id)
        {

            return GetByIDDataBase(id, null);           
        }
        
        /// <summary>
        /// Seleciona os dados do calendario anual por esc_id.
        /// </summary>
        /// <param name="esc_id">Id da escola</param>
        /// <returns></returns>
        [HttpGet]
        public ACA_CalendarioAnualDTO GetByEsc_id(long esc_id)
        {
            try
            {
                ACA_CalendarioAnualDTO dto = ApiBO.SelecionarCalendarioAnualPorEscId(esc_id);

                if (dto != null) return dto;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Erro: " + e.Message)
                });
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Seleciona os dados do calendario anual por id.
        /// -- Utilização: URL_API/calendario_anual/1
        /// -- Parâmetros: id do calendario anual
        /// </summary>
        /// <param name="id">Id do calendário anual.</param>
        /// <param name="dataBase">Id do calendário anual.</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public ACA_CalendarioAnualDTO GetByIDDataBase(int id, string dataBase)
        {
            try
            {
                DateTime data = string.IsNullOrEmpty(dataBase) ? new DateTime() : Convert.ToDateTime(dataBase);
                ACA_CalendarioAnualDTO dto = ApiBO.SelecionarCalendarioAnualPorId(id, data);

                if (dto != null) return dto;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Erro: " + e.Message)
                });
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Persiste os dados do Json.
        /// -- Utilização: URL_API/calendario_anual/
        /// -- Utilização: URL_API/tipos_disciplina/
        ///                - Deve ser informado json contendo um array com os calendarios anuais a serem persistidos;
        ///                - O formato do json deve seguir o modelo do método que seleciona todos os calendarios anuais;
        ///                - Para o método POST é necessário informar todos os atributos dos itens da listaCalendarioPeriodo,
        ///                  pois é realizado uma série de validações na camada de negócios. 
        ///                  [Em fase de desenvolvimento]
        /// </summary>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        public HttpResponseMessage Post()
        {
            try
            {
                string json = Request.Content.ReadAsStringAsync().Result;

                List<ACA_CalendarioAnualDTO> dto = ApiBO.SalvarCalendarioAnual(json);

                return (dto == null || dto.Count.Equals(0)) ?
                    Request.CreateResponse(HttpStatusCode.NoContent) :
                    Request.CreateResponse(HttpStatusCode.Created, dto);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Erro: {0}", e.Message));
            }
        }
    }
}
