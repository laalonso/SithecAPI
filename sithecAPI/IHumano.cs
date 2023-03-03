using sithecAPI.Models;
using System.Collections.Generic;

namespace sithecAPI
{
    public interface IHumano
    {
        int sumaNumeros(int valor1, int valor2, int valor3);
        int multiplicacion(Numero nums);
        List<Humano> getHumanosMock();
        List<Humano> getHumanos();
        Humano getHumanosById(int id);
        int setHumano(Humano humano);
        void updateHumano(Humano humano);
    }
}
