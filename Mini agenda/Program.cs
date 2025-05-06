//5 - Mini Agenda Diaria
// Objetivo: Fechas y organización.
// Descripción: Crea una agenda donde cada evento tenga:

// Título

// Fecha

// Descripción

// Opciones:

// Agregar evento

// Ver eventos por fecha

// Eliminar evento

// Buscar evento por título

// Salir

using Microsoft.VisualBasic;

class Program
{
    public static string[] titulo = new string[] { };
    public static DateOnly[] Fecha = new DateOnly[0] { };
    public static string[] descripcion = new string[] { };

    public static string HistorialAgenda ="HistorialAgenda.txt";
    public static bool continuar = true;

    static void Main(string[] args)
    {
        CargarAgenda();
        while (continuar)
        {
            Console.WriteLine("================================");
            Console.WriteLine("       MINI AGENDA DIARIA       ");
            Console.WriteLine("================================");
            Console.WriteLine("1. Agregar Evento               ");
            Console.WriteLine("2. Ver Evento Por Fecha         ");
            Console.WriteLine("3. Eliminar Evento              ");
            Console.WriteLine("4. Buscar Evento Por Titulo     ");
            Console.WriteLine("5. Salir                        ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    AgregarEvento();
                    break;
                case "2":
                    EventosFecha();
                    break;
                case "3":
                    EliminarEvento();
                    break;
                case "4":
                    BuscarEventoTitulo();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;

            }
        }
    }

    public static void CargarAgenda()
    {
        var linea = File.ReadAllLines(HistorialAgenda);
        int cantidad = linea.Length;

        titulo = new string[cantidad];
        Fecha = new DateOnly[cantidad];
        descripcion = new string[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            var partes = linea[i].Split(',');
            if (partes.Length >= 3)
            {
                titulo[i] = partes[0].Trim();
                Fecha[i] = DateOnly.Parse(partes[1].Trim());
                descripcion[i] = partes[2].Trim();
            }else
        {
            Console.WriteLine($"Línea {i + 1} no valida: {linea[i]}");
        }
        } 
    }

    public static void AgregarEvento()
    {
        Console.WriteLine("Ingrese el titulo: ");
        string nuevoEvento = Console.ReadLine();

        Array.Resize(ref titulo, titulo.Length + 1);
        titulo[titulo.Length - 1] = nuevoEvento;

        Console.WriteLine("Ingrese la fecha: ");
        string newfecha = Console.ReadLine();
        DateOnly nuevafecha;

        while (!DateOnly.TryParse(newfecha, out nuevafecha))
        {
            Console.WriteLine("Formato de fecha incorrecta");
            newfecha = Console.ReadLine();
        }

        Array.Resize(ref Fecha, Fecha.Length + 1);
        Fecha[Fecha.Length - 1] = nuevafecha;

        Console.WriteLine("Ingrese la descripcion del evento: ");
        string nuevadescrip = Console.ReadLine();

        Array.Resize(ref descripcion, descripcion.Length + 1);
        descripcion[descripcion.Length - 1] = nuevadescrip;

        using (StreamWriter writer = new StreamWriter(HistorialAgenda, append: true))
        {
            writer.WriteLine($"{nuevoEvento}, {nuevafecha}, {nuevadescrip}");
        }

        Console.WriteLine("Evento agregado correctamente");
    }

    public static void EventosFecha()
    {
        if (Fecha.Length == 0)
        {
            Console.WriteLine("No hay eventos registrados");
            return;
        }
        Console.WriteLine("seleccione la fecha del evento: ");
        for (int i = 0; i < Fecha.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Fecha[i]}");
        }
        int opcionfecha = Convert.ToInt32(Console.ReadLine());

        opcionfecha -= 1;

            Console.WriteLine($"El evento de la fecha es: {titulo[opcionfecha]}, {Fecha[opcionfecha]}, {descripcion[opcionfecha]}");

    }

    public static void EliminarEvento()
    {
        if (titulo.Length == 0)
        {
            Console.WriteLine("No hay eventos registrados");
            return;
        }
        Console.WriteLine("Seleccione el evento que desea eliminar: ");
        for (int i = 0; i < titulo.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {titulo[i]}, {Fecha[i]}, {descripcion[i]}");
        }
        int eliminarEvento = Convert.ToInt32(Console.ReadLine());

        if (eliminarEvento < 1 || eliminarEvento > titulo.Length)
        {
            Console.WriteLine("Indice fuera de rango");
            return;
        }

        for (int i = eliminarEvento; i < titulo.Length - 1; i++)
        {
            titulo[i] = titulo[i + 1];
            Fecha[i] = Fecha[i + 1];
            descripcion[i] = descripcion[i + 1];

        }
        Array.Resize(ref titulo, titulo.Length - 1);
        Array.Resize(ref Fecha, Fecha.Length - 1);
        Array.Resize(ref descripcion, descripcion.Length - 1);

        using (StreamWriter writer = new StreamWriter(HistorialAgenda))
        {
            for (int i = 0; i < titulo.Length; i++)
        {
            writer.WriteLine($"{titulo[i]}, {Fecha[i]}, {descripcion[i]}");
        }
        }

        Console.WriteLine("Evento eliminado correctamente");
    }

    public static void BuscarEventoTitulo()
    {
        if (titulo.Length == 0)
        {
            Console.WriteLine("No hay eventos disponibles");
            return;
        }
        Console.WriteLine("Ingrese el titulo del evento para buscar: ");
        string buscar = Console.ReadLine();

        for (int i = 0; i < titulo.Length; i++)
        {
            if (buscar == titulo[i])
            {
                Console.WriteLine($"Evento encontrado: {titulo[i]}, {Fecha[i]}, {descripcion[i]}");
            }

        }
        

    }
}