string path = "C:\\Users\\54112\\Desktop\\socios.csv"; //IMPORTANTE!!! Añada aqui el path absoluto al archivo .csv

LibreriaSocios.SocioHelper helper = new LibreriaSocios.SocioHelper(path);

//Un pequeño menu interactivo

bool running = true;
while (running)
{
    Console.WriteLine("Bienvenido al procesador de archivos CSVs para la Superliga!. \n" +
    "Escriba 'contar socios' para ver el numero de socios. \n" +
    "Escriba 'promedio edad' para ver la edad promedio de todos los socios. \n" +
    "Escriba 'top100' para ver el listado de las primeras 100 personas casadas y unviersitarias, ordenada por edad. \n" +
    "Escriba 'top5river' para ver el listado de los 5 nombres mas comunes de socios de river. \n" +
    "Escriba 'resumen general' para ver la cantidad de socios de cada equipo y algunas estadisticas más! \n" +
    "Escriba 'salir' para finalizar la aplicacion.");


    switch (Console.ReadLine())
    {
        case "contar socios":
            Console.Clear();
            helper.ContarSocios();
            Console.WriteLine();
            break;
        case "promedio edad":
            Console.Clear();
            helper.PromediarEdad();
            Console.WriteLine();
            break;
        case "top100":
            Console.Clear();
            helper.top100CasadosUniversitariosEtc();
            Console.WriteLine();
            break;
        case "top5river":
            Console.Clear();
            helper.top5NombresDeRiver();
            Console.WriteLine();
            break;
        case "resumen general":
            Console.Clear();
            helper.cantidadSociosPorClubPromedioMinMax();
            Console.WriteLine();
            break;
        case "salir":
            running = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("No entendí esa opcion, por favor verificar input");
            Console.WriteLine();
            break;
    }

}

