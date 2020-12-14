using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_login")]
        public int? IdLogin { get; set; }
        [Column("nm_cliente", TypeName = "varchar(100)")]
        public string NmCliente { get; set; }
        [Column("ds_cnh", TypeName = "varchar(14)")]
        public string DsCnh { get; set; }
        [Column("ds_cpf", TypeName = "varchar(14)")]
        public string DsCpf { get; set; }
        [Column("ds_telefone", TypeName = "varchar(15)")]
        public string DsTelefone { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_foto", TypeName = "varchar(200)")]
        public string DsFoto { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbCliente))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
