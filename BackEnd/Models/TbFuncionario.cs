using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("tb_funcionario")]
    public partial class TbFuncionario
    {
        public TbFuncionario()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Column("id_login")]
        public int? IdLogin { get; set; }
        [Column("nm_funcionario", TypeName = "varchar(100)")]
        public string NmFuncionario { get; set; }
        [Column("ds_carteira_trabalho", TypeName = "varchar(11)")]
        public string DsCarteiraTrabalho { get; set; }
        [Column("ds_perfil", TypeName = "varchar(100)")]
        public string DsPerfil { get; set; }
        [Column("ds_foto", TypeName = "varchar(200)")]
        public string DsFoto { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbFuncionario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
