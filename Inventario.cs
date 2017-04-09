using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario
{
    class Inventario
    {
        private Producto[] vecInventario; 
        private int _contadorInve;

        public Inventario()
        {
            _contadorInve = 0;
            vecInventario = new Producto[15];
        }

        /// <summary>
        /// Verifica que el código no se repita y el limite del vector.
        /// </summary>
        /// <param name="producto"></param>
        public void agregarProducto(Producto producto)
        {
            bool sePuedeAgregar = true;

            for (int cont = 0; cont < _contadorInve && sePuedeAgregar == true; cont++)
            {
                if (producto.codigo == vecInventario[cont].codigo)
                {
                    sePuedeAgregar = false;
                }
            }

            if (_contadorInve < 15 && sePuedeAgregar == true)
            {
                vecInventario[_contadorInve] = producto;
                _contadorInve++;
            }
        }

        /// <summary>
        /// Elimina el producto con el código ingresado y recorre a los demas productos, después borra el último.
        /// </summary>
        /// <param name="codigo"></param>
        public void eliminarProducto(int codigo)
        {
            for (int cont = 0; cont < _contadorInve; cont++)
            {
                if (codigo == vecInventario[cont].codigo)
                {
                    for (int i = cont; i < _contadorInve - 1; i++)
                    {
                        vecInventario[i] = vecInventario[i + 1];
                    }
                    vecInventario[_contadorInve - 1] = null;
                    _contadorInve--;
                    break;
                }
            }
        }

        /// <summary>
        /// Busca un producto mediante su código, en caso de no encontrar el producto regresa null.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Producto buscarProdcuto(int codigo)
        {
            bool encontroAlgo = false;
            int cont;

            for (cont = 0; cont < _contadorInve; cont++)
            {
                if (codigo == vecInventario[cont].codigo)
                {
                    encontroAlgo = true;
                    return vecInventario[cont];
                }
                else
                {
                    encontroAlgo = false;
                }
            }

            if (encontroAlgo == true)
            {
                return vecInventario[cont];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Inserta un producto en una posición asignada por el usuario entre 1 y 15.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="posicion"></param>
        public void insertarProducto(Producto producto, int posicion)//posicion de 1 a 15.
        {
            if (posicion > _contadorInve)//Condición por si acaso el usuario intenta ingresar en una posicion mayor al total de productos ingresados.
            {
                posicion = _contadorInve + 1;
            }

            bool sePuedeAgregar = true;
            for (int cont = 0; cont < _contadorInve; cont++)
            {
                if (producto.codigo == vecInventario[cont].codigo)
                {
                    sePuedeAgregar = false;
                    break;
                }
            }

            if (_contadorInve < 15 && sePuedeAgregar == true)
            {
                posicion = posicion - 1;
                for (int cont = _contadorInve; cont > posicion; cont--)
                {
                    vecInventario[cont] = vecInventario[cont - 1];
                }
                _contadorInve++;
                vecInventario[posicion] = producto;
            }
        }

        /// <summary>
        /// Muestra todos los productos en el vector.
        /// </summary>
        /// <returns></returns>
        public string reporteDeProductos()
        {
            string cadena = "";

            for (int cont = 0; cont < _contadorInve; cont++)
            {
                cadena += vecInventario[cont].ToString();
            }

            return cadena;
        }
    }
}
