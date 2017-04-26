using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos___Listas_enlazadas
{
    public class Producto
    {

        public Producto productoSiguiente{get;set;}
        String _nombre;
        String _cantidad;
        String _codigo;
        String _precio;
        int _posicion;

        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public String cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public String precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public Producto(String number, String quantity, String code, String price, int pos)
        {

            productoSiguiente = null;
            _nombre = number;
            _cantidad = quantity;
            _codigo = code;
            _precio = price;
            _posicion = pos;

        }

        public override string ToString()
        {

            String retorno;

            retorno = System.Environment.NewLine + "-POSICION = " + posicion;
            retorno += System.Environment.NewLine + "-Nombre = " + nombre;
            retorno += System.Environment.NewLine + "-Cantidad = " + cantidad;
            retorno += System.Environment.NewLine + "-Codigo = " + codigo;
            retorno += System.Environment.NewLine + "-Precio = " + precio;

            return retorno;

        }

    }

}
