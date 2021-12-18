using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using PM2Tarea3P201820110061.Models;
using SQLite;

namespace PM2Tarea3P201820110061.Controller
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        public DataBaseSQLite(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Empleado>().Wait();
        }

        public Task<int> GuardarEmpleado(Empleado empleado)
        {
            Debug.WriteLine($"ID EMPLE A MODIF: {empleado.Id}");
            if (empleado.Id != 0)
            {
                Debug.WriteLine("Entramos a Modificar Empleado a la BD");
                return db.UpdateAsync(empleado);
            }
            else
            {
                Debug.WriteLine("Entramos a Agregar Un Nuevo Emple a la BD");
                return db.InsertAsync(empleado);
            }
        }

        public Task<int> EliminarEmpleado(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }

        public async Task<List<Empleado>> ObtenerListaEmp()
        {
            return await Task.FromResult(await db.Table<Empleado>().ToListAsync());
        }
    }
}
