namespace ElimarNodosListasEnlazadas.Server
{
    public class NodoD
    {
        public string Informacion { get; set; }
        public NodoD? ReferenciaSiguiente { get; set; }
        public NodoD? ReferenciaAnterior { get; set; }


        public NodoD()
        {
            Informacion = string.Empty;
            ReferenciaSiguiente = null;
            ReferenciaAnterior = null;
        }

        public NodoD(string informacion)
        {
            Informacion = informacion;
            ReferenciaSiguiente = null;
            ReferenciaAnterior = null;
        }

        public override string ToString()
        {
            return $"{Informacion}";
        }
    }
}
