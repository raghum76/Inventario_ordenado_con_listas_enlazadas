using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estructura_de_datos___Listas_enlazadas
{

    public partial class Form1 : Form
    {

        Inventario listaProductos;

        public Form1()
        {
            InitializeComponent();
            listaProductos = new Inventario();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtList.Text = listaProductos.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int parseConversion;

            if (txtNombre.TextLength != 0 && Int32.TryParse(txtPrecio.Text, out parseConversion) && Int32.TryParse(txtCantidad.Text, out parseConversion) && txtCodigo.TextLength != 0)
            {

                listaProductos.Agregar(txtNombre.Text, txtCantidad.Text, txtCodigo.Text, txtPrecio.Text);
                MessageBox.Show("Agregado!!");

            }

            else
            {
                MessageBox.Show("Las cajas de texto de cantidad y precio solo admiten numeros!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtList.Text = listaProductos.Reporte();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtNombre.TextLength != 0)
            {

                Producto encontrado = listaProductos.Buscar(txtNombre.Text);

                if (encontrado != null)
                {

                    txtList.Text = "Encontrado!!";
                    txtList.Text += encontrado.ToString();

                }

                else
                {

                    txtList.Text = "No se encontro!!";

                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtNombre.TextLength != 0)
            {

                listaProductos.Eliminar(txtNombre.Text);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int parseConversion;

            if (txtNombre.TextLength != 0 && Int32.TryParse(txtPrecio.Text, out parseConversion) && Int32.TryParse(txtCantidad.Text, out parseConversion) && Int32.TryParse(txtCodigo.Text, out parseConversion) && Int32.TryParse(txtInsertar.Text, out parseConversion))
            {

                parseConversion = Convert.ToInt32(txtInsertar.Text);
                Producto nuevo = new Producto(txtNombre.Text, txtCantidad.Text, txtCodigo.Text, txtPrecio.Text, parseConversion);
                listaProductos.Insertar(nuevo, parseConversion);

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            int parseConversion;

            if (txtNombre.TextLength != 0 && Int32.TryParse(txtPrecio.Text, out parseConversion) && Int32.TryParse(txtCantidad.Text, out parseConversion) && txtCodigo.TextLength != 0)
            {

                Producto nuevo = new Producto(txtNombre.Text, txtCantidad.Text, txtCodigo.Text, txtPrecio.Text, 0);
                listaProductos.AgregarAlFinal(nuevo);

            }

            else
            {
                MessageBox.Show("Las cajas de texto de cantidad y precio solo admiten numeros!!!");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            int parseConversion;

            if (txtNombre.TextLength != 0 && Int32.TryParse(txtPrecio.Text, out parseConversion) && Int32.TryParse(txtCantidad.Text, out parseConversion) && txtCodigo.TextLength != 0)
            {

                Producto nuevo = new Producto(txtNombre.Text, txtCantidad.Text, txtCodigo.Text, txtPrecio.Text, 0);
                listaProductos.AgregarEnInicio(nuevo);

            }

            else
            {
                MessageBox.Show("Las cajas de texto de cantidad y precio solo admiten numeros!!!");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            listaProductos.OrdenarPorCodigo();

        }
    }

}
