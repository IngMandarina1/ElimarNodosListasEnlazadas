using System.Net.Mail;

namespace ElimarNodosListasEnlazadas.Server
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacio()
        {
            return UltimoNodo == null;
        }

        public string VaciarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            return "Se vacio la lista";
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Insercion con éxito";
        }

        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Insercion con éxito";
        }
        public string AgregarAntesDatoX(string datoX, Nodo nuevoNodo)
        {
            if (EstaVacio())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            if (PrimerNodo.Informacion == datoX)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
                return "Nodo insertado antes de " + datoX;
            }

            Nodo actual = PrimerNodo;
            while (actual.Referencia != null && actual.Referencia.Informacion != datoX)
            {
                actual = actual.Referencia;
            }

            if (actual.Referencia == null) return "Dato no encontrado";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;
            return "Nodo insertado antes de " + datoX;
        }

        public string AgregarDespuesDatoX(string datoX, Nodo nuevoNodo)
        {
            Nodo actual = PrimerNodo;
            while (actual != null && actual.Informacion != datoX)
            {
                actual = actual.Referencia;
            }

            if (actual == null) return "Dato no encontrado";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (actual == UltimoNodo) UltimoNodo = nuevoNodo;

            return "Nodo insertado despues de " + datoX;
        }

        public string AgregarEnPosicion(int posicion, Nodo nuevoNodo)
        {
            if (posicion < 0) return "Posicion invalida";

            if (posicion == 0) return AgregarNodoInicio(nuevoNodo);

            Nodo actual = PrimerNodo;
            int indice = 0;

            while (actual != null && indice < posicion - 1)
            {
                actual = actual.Referencia;
                indice++;
            }

            if (actual == null) return "Posicion fuera de rango";

            nuevoNodo.Referencia = actual.Referencia;
            actual.Referencia = nuevoNodo;

            if (nuevoNodo.Referencia == null) UltimoNodo = nuevoNodo;

            return "Nodo insertado en posicion " + posicion;
        }

        public string AgregarAntesDePosicion(int posicion, Nodo nuevoNodo)
        {
            return AgregarEnPosicion(posicion - 1, nuevoNodo);
        }

        public string AgregarDespuesDePosicion(int posicion, Nodo nuevoNodo)
        {
            return AgregarEnPosicion(posicion + 1, nuevoNodo);
        }

        public void RecorrerRecursivo(Nodo? nodo)
        {
            if (nodo == null) return;

            Console.WriteLine(nodo.Informacion);
            RecorrerRecursivo(nodo.Referencia);
        }

        public Nodo? BuscarElemento(string valor)
        {
            Nodo actual = PrimerNodo;
            while (actual != null)
            {
                if (actual.Informacion == valor) return actual;
                actual = actual.Referencia;
            }
            return null;
        }

        public string EliminarNodoInicio()
        {
            if (EstaVacio()) return "Lista Vacia";

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            if (PrimerNodo.Referencia != null)
            {
                Nodo temporal;
                temporal = PrimerNodo;
                PrimerNodo = PrimerNodo.Referencia;
                temporal = null;
            }

            return "Nodo Eliminado al inicio";

        }
        public string EliminarNodoFinal()
        {
            if (EstaVacio()) return "Lista Vacia";

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                Nodo Actual;
                Nodo Siguiente;

                Actual = PrimerNodo;
                Siguiente = Actual.Referencia;

                while (Siguiente.Referencia != null)
                {
                    Actual = Actual.Referencia;
                    Siguiente = Actual.Referencia;
                }
                Siguiente = null;
                Actual.Referencia = null;
                UltimoNodo = Actual;
            }
            return "ULtimo Nodo  eliminado con éxito";
        }
        public string EliminiarAntesX(string datoX)
        {
            Nodo NodoAnteAnterior = PrimerNodo;
            Nodo NodoAnterior = PrimerNodo;
            Nodo NodoActual = PrimerNodo;

            while (NodoActual != null && !NodoActual.Informacion.Equals(datoX))
            {
                NodoAnteAnterior = NodoAnterior;
                NodoAnterior = NodoActual;
                NodoActual = NodoActual.Referencia;
            }
            if (NodoActual != null)
            {
                if (NodoActual == PrimerNodo)
                {
                    return "No existe nodo para eliminar";
                }
                else if (NodoAnterior == NodoAnteAnterior)
                {
                    EliminarNodoInicio();
                }
                else
                {
                    NodoAnteAnterior.Referencia = NodoAnterior.Referencia;
                    NodoAnterior = null;
                }
                return $"Nodo Eliminado antes del dato {datoX}";

            }
            else
            {
                return "Dato no encontrado";
            }



        }
        public string EliminarDespuesDatoX(string datoX)
        {
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && !nodoActual.Informacion.Equals(datoX))
            {
                nodoActual = nodoActual.Referencia;
            }
            if (nodoActual == null)
            {
                return "Dato no encontrado";
            }
            if (nodoActual.Referencia == null)
            {
                return "No existe nodo para eliminar";
            }
            Nodo tempo = nodoActual.Referencia;
            nodoActual.Referencia = tempo.Referencia;

            if (tempo == UltimoNodo)
            {
                UltimoNodo = nodoActual;
            }
            tempo = null;
            return $"Nodo Eliminado despues del dato {datoX}";
        }

        public string EliminarEnPosicion(int posicion)
        {
            Nodo actual = PrimerNodo;
            Nodo anterior;

            if (posicion < 0) return "Posicion invalida";

            if (posicion == 0)
            {
                if (PrimerNodo == null) return "Lista Vacia";

                PrimerNodo = PrimerNodo.Referencia;
                if (PrimerNodo == null)
                {
                    UltimoNodo = null;
                }
                return "Nodo eliminado en posicion" + posicion;
            }

            int indice = 0;

            while (actual != null && indice < posicion - 1)
            {
                actual = actual.Referencia;
                indice++;
            }

            if (actual == null || actual.Referencia == null) return "Posicion fuera de rango";

            anterior = actual.Referencia;
            actual.Referencia = anterior.Referencia;

            if (anterior == UltimoNodo)
            {
                UltimoNodo = actual;
            }

            return "Nodo elimiado en posicion " + posicion;
        }
        public string OrdenarLista()
        {
            if (PrimerNodo == null || PrimerNodo.Referencia == null) return "Lista vacia";

            bool intercambio;
            do
            {
                intercambio = false;
                Nodo actual = PrimerNodo;
                while (actual.Referencia != null)
                {
                    if (string.Compare(actual.Informacion, actual.Referencia.Informacion) > 0)
                    {
                        string temp = actual.Informacion;
                        actual.Informacion = actual.Referencia.Informacion;
                        actual.Referencia.Informacion = temp;
                        intercambio = true;
                    }
                    actual = actual.Referencia;
                }
            } while (intercambio);
            return "Lista ordenada con éxito";
        }
    }
}
