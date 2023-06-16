using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListadeTareas.Models
{
    public class TareaItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tarea { get; set; }
    }
}
