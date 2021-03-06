﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Busca.aspx.cs" Inherits="GestaoEscolar.Relatorios.AtaFinalEnriquecimentoCurricular.Busca" %>

<%@ Register Src="~/WebControls/Combos/Novos/UCCCursoCurriculo.ascx" TagName="UCComboCursoCurriculo"
    TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/Combos/UCComboUAEscola.ascx" TagName="UCComboUAEscola"
    TagPrefix="uc3" %>
<%@ Register Src="~/WebControls/Combos/Novos/UCCTurma.ascx" TagName="UCComboTurma"
    TagPrefix="uc4" %>
<%@ Register Src="~/WebControls/Combos/Novos/UCCCalendario.ascx" TagName="UCComboCalendario"
    TagPrefix="uc5" %>
<%@ Register Src="~/WebControls/BuscaAluno/UCCamposBuscaAluno.ascx" TagName="UCCamposBuscaAluno"
    TagPrefix="uc6" %>
<%@ Register Src="~/WebControls/Combos/Novos/UCCCurriculoPeriodo.ascx" TagName="UCComboCurriculoPeriodo"
    TagPrefix="uc7" %>
<%@ Register Src="~/WebControls/Mensagens/UCTotalRegistros.ascx" TagName="UCTotalRegistros"
    TagPrefix="uc8" %>
<%@ Register Src="~/WebControls/Mensagens/UCCamposObrigatorios.ascx" TagName="UCCamposObrigatorios"
    TagPrefix="uc10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updMensagem" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="EnriquecimentoCurricular" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="uppPesquisa" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <fieldset id="fdsPesquisa" runat="server" style="margin-left: 10px;">
                    <legend>Ata final de enriquecimento curricular</legend>
                    <uc10:UCCamposObrigatorios ID="UCCamposObrigatorios" runat="server" Visible="false" />
                    <div id="_divPesquisa" class="divPesquisa area-form" runat="server">
                        <asp:Label ID="lblAvisoMensagem" runat="server"></asp:Label>
                        <!-- FiltrosPadrao -->
                        <uc3:UCComboUAEscola ID="UCComboUAEscola" runat="server" CarregarEscolaAutomatico="true"
                            MostrarMessageSelecioneEscola="true" MostrarMessageSelecioneUA="true" OnIndexChangedUA="UCComboUAEscola_IndexChangedUA"
                            OnIndexChangedUnidadeEscola="UCComboUAEscola_IndexChangedUnidadeEscola" ValidationGroup="EnriquecimentoCurricular"
                            ObrigatorioEscola="true" ObrigatorioUA="true" />
                        <uc5:UCComboCalendario ID="UCComboCalendario1" runat="server" MostrarMensagemSelecione="true" ValidationGroup="EnriquecimentoCurricular"
                            Obrigatorio="true" />
                        <uc2:UCComboCursoCurriculo ID="UCComboCursoCurriculo1" MostrarMensagemSelecione="true"
                            runat="server" ValidationGroup="EnriquecimentoCurricular" Obrigatorio="true" />
                        <uc7:UCComboCurriculoPeriodo ID="UCComboCurriculoPeriodo1" MostrarMensagemSelecione="true"
                            runat="server" ValidationGroup="EnriquecimentoCurricular" Obrigatorio="true" />
                        <uc4:UCComboTurma ID="UCComboTurma1" runat="server" MostrarMessageSelecione="true" ValidationGroup="EnriquecimentoCurricular"
                            Obrigatorio="true" />
                    </div>
                    <div class="right area-botoes-bottom">
                        <asp:Button ID="btnGerarRel" runat="server" Text="<%$ Resources:Relatorios, AtaFinalEnriquecimentoCurricular.Busca.btnGerarRel.Text %>" OnClick="btnGerarRel_Click"
                            ValidationGroup="EnriquecimentoCurricular" />
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
