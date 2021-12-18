using System;
using SQLite;
namespace PM2Tarea3P201820110061.Models
{
    public class Empleado
    {
        public Empleado()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Apellidos { get; set; }

        public int Edad { get; set; }

        [MaxLength(200)]
        public String Direccion { get; set; }

        [MaxLength(100)]
        public String Puesto { get; set; }
    }
}
