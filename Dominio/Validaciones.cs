using System;

namespace BibliotecaAPI.Dominio
{
    public static class Validaciones
    {
        public static bool IsbnPalindromo(string isbn)
        {
            string palabraAlReves;
            char[] isbnToArray = isbn.ToCharArray();
            Array.Reverse(isbnToArray);
            palabraAlReves = new string(isbnToArray);
            return isbn.Equals(palabraAlReves, StringComparison.OrdinalIgnoreCase);
        }

        public static int NumeroDomingosEntreFechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            int numeroDeDomingos = 0;

            for (DateTime fecha = fechaInicial; fecha <= fechaFinal; fecha = fecha.AddDays(1))
            {
                if (fecha.DayOfWeek == DayOfWeek.Sunday)
                {
                    numeroDeDomingos++;
                }
            }
            return numeroDeDomingos;
        }

        public static int SumaIsbn(string isbn)
        {
            int contador = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
                if (isbn[i] == '1' || isbn[i] == '2' || isbn[i] == '3' || isbn[i] == '4' || isbn[i] == '5' || isbn[i] == '6' || isbn[i] == '7' || isbn[i] == '8' || isbn[i] == '9')
                {
                    int val = (int)Char.GetNumericValue(isbn[i]);
                    contador = contador + val;
                }
            }
            return contador;
        }

        public static DateTime FechaDeEntrega(DateTime fechaInicial)
        {

            const int NRO_DE_DIAS_PRESTAMO = 15;
            DateTime fechaFinal = fechaInicial.AddDays(NRO_DE_DIAS_PRESTAMO);

            int nroDeDomingos = NumeroDomingosEntreFechas(fechaInicial, fechaFinal);


            DateTime fechaDeEntrega = fechaInicial.AddDays(NRO_DE_DIAS_PRESTAMO + nroDeDomingos);

            if (fechaDeEntrega.DayOfWeek == DayOfWeek.Sunday)
            {
                fechaDeEntrega = fechaDeEntrega.AddDays(1);
            }

            return fechaDeEntrega;
        }
    }
}
