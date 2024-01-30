using PracticaCORE.Models;
using PracticaCORE.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region PROCEDURE

#endregion

namespace PracticaCORE
{
    public partial class FormPractica : Form
    {
        Repository1 repo;
        private List<string> codClienteList;
        private List<string> idPedidos;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new Repository1();
            this.codClienteList = new List<string>();
            this.LoadClientes();
        }

        private void LoadClientes()
        {
            List<string> clientes = this.repo.GetClientes();
            foreach (ResumenEmpresas cliente in clientes)
            {
                this.cmbclientes.Items.Add(cliente.empresa);
                this.codClienteList.Add(cliente.codCliente);
            }
        }

        private void LoadPedidos()
        {
            List<Pedido> pedidos = this.repo.GetPedidos(codCliente);
            foreach (Pedido pedido in pedidos)
            {
                this.idPedidos.Add(pedido.codPedido);
                this.lstpedidos.Items.Add(pedido.codPedido);
            }
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cmbclientes.SelectedIndex;
            if(index != null)
            {
                string cliente = this.codClienteList[index];
                ResumenEmpresas resumenEmpresas = this.repo.FindClientes(cliente);
                this.txtcargo.Text = resumenEmpresas.cargo;
                this.txtciudad.Text = resumenEmpresas.ciudad;
                this.txtempresa.Text = resumenEmpresas.empresa;
                this.txtcontacto.Text = resumenEmpresas.contacto;
                this.txttelefono.Text = resumenEmpresas.telefono;
                this.LoadPedidos();
            }
        }
    }
}
