using SQLite;
using System;

namespace Everis.Models
{
    [Table("Evento")]
    public class EventoModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Evento { get; set; }
        [MaxLength(60)]
        public string Local { get; set; }
        public string Data { get; set; }
        [MaxLength(5)]
        public string Horario { get; set; }
    }
}