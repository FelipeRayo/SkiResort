namespace SkiResort
{
    public class FlightRoute
    {

        // Crear un arreglo
        int[,] matriz = new int[,]
        {
            { 2 , 36, 44, 7 , 13, 26, 37, 18, 12, 1 },
            { 48, 22, 30, 43, 39, 49, 28, 23, 9, 11 },
            { 4 , 45, 15, 6, 20, 35, 25, 19, 31, 16 },
            { 46, 29, 21, 34, 40, 14, 24, 3, 27, 38 },
            { 50, 32, 5 , 42, 8, 41, 47, 10, 33, 17 },
            { 15, 31, 1 , 26, 5, 25, 20, 38, 33, 36 },
            { 28, 43, 19, 29, 21, 50, 18, 13, 9, 32 },
            { 14, 41, 2 , 47, 11, 44, 16, 10, 30, 8 },
            { 40, 37, 7 , 35, 34, 48, 23, 22, 46, 39 },
            { 4 , 6 , 27, 42, 24, 12, 17, 3, 45, 49 }
        };

        public FlightRoute()
        {
            List<Nodo> nodoVuelos = BuscarMaximoValor(matriz);

            Console.WriteLine("El número más grande de la matriz es: {0}", nodoVuelos[0].NumeroCelda);
            Console.WriteLine("Los números más grandes de la matriz son: ");
            foreach (var vuelo in nodoVuelos)
            {
                Console.Write($"Numero de celda: {vuelo.NumeroCelda}, coordenadas: {vuelo.Coordenada}");
                foreach (var ady in vuelo.Adyacentes)
                {
                    Console.WriteLine("Adyacentes: " + string.Join(",", ady.NumeroAdy) + " coordenada ady: " + string.Join(",", ady.Coordenada));
                }
            }
        }

        public List<Nodo> BuscarMaximoValor(int[,] matrix)
        {
            List<Nodo> vuelos = new List<Nodo>();
            Nodo nodo = new Nodo();
            int max = matrix[0, 0];
            nodo.NumeroCelda = max;
            nodo.Coordenada = (0, 0);


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];

                        nodo.NumeroCelda = max;
                        nodo.Coordenada = (i, j);
                        nodo.Adyacentes = getAdy((i, j));
                        vuelos.Clear();
                        vuelos.Add(nodo);
                    }
                    else if (matrix[i, j] == max)
                    {
                        Nodo vueloDos = new Nodo
                        {
                            NumeroCelda = max,
                            Coordenada = (i, j),
                            Adyacentes = getAdy((i, j))
                        };
                        vuelos.Add(vueloDos);
                    }
                }
            }

            return vuelos;
        }

        public List<Adyacente> getAdy((int, int) coordenadas)
        {
            List<Adyacente> adyacentes = new List<Adyacente>();

            int fila = coordenadas.Item1;
            int columna = coordenadas.Item2;

            int valor = matriz[fila, columna];

            // Comprueba si hay adyacentes a la izquierda
            if (columna > 0)
            {
                Adyacente adyacente = new Adyacente
                {
                    NumeroAdy = matriz[fila, columna - 1],
                    Coordenada = (fila, columna - 1)
                };
                adyacentes.Add(adyacente);
            }

            // Comprueba si hay adyacentes a la derecha
            if (columna < matriz.GetLength(1) - 1)
            {
                Adyacente adyacente = new Adyacente
                {
                    NumeroAdy = matriz[fila, columna + 1],
                    Coordenada = (fila, columna + 1)
                };
                adyacentes.Add(adyacente);
            }

            // Comprueba si hay adyacentes arriba
            if (fila > 0)
            {
                Adyacente adyacente = new Adyacente
                {
                    NumeroAdy = matriz[fila - 1, columna],
                    Coordenada = (fila - 1, columna)
                };
                adyacentes.Add(adyacente);
            }

            // Comprueba si hay adyacentes abajo
            if (fila < matriz.GetLength(0) - 1)
            {
                Adyacente adyacente = new Adyacente
                {
                    NumeroAdy = matriz[fila + 1, columna],
                    Coordenada = (fila + 1, columna)
                };
                adyacentes.Add(adyacente);
            }

            return adyacentes;
        }
    }

}
