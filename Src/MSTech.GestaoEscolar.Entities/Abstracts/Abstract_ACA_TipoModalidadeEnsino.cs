/*
	Classe gerada automaticamente pelo MSTech Code Creator
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MSTech.Data.Common.Abstracts;
using MSTech.Validation;

namespace MSTech.GestaoEscolar.Entities.Abstracts
{	
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
    public abstract class Abstract_ACA_TipoModalidadeEnsino : Abstract_Entity
    {
		[MSNotNullOrEmpty()]
		[DataObjectField(true, true, false)]
		public virtual int tme_id { get; set; }
		[MSValidRange(100)]
		[MSNotNullOrEmpty()]
		public virtual string tme_nome { get; set; }
		[MSNotNullOrEmpty()]
		public virtual byte tme_situacao { get; set; }
		[MSNotNullOrEmpty()]
		public virtual DateTime tme_dataCriacao { get; set; }
		[MSNotNullOrEmpty()]
		public virtual DateTime tme_dataAlteracao { get; set; }

    }
}