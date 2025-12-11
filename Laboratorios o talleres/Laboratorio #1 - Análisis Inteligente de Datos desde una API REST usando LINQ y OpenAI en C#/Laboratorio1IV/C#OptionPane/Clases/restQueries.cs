using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_OptionPane.Clases
{
    internal class restQueries
    {
        private List<rest> restDatas = new List<rest>(); // Lista en donde se guardara los datos del JSON 

        public restQueries() // Metodo construcctor
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\apiRest.json");
            using (StreamReader reader = new StreamReader(path)) //lee el archivo json
            {
                string json = reader.ReadToEnd();
                this.restDatas = System.Text.Json.JsonSerializer.Deserialize<List<rest>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        // Metodos
        public IEnumerable<rest> getAllData()  // Metodo para obtener datos de la lista restDatas
        {
            return restDatas;
        }

        public void impAllData(IEnumerable<rest> restDatas) // Metodo para imprimir por cada objeto la lista de restDatas
        {
            Console.WriteLine("{0,-30} {1,50} {2,50} {3,50}", "userId", "id", "title", "body");
            foreach (var i in restDatas)
            {
                Console.WriteLine("{0,-30} {1,50} {2,50} {3,50}", i.userId, i.id, i.title, i.body);
            }
        }

        public IEnumerable<rest> EscogeruserIDDespuesDel8()  //reto where
        {
            //query epresion
            return from us in restDatas where us.userId > 8 select us;
        }

        public IEnumerable<rest> LibrosQueTenganEnTitulovoluptas() //reto lambda
        {
            return from vl in restDatas where vl.title.Contains("voluptas") select vl;
        }

        public IEnumerable<rest> OrdenarPorTituloAscConIDmayorA50()
        {
            // Ordena de A - Z por title y ID siendo mayor a 50
            return restDatas.Where(r => r.id > 50).OrderBy(r => r.title);
        }

        public IEnumerable<rest> OrdenarPorIdDescConIDMenor50()
        {
            // Ordena de mayor a menor por el id menor 50
            return restDatas.Where(r => r.id < 50).OrderByDescending(r => r.id);
        }

        public IEnumerable<rest> SeleccionarIdyTituloDeLosTresPrimeros()
        {
            // Devuelve solo el id y el título de cada objeto
            return restDatas.Take(3).Select(r => new rest(){id = r.id,title = r.title});
        }

        public int ContarRegistros()
        {
            return restDatas.Count();
        }

        public double PromedioCaracteresTitulos()
        {
            return restDatas.Average(r => r.title.Length);
        }

        public int LongitudMaximaTitulo()
        {
            return restDatas.Max(r => r.title.Length);
        }

        public int LongitudMinimaTitulo()
        {
            return restDatas.Min(r => r.title.Length);
        }

        public double PromedioCaracteresBody()
        {
            return restDatas.Average(r => r.body.Length);
        }
    }
}
