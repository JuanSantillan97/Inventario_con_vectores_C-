using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuacion_Matematica_con_FIFO_y_LIFO
{
    class Arbol
    {
        private NodoCaracter raiz;

        public Arbol()
        {
            raiz = null;
        }

        //Llenar Árbol._____________________________________________________________________________________________________________
        public void llenarArbol(string ecuacion)
        {
            Lista listaEcuacion = new Lista();

            listaEcuacion.crearListaEcuacion(ecuacion);
            raiz = listaEcuacion.regresarInicio();
            NodoCaracter temp = raiz;

            //Multiplicación y División.--------------------------------------------------------------------------------------------
            while (temp != null)
            {
                if (temp.dato == "*" || temp.dato == "/")
                {
                    if (temp.hIzq == null && temp.hDer == null)
                    {
                        temp.hIzq = temp.anterior;
                        temp.hDer = temp.siguiente;
                        //Unión del siguiente.
                        NodoCaracter temp2 = temp.siguiente.siguiente;
                        if (temp2 != null)
                        {
                            temp2.anterior = temp;
                            temp.siguiente = temp2;
                        }
                        else
                        {
                            temp.siguiente = null;
                        }
                        //Unión del anterior.
                        temp2 = temp.anterior.anterior;
                        if (temp2 != null)
                        {
                            temp.anterior = temp2;
                            temp2.siguiente = temp;
                        }
                        else
                        {
                            listaEcuacion.eliminarInicio();
                        }
                    }
                }
                temp = temp.siguiente;
            }
            //Suma y Resta.---------------------------------------------------------------------------------------------------------
            temp = listaEcuacion.regresarInicio();
            while (temp != null)
            {
                if (temp.dato == "+" || temp.dato == "-")
                {
                    if (temp.hIzq == null && temp.hDer == null)
                    {
                        temp.hIzq = temp.anterior;
                        temp.hDer = temp.siguiente;
                        //Unión del siguiente.
                        NodoCaracter temp2 = temp.siguiente.siguiente;
                        if (temp2 != null)
                        {
                            temp2.anterior = temp;
                            temp.siguiente = temp2;
                        }
                        else
                        {
                            temp.siguiente = null;
                        }
                        //Unión del anterior.
                        temp2 = temp.anterior.anterior;
                        if (temp2 != null)
                        {
                            temp.anterior = temp2;
                            temp2.siguiente = temp;
                        }
                        else
                        {
                            listaEcuacion.eliminarInicio();
                        }
                    }
                }
                temp = temp.siguiente;
            }
            raiz = listaEcuacion.regresarInicio();
        }

        //Pre Orden (PRIVADO)._________________________________________________________________________________________________
        private string preOrdenPrivate(NodoCaracter nRaiz)
        {
            string cadena = "";
            if (nRaiz != null)
            {
                cadena += nRaiz.ToString();             //Raiz
                cadena += preOrdenPrivate(nRaiz.hIzq);  //Izquierda
                cadena += preOrdenPrivate(nRaiz.hDer);  //Derecha
            }
            return cadena;
        }
        //Pre Orden.
        public string preOrden()
        {
            if (raiz == null)
            {
                return "No hay nada...";
            }
            else
            {
                return preOrdenPrivate(raiz);
            }
        }
        //Post Orden (PRIVADO).___________________________________________________________________________________________________
        private string postOrdenPrivate(NodoCaracter nRaiz)
        {
            string cadena = "";
            if (nRaiz != null)
            {
                cadena += postOrdenPrivate(nRaiz.hIzq);  //Izquierda
                cadena += postOrdenPrivate(nRaiz.hDer);  //Derecha
                cadena += nRaiz.ToString();             //Raiz
            }
            return cadena;
        }
        //Post Orden.
        public string postOrden()
        {
            if (raiz == null)
            {
                return "No hay nada...";
            }
            else
            {
                return postOrdenPrivate(raiz);
            }
        }

        //Resolver ecuación por método Pre Orden.
        public int resolverEcuacionPreOrden()
        {
            Lista pila = new Lista();

            string cadena = preOrden();
            pila.crearListaEcuacion(cadena);

            Lista pilaDeNumeros = new Lista();
            NodoCaracter temp = pila.regresarUltimo();

            while (temp != null)
            {
                int num1 = 0, num2 = 0, resultado = 0;

                if (temp.dato == "*")
                {
                    num1 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    num2 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    resultado = num1 * num2;
                    NodoCaracter resu = new NodoCaracter(resultado.ToString());
                    pilaDeNumeros.agregarPush(resu);
                }
                else if (temp.dato == "/")
                {
                    num1 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    num2 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    resultado = num1 / num2;
                    NodoCaracter resu = new NodoCaracter(resultado.ToString());
                    pilaDeNumeros.agregarPush(resu);
                }
                else if (temp.dato == "+")
                {
                    num1 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    num2 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    resultado = num1 + num2;
                    NodoCaracter resu = new NodoCaracter(resultado.ToString());
                    pilaDeNumeros.agregarPush(resu);
                }
                else if (temp.dato == "-")
                {
                    num1 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    num2 = Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
                    resultado = num1 - num2;
                    NodoCaracter resu = new NodoCaracter(resultado.ToString());
                    pilaDeNumeros.agregarPush(resu);
                }
                else
                {
                    pilaDeNumeros.agregarPush(temp);
                }
                temp = temp.anterior;
            }
            return Convert.ToInt32(pilaDeNumeros.eliminarPopPila().dato);
        }



        //Resolver ecuación por método Post Orden.




        //Mostrar Arbol de forma fea. (PRIVADO)_____________________________________________________________________________________
        private string mostrarArbolPrivate(NodoCaracter nRaiz)
        {
            string cadena = "";
            if (nRaiz != null)
            {
                cadena += nRaiz.ver();                      //Raiz
                cadena += mostrarArbolPrivate(nRaiz.hIzq);  //Izquierda
                cadena += mostrarArbolPrivate(nRaiz.hDer);  //Derecha
            }
            return cadena;
        }
        //Mostrar Arbol de forma fea.
        public string mostrarArbol()
        {
            if (raiz == null)
            {
                return "No hay nada...";
            }
            else
            {
                return mostrarArbolPrivate(raiz);
            }
        }
        //Mostrar Raíz._____________________________________________________________________________________________________________
        public string mostrarRaiz()
        {
            return raiz.ver();
        }
    }
}
