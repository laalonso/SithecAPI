using sithecAPI.Models;
using System.Linq;

namespace sithecAPI.Data
{
    public class DbInitializer
    {

        public static void Initialize(HumanoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Humanos.Any())
            {
                return;
            }

            var humanos = new Humano[]
            {
            new Humano{Nombre="Alejandro", Sexo="Masculino", Edad=30, Altura=165, Peso=65.200},
            new Humano{Nombre="Juliana", Sexo="Femenino", Edad=23, Altura=175, Peso=98.400},
            new Humano{Nombre="Homero",Sexo="Masculino", Edad=45, Altura=158, Peso=50.100},
            new Humano{Nombre="Alexa",Sexo="Femenino", Edad=27, Altura=160, Peso=65.200},
            new Humano{Nombre="Carlos",Sexo="Masculino", Edad=18, Altura=170, Peso=89.300},
            };
            foreach (Humano s in humanos)
            {
                context.Humanos.Add(s);
            }
            context.SaveChanges();

        }
    }
}

