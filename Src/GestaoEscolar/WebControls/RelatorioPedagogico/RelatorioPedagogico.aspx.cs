﻿namespace GestaoEscolar.WebControls.RelatorioPedagogico
{
    using MSTech.CoreSSO.BLL;
    using MSTech.GestaoEscolar.BLL;
    using MSTech.GestaoEscolar.Web.WebProject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class RelatorioPedagogico : MotherPageLogado
    {
        public long alu_id
        {
            get { return Convert.ToInt64(ViewState["alu_id"] ?? "-1"); }
            set { ViewState["alu_id"] = value; }
        }

        public int ano
        {
            get { return Convert.ToInt32(ViewState["ano"] ?? "-1"); }
            set { ViewState["ano"] = value; }
        }

        protected override void Page_PreInit(object sender, EventArgs e)
        {
            base.Page_PreInit(sender, e);
            Page.Theme = "IntranetSMEBootStrap";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (sm != null)
            {
                sm.Scripts.Add(new ScriptReference("~/Includes/jquery-2.0.3.min.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/bootstrap/bootstrap.min.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/scrolling.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/angular.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/module.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/Boletim.controller.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/calendario.controller.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/sondagem.controller.js"));
                sm.Scripts.Add(new ScriptReference("~/Includes/Angular/anotacao.controller.js"));
            }

            if (!IsPostBack)
            {
                alu_id = 1148257;
                ano = MTR_MatriculaTurmaBO.GetSelectAnoMatricula(alu_id).Select().Select(p => Convert.ToInt32(p["cal_ano"])).Max();
            }
        }
    }
}