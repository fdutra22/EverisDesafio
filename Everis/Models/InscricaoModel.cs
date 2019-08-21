using SQLite;
using System;

namespace Everis.Models
{
    [Table("Inscricao")]
    public class InscricaoModel {
        

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int IdEvento { get; set; }
        [MaxLength(60)]
        public string Nome { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Telefone { get; set; }
        public string Tema { get; set; }
    }
}