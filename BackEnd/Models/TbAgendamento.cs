using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("tb_agendamento")]
    public partial class TbAgendamento
    {
        [Key]
        [Column("id_agendamento")]
        public int IdAgendamento { get; set; }
        [Column("id_funcionario")]
        public int? IdFuncionario { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_carro")]
        public int IdCarro { get; set; }
        [Column("ds_situacao", TypeName = "varchar(50)")]
        public string DsSituacao { get; set; }
        [Column("dt_agendamento", TypeName = "datetime")]
        public DateTime DtAgendamento { get; set; }
        [Column("nr_avaliacao")]
        public int? NrAvaliacao { get; set; }

        [ForeignKey(nameof(IdCarro))]
        [InverseProperty(nameof(TbCarro.TbAgendamento))]
        public virtual TbCarro IdCarroNavigation { get; set; }
        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbAgendamento))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbAgendamento))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
    }
}
