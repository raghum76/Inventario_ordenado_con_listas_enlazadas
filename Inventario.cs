using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructura_de_datos___Listas_enlazadas
{

    public class Inventario
    {

        Producto primero;
        int _tamaño;

        public int tamaño
        {
            get { return _tamaño; }
            set { _tamaño = value; }
        }

        public Inventario()
        {

            primero = null;
            tamaño = 0;

        }

        public override string ToString()
        {

            if (primero == null)
            {

                return "Lista vacia";

            }

            else
            {

                return "Lista con datos = " + tamaño.ToString();

            }

        }

        public void Agregar(String anombre, String acantidad, String acodigo, String aprecio)
        {

            Producto nuevo = new Producto(anombre, acantidad, acodigo, aprecio, 0);
            nuevo.productoSiguiente = primero;
            primero = nuevo;
            tamaño++;
            AcomodarPosiciones();

        }

        public Producto Buscar(String bNombre)
        {

            Producto encontrado = null, actual = primero;

            while (actual != null)
            {

                if (actual.nombre == bNombre)
                {

                    encontrado = actual;
                    break;

                }

                actual = actual.productoSiguiente;

            }

            return encontrado;

        }

        public void Eliminar(String eNombre)
        {

            if (primero == null)
            {

                return;

            }

            Producto actual = primero;
            Producto anterior = primero;

            if (primero.nombre == eNombre)
            {

                if (primero.productoSiguiente != null)
                {

                    primero = primero.productoSiguiente;
                    tamaño--;

                }

                else
                {

                    primero = null;
                    tamaño = 0;

                }

            }

            else
            {

                while (actual.nombre != eNombre && actual.productoSiguiente != null)
                {

                    anterior = actual;
                    actual = actual.productoSiguiente;

                }

                if (actual.nombre == eNombre)
                {

                    anterior.productoSiguiente = actual.productoSiguiente;
                    tamaño--;
                    AcomodarPosiciones();

                }

            }

        }

        public String Reporte()
        {


            if (primero == null)
            {

                return this.ToString();

            }

            if (tamaño == 1)
            {

                return this.ToString() + primero.ToString();

            }

            String reporte = null;
            Producto actual = primero;
            Producto[] todoLosProductos = new Producto[tamaño];

            reporte = this.ToString();

            for (int i = (todoLosProductos.Length - 1); i > -1; i--)
            {

                todoLosProductos[i] = actual;
                actual = actual.productoSiguiente;

            }

            for (int i = 0; i < (todoLosProductos.Length - 1); i++)
            {

                reporte += todoLosProductos[i].ToString();

            }

            return reporte += todoLosProductos[tamaño - 1];

        }

        public void Insertar(Producto elInsertado, int pos)
        {

            if (primero == null)
            {

                return;

            }

            pos--;

            if (pos < 0)
            {

                return;

            }

            if (pos == 0)
            {

                AgregarEnInicio(elInsertado);
                return;

            }

            if (pos < (tamaño + 1))
            {

                Producto actual = primero, anterior = primero;

                while (actual.posicion != pos)
                {

                    anterior = actual;
                    actual = actual.productoSiguiente;

                    if (actual.productoSiguiente == null)
                    {
                        break;
                    }

                }

                if (actual.posicion == pos)
                {

                    if (anterior == actual)
                    {

                        anterior = actual;
                        actual = actual.productoSiguiente;
                        anterior.productoSiguiente = elInsertado;
                        elInsertado.productoSiguiente = actual;
                        tamaño++;
                        AcomodarPosiciones();
                        return;

                    }

                    if (anterior != actual)
                    {

                        anterior.productoSiguiente = elInsertado;
                        elInsertado.productoSiguiente = actual;
                        actual = actual.productoSiguiente;
                        tamaño++;
                        AcomodarPosiciones();

                    }

                }

            }

        }

        public void AgregarEnInicio(Producto elInsertado)
        {

            if (primero != null)
            {

                Producto actual = primero;

                while (actual.productoSiguiente != null)
                {

                    actual = actual.productoSiguiente;

                }

                actual.productoSiguiente = elInsertado;
                elInsertado.posicion = 1;
                tamaño++;
                AcomodarPosiciones();

            }

        }

        public void AgregarAlFinal(Producto elInsertado)
        {

            if (primero != null)
            {

                elInsertado.productoSiguiente = primero;
                primero = elInsertado;
                tamaño++;
                AcomodarPosiciones();

            }

        }

        public void AcomodarPosiciones()
        {

            if (primero != null)
            {

                int auxiliar = tamaño;
                Producto actual = primero;

                if (tamaño == 1)
                {

                    primero.posicion = 1;
                    return;

                }

                while (actual != null)
                {

                    actual.posicion = auxiliar;
                    auxiliar--;
                    actual = actual.productoSiguiente;

                }

            }

        }

        public void OrdenarPorCodigo()
        {

            if (tamaño > 1)
            {

                Producto[] todosLosProductos = new Producto[tamaño];
                Producto actual = primero;

                for (int i = (tamaño - 1); i > -1; i--)
                {

                    todosLosProductos[i] = actual;
                    actual = actual.productoSiguiente;

                }

                IEnumerable<Producto> query = todosLosProductos.OrderBy(producto => producto.codigo);
                todosLosProductos = query.ToArray();

                for (int i = 0; i < (tamaño - 1); i++)
                {

                    todosLosProductos[i + 1].productoSiguiente = todosLosProductos[i];

                }

                todosLosProductos[0].productoSiguiente = null;
                primero = todosLosProductos[tamaño - 1];
                AcomodarPosiciones();

            }

        }

    }
}
