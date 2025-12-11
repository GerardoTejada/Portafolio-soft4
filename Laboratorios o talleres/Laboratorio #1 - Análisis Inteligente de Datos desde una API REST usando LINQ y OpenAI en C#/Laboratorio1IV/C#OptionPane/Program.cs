
using C_OptionPane.Clases;

namespace principal
{
    class main // Clase principal
    {
        static void Main(string[] args)
        { 
            // Variables / objetos
            var rq = new restQueries();


            // Procesos
            try
            {
                //rq.impAllData(); // imprimir los datos que estan en el JSON (Borrar o modificar esta linea despues)( se ve feo xd)
                
                //1. Console.WriteLine("Datos con userId mayor a 8");
                //rq.impAllData(rq.EscogeruserIDDespuesDel8()); // Imprime los datos que cumplen la condicion del metodo EscogeruserIDDespuesDel8

                //2 Console.WriteLine("Datos con 'voluptas' en el titulo");
                //rq.impAllData(rq.LibrosQueTenganEnTitulovoluptas()); // Imprime los datos que cumplen la condicion del metodo LibrosQueTenganEnTitulovoluptas

                //3 Console.WriteLine("Datos ordenados por titulo A-Z con ID mayor a 50");
                //rq.impAllData(rq.OrdenarPorTituloAscConIDmayorA50()); // Imprime los datos que cumplen la condicion del metodo OrdenarPorTituloAscConIDmayorA50

                //4 Console.WriteLine("Datos ordenados por ID de mayor a menor con ID menor a 50");
                //rq.impAllData(rq.OrdenarPorIdDescConIDMenor50()); // Imprime los datos que cumplen la condicion del metodo OrdenarPorIdDescConIDMenor50

                //5 Console.WriteLine("datos con id y titulo");
                //rq.impAllData(rq.SeleccionarIdyTituloDeLosTresPrimeros()); //Imprime los datos que cumplen la condicion del metodo SeleccionarIdyTitulo

                //6 Console.WriteLine($"Total de registros: {rq.ContarRegistros()}"); // Imprime el total de registros que hay en el JSON

                //7 Console.WriteLine($"Promedio de caracteres en títulos: {rq.PromedioCaracteresTitulos():F2}"); // Imprime el promedio de caracteres en los títulos con 2 decimales

                //8 Console.WriteLine($"Título más largo: {rq.LongitudMaximaTitulo()} caracteres");// Imprime la longitud del título más largo

                //9 Console.WriteLine($"Título más corto: {rq.LongitudMinimaTitulo()} caracteres");// Imprime la longitud del título más corto

                //10 Console.WriteLine($"Promedio de caracteres en body: {rq.PromedioCaracteresBody():F2}");// Imprime el promedio de caracteres en los body con 2 decimales
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

