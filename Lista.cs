using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuacion_Matematica_con_FIFO_y_LIFO
{
    class Lista
    {
        private NodoCaracter inicio, ultimo;

        public Lista()
        {
            inicio = null;
            ultimo = null;
        }
        //Agregar (PUSH).
        public void agregarPush(NodoCaracter nuevoCar)
        {
            if (inicio == null)
            {
                inicio = nuevoCar;
                ultimo = nuevoCar;
            }
            else
            {
                NodoCaracter temp = inicio;
                while (temp.siguiente != null)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevoCar;
                //nuevoCar.anterior = temp;
                ultimo = nuevoCar;
            }
        }
        //Crear Lista de la ecuación._______________________________________________________________________________________________
        public void crearListaEcuacion(string ecuacion)
        {
            for (int i = 0; i < ecuacion.Length; i++)
            {
                NodoCaracter caracterNew = new NodoCaracter(ecuacion[i].ToString());

                if (inicio == null)//En caso de no tener ningun Nodo, agrega al primer Nodo en inicio.
                {
                    inicio = caracterNew;
                    ultimo = caracterNew;
                }
                else//busca el último Nodo con un siguiente en null para poder agregar.
                {
                    NodoCaracter temp = inicio;
                    while (temp.siguiente != null)
                    {
                        temp = temp.siguiente;
                    }
                    temp.siguiente = caracterNew;
                    caracterNew.anterior = temp;
                    ultimo = caracterNew;
                }
            }
        }
        //Regresar inicio.__________________________________________________________________________________________________________
        public NodoCaracter regresarInicio()
        {
            return inicio;
        }
        //Regresar ultimo.
        public NodoCaracter regresarUltimo()
        {
            return ultimo;
        }
        //Eliminar inicio._________________________________________________________________________________________________
        public void eliminarInicio()
        {
            if (inicio == null || inicio.siguiente == null)
            {
                inicio = null;
                ultimo = null;
            }
            else
            {
                inicio = inicio.siguiente;
                inicio.anterior = null;
            }
        }
        //Eliminar (POP-COLA). eliminar el primero en entrar.
        public NodoCaracter eliminarPopCola()
        {
            NodoCaracter temp = inicio;
            if (inicio == null)
            {
                return null;
            }
            else
            {
                inicio = inicio.siguiente;
                return temp;
            }
        }
        //Eliminar (POP-PILA). eliminar el último en entrar.
        public NodoCaracter eliminarPopPila()
        {
            NodoCaracter temp = ultimo;
            if (ultimo == null)
            {
                return null;
            }
            else
            {
                ultimo = ultimo.anterior;
                return temp;

                //while (temp.siguiente != null)
                //{
                //    temp = temp.siguiente;
                //}
                //temp = temp.anterior;


                //ultimo = temp.siguiente;
                //temp = ultimo;
                //temp.siguiente = null;
                //ultimo = temp;
                //return temp;
            }
        }
        //__________________________________________________________________________________________________________________________
        /// <summary>
        /// Muestra todos los productos en el vector.
        /// </summary>
        /// <returns></returns>
        public string mostrarLista()
        {
            string cadena = "";
            NodoCaracter temp = inicio;

            while (temp != null)
            {
                cadena += temp.ToString();
                temp = temp.siguiente;
            }

            return cadena;
        }
    }
}
