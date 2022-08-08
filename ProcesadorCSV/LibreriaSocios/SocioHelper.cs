using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaSocios;

namespace LibreriaSocios
{
    public class SocioHelper
    {
        // Leemos el csv en el ctor de nuestro helper y luego usamos un poco de LINQ y cariño para devolver los datos pedidos

        List<String[]> listaSocios;

        //Esta listaSocios tiene toda la informacion de todos los socios. Acceder a cada dato puede ser confuso porque nos guiamos por indice, para referencia:
        //socio[0] = nombre 
        //socio[1] = edad
        //socio[2] = club
        //socio[3] = estado civil
        //socio[4] = estudios

        public SocioHelper(string path)
        {
            string[] socios = File.ReadAllLines(path);

            var query =
                from linea in socios
                let elementos = linea.Split(";")
                select elementos;
            this.listaSocios = query.ToList();
        }

        public void ContarSocios()        
        {
            Console.WriteLine(listaSocios.Count);
        }

        public void PromediarEdad()
        {
            var query =
                from elementos in listaSocios
                let edades = Int32.Parse(elementos[1])
                select edades;
            var result = query.ToList();
            var promedio = result.Average();

            Console.WriteLine(promedio);
        }

        public void top100CasadosUniversitariosEtc()
        {
            var top100Filtrado = listaSocios
                .Where(socio => socio[3].Equals("Casado"))
                .Where(socio => socio[4].Equals("Universitario"))
                .Take(100)
                .OrderBy(socio => socio[1]);

            foreach (var socio in top100Filtrado)
            {
                Console.WriteLine($"{socio[0]}, de {socio[1]} años, hincha de {socio[2]}");
            }
        }

        public void top5NombresDeRiver()
        {
            var top5 = listaSocios
                .Where(socio => socio[2].Equals("River"))
                .GroupBy(socio => socio[0])
                .OrderByDescending(socio => socio.Count())
                .Take(5)
                .Select(socio => socio.Key).ToList();
            foreach (string socio in top5)
            {
                Console.WriteLine(socio);
            }
        }
        
        public void cantidadSociosPorClubPromedioMinMax()
        {
            var clubes = listaSocios
                .Select(socio => socio[2]).Distinct().ToList();

            Dictionary<string, int> lista = new Dictionary<string, int>();

            foreach (string club in clubes)
            {
                var numeroSocios = listaSocios
                    .Where(socio => socio[2].Equals(club));
                lista.Add(club, numeroSocios.Count());   
            }

            var listaOrdernada = lista.OrderByDescending(x => x.Value);

            foreach (var club in listaOrdernada)
            {

                double promedio = listaSocios
                    .Where(socio => socio[2].Equals(club.Key))
                    .Select(socio => Int32.Parse(socio[1])).ToList().Average();
                

                double minEdad = listaSocios
                    .Where(socio => socio[2].Equals(club.Key))
                    .Select(socio => Int32.Parse(socio[1])).ToList().Min();
                

                double maxEdad = listaSocios
                    .Where(socio => socio[2].Equals(club.Key))
                    .Select(socio => Int32.Parse(socio[1])).ToList().Max();

                Console.WriteLine($"El club {club.Key} tiene {club.Value} socios, con edad promedio {promedio}, con minima edad registrada {minEdad} y maxima {maxEdad}.");

            }           

        }
    }
}
