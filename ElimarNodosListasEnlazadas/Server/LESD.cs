using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElimarNodosListasEnlazadas.Server
{
    public class LESD
    {
        public NodoD? PrimerNodo { get; set; }
        public NodoD? UltimoNodo { get; set; }

        public LESD()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }
        bool EstaVacia()
        {
            return UltimoNodo == null;
        }

        public string VaciarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            return "SE VACIO LA LISTA";
        }


        public string AgregarNodoINicio(NodoD nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
                return "Nodo Creado";
            }
            else
            {
                nuevoNodo.ReferenciaSiguiente = PrimerNodo;
                PrimerNodo.ReferenciaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }

            return $" Nodo con Informacion {nuevoNodo} Agregado con exito";

        }

        public string AgregarNodoFinal(NodoD nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
                return "Nodo Creado";
            }
            else
            {
                nuevoNodo.ReferenciaAnterior = UltimoNodo;
                UltimoNodo.ReferenciaSiguiente = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return $" Nodo con Informacion {nuevoNodo} Agregado con exito";
        }

        public string AntesDatoX(string datoX, NodoD nuevoNodo)
        {
            if (EstaVacia()) return "Lista Vacia";

            NodoD nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }

            if (nodoActual == null) return "Dato no Encontrado";

            if (nodoActual == PrimerNodo)
            {
                nuevoNodo.ReferenciaSiguiente = nodoActual;
                nodoActual.ReferenciaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
                return $"Nodo con informacion {nuevoNodo.Informacion} agregado antes de {datoX}";
            }

            nuevoNodo.ReferenciaSiguiente = nodoActual;
            nuevoNodo.ReferenciaAnterior = nodoActual.ReferenciaAnterior;

            nodoActual.ReferenciaAnterior.ReferenciaSiguiente = nuevoNodo;
            nodoActual.ReferenciaAnterior = nuevoNodo;

            return $"Nodo con informacion {nuevoNodo.Informacion} agregado antes de {datoX}";
        }

        public string DespuesDatoX(string datoX, NodoD nuevoNodo)
        {
            if (EstaVacia()) return "Lista Vacia";

            if (UltimoNodo == PrimerNodo)
            {
                AgregarNodoFinal(nuevoNodo);
                return "Nodo Insertado al Final";
            }
            NodoD nodoActual = PrimerNodo;
            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }

            if (nodoActual == null) return "Dato no Encontrado";

            nuevoNodo.ReferenciaSiguiente = nodoActual.ReferenciaSiguiente;
            nuevoNodo.ReferenciaAnterior = nodoActual;

            nodoActual.ReferenciaSiguiente.ReferenciaAnterior = nuevoNodo;
            nodoActual.ReferenciaSiguiente = nuevoNodo;

            return $"Nodo con informacion {nuevoNodo.Informacion} agregado despues de {datoX}";


        }



        public string AgregarAntesPosicionX(int posicion, NodoD nuevoNodo)
        {
            if (posicion <= 0 || PrimerNodo == null) return "Posicion invalida";

            NodoD nodoActul = PrimerNodo;
            int Indice = 0;

            while(nodoActul != null && Indice < posicion)
            {
                nodoActul = nodoActul.ReferenciaSiguiente;
                Indice++;
            }
            if (nodoActul == null) return "Posicion Invalida";

            if(nodoActul.ReferenciaSiguiente == null)
            {
                AgregarNodoINicio(nuevoNodo);
            }
            else
            {
                nuevoNodo.ReferenciaAnterior = nodoActul.ReferenciaAnterior;
                nuevoNodo.ReferenciaSiguiente = nodoActul;
                nodoActul.ReferenciaAnterior.ReferenciaSiguiente = nuevoNodo;
                nodoActul.ReferenciaAnterior = nuevoNodo;
            }

            return $"Nodo con informacion {nuevoNodo.Informacion} agregado antess de la posicion{posicion}";

        }

        public string AgregarDespuesPosicionX(int posicion, NodoD nuevoNodo)
        {
            if (posicion <= 0 || PrimerNodo == null) return "Lista Vacia";

            NodoD nodoActual = PrimerNodo;
            int Indice = 0;

            while (nodoActual != null && Indice < posicion)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
                Indice++;
            }

            if (nodoActual == null) return "Posicion Invalida";

            NodoD siguienteNodo = nodoActual.ReferenciaSiguiente;

            nuevoNodo.ReferenciaAnterior = nodoActual;
            nuevoNodo.ReferenciaSiguiente = siguienteNodo;

            nodoActual.ReferenciaSiguiente = nuevoNodo;

            if (siguienteNodo != null)
            {
                siguienteNodo.ReferenciaAnterior = nuevoNodo;
            }
            else
            {
                UltimoNodo = nuevoNodo;
            }

            return $"Nodo con informacion {nuevoNodo.Informacion} agregado después de la posición {posicion}";
        }

        public string EliminarInicio()
        {
            if (EstaVacia()) return "No existen elementos";
            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                NodoD nodoEliminado = PrimerNodo;
                PrimerNodo = PrimerNodo.ReferenciaSiguiente;
                nodoEliminado = null;
            }
            return $"Nodo Eliminado";

        }

        public string EliminarFinal()
        {
            if (EstaVacia()) return "No existen elementos";
            if(PrimerNodo  == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                NodoD nodoEliminado = UltimoNodo;

                UltimoNodo = UltimoNodo.ReferenciaAnterior;
                UltimoNodo.ReferenciaSiguiente = null;

                nodoEliminado = null;
            }

            return $"Nodo Eliminado";
        }

        public string EliminarConDatoX(string datoX)
        {
            if (EstaVacia()) return "Lista Vacia";

            NodoD nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }

            if (nodoActual == null) return $"No se encontro el nodo con informacion {datoX}";

            if(nodoActual == PrimerNodo)
            {
                PrimerNodo = nodoActual.ReferenciaSiguiente;
                if(PrimerNodo != null)
                {
                    PrimerNodo.ReferenciaAnterior = null;
                }
                else
                {
                    UltimoNodo = null;
                }
            }
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nodoActual.ReferenciaAnterior;
                UltimoNodo.ReferenciaSiguiente = null;
            }
            nodoActual.ReferenciaAnterior.ReferenciaSiguiente = nodoActual.ReferenciaSiguiente;
            nodoActual.ReferenciaSiguiente.ReferenciaAnterior = nodoActual.ReferenciaAnterior;

            return $"Nodo con informacion {datoX} Eliminado";

        }


        public string EliminarAntesDatoX(string datoX)
        {
            if (EstaVacia()) return "Lista Vacia";

            NodoD nodoActual = PrimerNodo;
            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }
            if (nodoActual != null) 
            { 
                if (nodoActual == PrimerNodo)
                {
                    return "Posicion Invalida";
                }else if(nodoActual.ReferenciaAnterior == PrimerNodo)
                {
                    EliminarInicio();
                }
                else
                {
                    nodoActual.ReferenciaAnterior.ReferenciaAnterior.ReferenciaSiguiente = nodoActual.ReferenciaAnterior.ReferenciaSiguiente;
                    nodoActual.ReferenciaAnterior = nodoActual.ReferenciaAnterior.ReferenciaAnterior;    
                }
                return $"Nodo Eliminado antes del dato {datoX}";
            }
            return "Dato no encontrado";


        }

        public string EliminarDespuesDatoX(string datoX)
        {
            if (EstaVacia()) return "Lista Vacia";
            NodoD nodoActual = PrimerNodo;
            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
            }
            if(nodoActual != null && nodoActual.ReferenciaSiguiente != null)
            {
                NodoD nodoEliminar = nodoActual.ReferenciaSiguiente;
                nodoActual.ReferenciaSiguiente = nodoEliminar.ReferenciaSiguiente;
                if(nodoEliminar.ReferenciaSiguiente != null)
                {
                    nodoEliminar.ReferenciaSiguiente.ReferenciaAnterior = nodoActual;
                }
                return $"Nodo Eliminado despues del dato {datoX}";

            }
            return "Dato no encontrado";
        }

        public string EliminarAntesDePosX(int posicion)
        {
            if (PrimerNodo == null || posicion <= 1) return "Lista Vacia";

            NodoD actual = PrimerNodo;
            int indice = 0;

            while (actual != null && indice < posicion)
            {
                actual = actual.ReferenciaSiguiente;
                indice++;
            }

            if (actual == null || actual.ReferenciaAnterior == null) return "Nodo no encontrado";

            NodoD nodoAEliminar = actual.ReferenciaAnterior;

            if (nodoAEliminar.ReferenciaAnterior != null)
            {
                nodoAEliminar.ReferenciaAnterior.ReferenciaSiguiente = actual;
                actual.ReferenciaAnterior = nodoAEliminar.ReferenciaAnterior;
            }
            else
            {
                PrimerNodo = actual;
                actual.ReferenciaAnterior = null;
            }
            nodoAEliminar.ReferenciaSiguiente = null;
            nodoAEliminar.ReferenciaAnterior = null;
            nodoAEliminar = null;

            return $"Nodo Eliminado Anres de la posicion {posicion}";

        }
        public string EliminarDespuesDePosX(int posicion)
        {
            if (EstaVacia()) return "Lista Vacia"; 
            NodoD actual = PrimerNodo;
            int Indice = 0;

            while (actual != null && Indice < posicion)
            {
                actual = actual.ReferenciaSiguiente;
                Indice++;
            }
            if (actual == null || actual.ReferenciaSiguiente == null)
            {
                return "Nodo no encontrado";
            }

            NodoD nodoAEliminar = actual.ReferenciaSiguiente;
            actual.ReferenciaSiguiente = nodoAEliminar.ReferenciaSiguiente;

            if (nodoAEliminar.ReferenciaSiguiente != null)
            {
                nodoAEliminar.ReferenciaSiguiente.ReferenciaAnterior = actual;
            }
            else
            {
                UltimoNodo = actual;
            }

            nodoAEliminar.ReferenciaSiguiente = null;
            nodoAEliminar.ReferenciaAnterior = null;
            nodoAEliminar = null;
            return $"Nodo Eliminado Despues de la posicion {posicion}";
        }

        public string Buscar(string datoX)
        {
            if (EstaVacia()) return "Lista Vacia";

            NodoD nodoActual = PrimerNodo;
            int Indice = 0;
            while (nodoActual != null && nodoActual.Informacion != datoX)
            {
                nodoActual = nodoActual.ReferenciaSiguiente;
                Indice++;
            }

            if(nodoActual == null) return "Nodo No Encontrado";

            return $"Nodo con informacion {datoX} econtrado en posicion {Indice}";


        }
        public string OrdenarLista()
        {
            if (PrimerNodo == null || PrimerNodo.ReferenciaSiguiente == null) return "Lista vacia";

            bool intercambio;
            do
            {
                intercambio = false;
                NodoD actual = PrimerNodo;
                while (actual.ReferenciaSiguiente != null)
                {
                    if (string.Compare(actual.Informacion, actual.ReferenciaSiguiente.Informacion) > 0)
                    {
                        string temp = actual.Informacion;
                        actual.Informacion = actual.ReferenciaSiguiente.Informacion;
                        actual.ReferenciaSiguiente.Informacion = temp;
                        intercambio = true;
                    }
                    actual = actual.ReferenciaSiguiente;
                }
            } while (intercambio);
            return "Lista ordenada con éxito";
        }



    }
}
