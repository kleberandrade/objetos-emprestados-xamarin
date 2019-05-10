using SQLite;
using System;

namespace ObjetosEmprestado.Models
{
    public class ObjetoEmprestado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}
