using Microsoft.EntityFrameworkCore;
using sithecAPI.Data;
using sithecAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sithecAPI.Middleware
{
    public class HumanoManager: IHumano
    {
        private HumanoContext _humanoContext;

       public HumanoManager(HumanoContext humanoContext)
       {
            _humanoContext = humanoContext;
       }

        public List<Humano> getHumanosMock()
        {
            List<Humano> humanos = new List<Humano>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                var random = r.Next(1, 100);
                var randomAltura = r.NextDouble();
                var randomPeso = r.NextDouble();

                humanos.Add(new Humano
                {
                    id = random,
                    Nombre = "Persona_" + random,
                    Sexo = (i % 2 != 0 ? "Femenino" : "Masculino"),
                    Altura = randomAltura,
                    Peso = randomPeso
                }); ;
                ; 
            }
            return humanos;
        }

        public int multiplicacion(Numero nums)
        {
            return nums.valor1 * nums.valor2 * nums.valor3;
        }

        public int sumaNumeros(int valor1, int valor2, int valor3)
        {
            return valor1 + valor2 + valor3;
        }

        public List<Humano> getHumanos()
        {
            return _humanoContext.Humanos.ToList();
        }

        public Humano getHumanosById(int id)
        {
            return _humanoContext.Humanos.Find(id);
        }

        public int setHumano(Humano humano)
        {
            _humanoContext.Humanos.Add(humano);
            _humanoContext.SaveChanges();

            return humano.id;
        }

        public void updateHumano(Humano humano)
        {
            _humanoContext.Entry(humano).State = EntityState.Modified;
            _humanoContext.Humanos.Update(humano);

            _humanoContext.SaveChanges();
        }
    }
}
