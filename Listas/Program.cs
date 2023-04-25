// See https://aka.ms/new-console-template for more information
using codehouse_1.Clases;

List<Persona> listaPersonas = new List<Persona>();

Persona persona1 = new Persona
{
    Nombre = "Pedro",
    Apellido = "Sanchez",
    Edad = 39
};

Persona persona2 = new Persona
{
    Nombre = "Ismael",
    Apellido = "De la Poza",
    Edad = 32
};

listaPersonas.Add(persona1);
listaPersonas.Add(persona2);

List<Persona> personas2 = new List<Persona>
{
    new Persona
    {
        Nombre = "Pedro",
        Apellido = "Sanchez",
        Edad = 39
    },
    new Persona
    {
        Nombre = "Ismael",
        Apellido = "De la Poza",
        Edad = 32
    }
};

foreach(Persona p in personas2)
{
    Console.WriteLine(p.Nombre + " " + p.Apellido);
}

List<Coche> listCoches = new List<Coche>
{
    new Coche
    {
        Marca = "Seat",
        Combustible = "Gasolina",
        NumeroPuertas = 5
    },
    new Coche
    {
        Marca = "Renault",
        Combustible = "Gasoil",
        NumeroPuertas = 5
    },
    new Coche
    {
        Marca = "Bmw",
        Combustible = "Gasolina",
        NumeroPuertas = 5
    },

};


List<Camion> listaCamiones = new List<Camion>
{
    new Camion
    {
        Combustible="Diesel",
        Carga = 1000,
        Marca = "Iveco"
    },
     new Camion
    {
        Combustible="Diesel",
        Carga = 1100,
        Marca = "Reanult"
    },
};

listCoches.Add(new Coche
{
    Marca = "Dacia",
    Combustible = "Diesel",
    NumeroPuertas = 3
});

listCoches.RemoveAt(2);

ImprimirCoches();

List<Camion> listaCamiones2 = new List<Camion>
{
    new Camion
    {
        Combustible="Diesel",
        Carga = 1000,
        Marca = "MAN"
    },
     new Camion
    {
        Combustible="Diesel",
        Carga = 1100,
        Marca = "Mercedes"
    },
};

listaCamiones.AddRange(listaCamiones2);

ImprimirCamion();

void ImprimirCoches()
{
    foreach(Coche c in listCoches)
    {
        Console.WriteLine($"El coche: {c.Marca} es de {c.Combustible} y tiene {c.NumeroPuertas}");
    }
}

void ImprimirCamion()
{
    foreach (Camion c in listaCamiones)
    {
        Console.WriteLine($"El Camion: {c.Marca} es de {c.Combustible} y soporta {c.Carga}");
    }
}


List<Libro> listaLibros = new List<Libro>
{
    new Libro
    {
        Titulo = "Titulo1",
        Autor = listaPersonas[0],
        AnioPublicacion = 1999
    },
    new Libro
    {
        Titulo = "Titulo2",
        Autor = listaPersonas[0],
        AnioPublicacion = 1993
    },
    new Libro
    {
        Titulo = "Titulo2",
        Autor = listaPersonas[0],
        AnioPublicacion = 1992
    },
    new Libro
    {
        Titulo = "Titulo3",
        Autor = listaPersonas[0],
        AnioPublicacion = 1994
    },
    new Libro
    {
        Titulo = "Titulo4",
        Autor = listaPersonas[1],
        AnioPublicacion = 1999
    },
    new Libro
    {
        Titulo = "Titulo5",
        Autor = listaPersonas[1],
        AnioPublicacion = 1993
    },
    new Libro
    {
        Titulo = "Titulo6",
        Autor = listaPersonas[1],
        AnioPublicacion = 1992
    },
    new Libro
    {
        Titulo = "Titulo7",
        Autor = listaPersonas[1],
        AnioPublicacion = 1994
    },
    new Libro
    {
        Titulo = "Titulo8",
        Autor = listaPersonas[1],
        AnioPublicacion = 1993
    },
    new Libro
    {
        Titulo = "Titulo9",
        Autor = listaPersonas[1],
        AnioPublicacion = 1992
    },
    new Libro
    {
        Titulo = "Titulo10",
        Autor = listaPersonas[1],
        AnioPublicacion = 1994
    },
};

List<Editorial> listaEditoriales = new List<Editorial>
{
    new Editorial
    {
        Nombre = "Editorial1",
        Libros = new List<Libro>
        {
            listaLibros[0],
            listaLibros[1],
            listaLibros[2],
            listaLibros[3],
            listaLibros[4],
        }
    },
    new Editorial
    {
        Nombre = "Editorial2",
        Libros = new List<Libro>
        {
            listaLibros[5],
            listaLibros[6],
            listaLibros[7],
        }
    },
     new Editorial
    {
        Nombre = "Editorial2",
        Libros = new List<Libro>
        {
            listaLibros[8],
            listaLibros[9],
            listaLibros[10],
        }
    },

};

imprimirEditorial();

Console.WriteLine("\n---------Creacion nuevos items--------\n");

Persona nuevaPersona = new Persona
{
    Nombre = "Autor3",
    Apellido = "Autor3.3",
    Edad = 32
};

listaPersonas.Add(nuevaPersona);

Libro nuevoLibro = new Libro
{
    Titulo = "titulo11",
    AnioPublicacion = 1873,
    Autor = nuevaPersona
};

listaLibros.Add(nuevoLibro);

Editorial nuevaEditorial = new Editorial
{
    Nombre = "Editorial4",
    Libros = new List<Libro>
    {
        nuevoLibro
    }
};

listaEditoriales.Add(nuevaEditorial);

imprimirEditorial();

Console.WriteLine("\n---------Borrado de persona--------\n");


listaPersonas.RemoveAt(1);

imprimirEditorial();

void imprimirEditorial()
{
    foreach (Editorial e in listaEditoriales)
    {
        Console.WriteLine(e.Nombre);
        foreach(Libro l in e.Libros)
        {
            Console.WriteLine($"Titulo: {l.Titulo} Año: {l.AnioPublicacion} Autor: {l.Autor.Nombre}");
        }
    }

}
