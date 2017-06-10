using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuacion_Matematica_con_FIFO_y_LIFO
{
    class NodoCaracter
    {
        //Hijos del Nodo
        public NodoCaracter hIzq, hDer;
        //Siguiente y Anterior del Nodo
        public NodoCaracter siguiente, anterior;

        //Dato del nodo
        private string _dato;
        public string dato
        {
            get { return _dato; }
        }

        public NodoCaracter(string dato)
        {
            _dato = dato;

            hIzq = null;
            hDer = null;
        }

        public override string ToString()
        {
            return _dato.ToString();
        }

        public string ver()
        {
            string cadena = "";
            if (hIzq != null && hDer != null)//tiene 2 hijos
            {
                cadena = "Padre: " + _dato + " (Hijo Izquierdo = " + hIzq.dato + ". Hijo Derecho = " + hDer.dato + ")" + "\r\n";
            }
            else if (hIzq != null && hDer == null)//tiene solo un hijo izquierdo
            {
                cadena = "Padre: " + _dato + " (Hijo Izquierdo = " + hIzq.dato + ")" + "\r\n";
            }
            else if (hIzq == null && hDer != null)//tiene solo un hijo derecho
            {
                cadena = "Padre: " + _dato + " (Hijo Derecho = " + hDer.dato + ")" + "\r\n";
            }
            else//no tiene hijos
            {
                cadena = "Padre: " + _dato + " (Sin hijos)" + "\r\n";
            }
            return cadena;
        }

    }
}
