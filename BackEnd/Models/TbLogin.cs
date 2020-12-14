using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("tb_login")]
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbCliente = new HashSet<TbCliente>();
            TbFuncionario = new HashSet<TbFuncionario>();
        }

        [Key]
        [Column("Id_login")]
        public int IdLogin { get; set; }
        [Column("ds_email", TypeName = "varchar(50)")]
        public string DsEmail { get; set; }
        [Column("ds_senha", TypeName = "varchar(50)")]
        public string DsSenha { get; set; }
        [Column("ds_perfil", TypeName = "varchar(50)")]
        public string DsPerfil { get; set; }
        [Column("dt_ultimo_login", TypeName = "datetime")]
        public DateTime? DtUltimoLogin { get; set; }

        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbCliente> TbCliente { get; set; }
        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbFuncionario> TbFuncionario { get; set; }
    }
}
