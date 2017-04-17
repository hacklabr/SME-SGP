﻿using MSTech.CoreSSO.BLL;
using MSTech.GestaoEscolar.BLL;
using MSTech.GestaoEscolar.Entities;
using MSTech.GestaoEscolar.Web.WebProject;
using MSTech.Validation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GestaoEscolar.Academico.ObjetoAprendizagem
{
    public partial class Cadastro : MotherPageLogado
    {
        private int _VS_oap_id
        {
            get
            {
                if (ViewState["_VS_oap_id"] != null)
                {
                    return Convert.ToInt32(ViewState["_VS_oap_id"]);
                }
                return -1;
            }
            set
            {
                ViewState["_VS_oap_id"] = value;
            }
        }

        private int _VS_tds_id
        {
            get
            {
                if (ViewState["_VS_tds_id"] != null)
                {
                    return Convert.ToInt32(ViewState["_VS_tds_id"]);
                }
                return -1;
            }
            set
            {
                ViewState["_VS_tds_id"] = value;
            }
        }

        private int _VS_cal_ano
        {
            get
            {
                if (ViewState["_VS_cal_ano"] != null)
                {
                    return Convert.ToInt32(ViewState["_VS_cal_ano"]);
                }
                return -1;
            }
            set
            {
                ViewState["_VS_cal_ano"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((PreviousPage != null) && (PreviousPage.IsCrossPagePostBack))
                {
                    _VS_oap_id = PreviousPage.oap_id;
                    _VS_tds_id = PreviousPage.tds_id;
                    _VS_cal_ano = PreviousPage.cal_ano;
                    txtAno.Text = _VS_cal_ano.ToString();
                    LoadPage();

                    if(_VS_oap_id > 0)
                        LoadEdit(_VS_oap_id);
                }
                else
                {
                    Response.Redirect(__SessionWEB._AreaAtual._Diretorio + "Academico/ObjetoAprendizagem/Busca.aspx", false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void _btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lstCiclos = CriarListaTipoCiclo();

                if (!lstCiclos.Any())
                    throw new ValidationException("Selecione pelo menos um ciclo.");

                ACA_ObjetoAprendizagem obj = new ACA_ObjetoAprendizagem
                {
                    IsNew = _VS_oap_id <= 0,
                    oap_descricao = _txtDescricao.Text,
                    tds_id = _VS_tds_id,
                    cal_ano = _VS_cal_ano,
                    oap_situacao = (_ckbBloqueado.Checked ? (byte)ObjetoAprendizagemSituacao.Bloqueado 
                                                          : (byte)ObjetoAprendizagemSituacao.Ativo),
                    oap_id = _VS_oap_id
                };

                ACA_ObjetoAprendizagemBO.Save(obj, lstCiclos);

                if (_VS_oap_id > 0)
                {
                    ApplicationWEB._GravaLogSistema(LOG_SistemaTipo.Update, "oap_id: " + obj.oap_id);
                    __SessionWEB.PostMessages = UtilBO.GetErroMessage("Objeto de conhecimento alterado com sucesso.", UtilBO.TipoMensagem.Sucesso);
                }
                else
                {
                    ApplicationWEB._GravaLogSistema(LOG_SistemaTipo.Insert, "oap_id: " + obj.oap_id);
                    __SessionWEB.PostMessages = UtilBO.GetErroMessage("Objeto de conhecimento incluído com sucesso.", UtilBO.TipoMensagem.Sucesso);
                }

                Session["tds_id_oap"] = _VS_tds_id;
                Response.Redirect(__SessionWEB._AreaAtual._Diretorio + "Academico/ObjetoAprendizagem/Busca.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (ValidationException ex)
            {
                _lblMessage.Text = UtilBO.GetErroMessage(ex.Message, UtilBO.TipoMensagem.Alerta);
            }
            catch (ArgumentException ex)
            {
                _lblMessage.Text = UtilBO.GetErroMessage(ex.Message, UtilBO.TipoMensagem.Alerta);
            }
            catch (Exception ex)
            {
                ApplicationWEB._GravaErro(ex);
                _lblMessage.Text = UtilBO.GetErroMessage("Erro ao tentar salvar o objeto de conhecimento.", UtilBO.TipoMensagem.Erro);
            }
        }

        private List<int> CriarListaTipoCiclo()
        {
            List<int> list = new List<int>();
            foreach (RepeaterItem item in rptCampos.Items)
            {
                CheckBox ckbCampo = (CheckBox)item.FindControl("ckbCampo");
                if (ckbCampo != null && ckbCampo.Checked)
                {
                    HiddenField hdnId = (HiddenField)item.FindControl("hdnId");
                    if (hdnId != null)
                        list.Add(Convert.ToInt32(hdnId.Value));
                }
            }

            return list;
        }

        protected void _btnCancelar_Click(object sender, EventArgs e)
        {
            Session["tds_id_oap"] = _VS_tds_id;
            Response.Redirect("~/Academico/ObjetoAprendizagem/Busca.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private void LoadEdit(int oap_id)
        {
            try
            {
                ACA_ObjetoAprendizagem objetoAp = new ACA_ObjetoAprendizagem { oap_id = oap_id };
                ACA_ObjetoAprendizagemBO.GetEntity(objetoAp);

                _txtDescricao.Text = objetoAp.oap_descricao;
                _ckbBloqueado.Checked = objetoAp.oap_situacao == (byte)ObjetoAprendizagemSituacao.Bloqueado;

                Dictionary<int, bool> ciclos = ACA_ObjetoAprendizagemTipoCicloBO.SelectBy_ObjetoAprendizagem(oap_id);

                if (ciclos.Any(p => !p.Value))
                    lblMessageCiclos.Text = UtilBO.GetErroMessage(GetGlobalResourceObject("Academico", "ObjetoAprendizagem.Cadastro.lblMessageCiclos.Text").ToString(), UtilBO.TipoMensagem.Informacao);

                foreach (RepeaterItem item in rptCampos.Items)
                {
                    CheckBox ckbCampo = (CheckBox)item.FindControl("ckbCampo");
                    if (ckbCampo != null)
                    {
                        HiddenField hdnId = (HiddenField)item.FindControl("hdnId");
                        if (hdnId != null)
                        {
                            ckbCampo.Checked = ciclos.Any(p => p.Key == Convert.ToInt32(hdnId.Value));
                            ckbCampo.Enabled = !ciclos.Any(p => p.Key == Convert.ToInt32(hdnId.Value)) ||
                                               ciclos.Any(p => p.Key == Convert.ToInt32(hdnId.Value) && !p.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationWEB._GravaErro(ex);
                _lblMessage.Text = UtilBO.GetErroMessage("Erro ao carregar o objeto de conhecimento.", UtilBO.TipoMensagem.Erro);
            }
        }

        private void LoadPage()
        {
            try
            {
                var tds = new ACA_TipoDisciplina { tds_id = _VS_tds_id };
                ACA_TipoDisciplinaBO.GetEntity(tds);

                txtDisciplina.Text = tds.tds_nome;

                rptCampos.DataSource = ACA_TipoCicloBO.SelecionaTipoCicloAtivos(true, ApplicationWEB.AppMinutosCacheLongo);
                rptCampos.DataBind();
            }
            catch (Exception ex)
            {
                ApplicationWEB._GravaErro(ex);
                _lblMessage.Text = UtilBO.GetErroMessage("Erro ao carregar a página.", UtilBO.TipoMensagem.Erro);
            }
        }

        protected void cvCiclos_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            foreach (RepeaterItem item in rptCampos.Items)
            {
                CheckBox ckbCampo = (CheckBox)item.FindControl("ckbCampo");
                if (ckbCampo != null && ckbCampo.Checked)
                {
                    args.IsValid = true;
                    break;
                }
            }
        }
    }
}