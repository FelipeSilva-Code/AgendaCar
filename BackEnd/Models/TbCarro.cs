using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("tb_carro")]
    public partial class TbCarro
    {
        public TbCarro()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_carro")]
        public int IdCarro { get; set; }
        [Column("ds_marca", TypeName = "varchar(50)")]
        public string DsMarca { get; set; }
        [Column("ds_modelo", TypeName = "varchar(50)")]
        public string DsModelo { get; set; }
        [Column("nr_ano_fabricacao")]
        public int? NrAnoFabricacao { get; set; }
        [Column("nr_ano_versao")]
        public int? NrAnoVersao { get; set; }
        [Column("ds_cor", TypeName = "varchar(50)")]
        public string DsCor { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }

        [InverseProperty("IdCarroNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
