﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Teste_Wakke
{
    public partial class frm_inicio : Form
    {

        public frm_inicio()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dt_formulario.SelectedRows)
            {
                dt_formulario.Rows.RemoveAt(item.Index);
            }
        }

        private void btn_cadastro_Click(object sender, EventArgs e)
        {
            frm_cadastro form = new frm_cadastro();

            if (form.ShowDialog() == DialogResult.OK)
            {
                AddRows(form.Txdcid ,form.Rbativo ,form.Txtnome, form.Txtsobrenome ,form.Txtdata ,form.Txtaltura);
            }


        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            frm_cadastro form = new frm_cadastro();
                 
            if (form.ShowDialog() == DialogResult.OK)
            {
                Int32 selectedRowCount = dt_formulario.Rows.GetRowCount(DataGridViewElementStates.Selected);
                EditRow(selectedRowCount, form.Rbativo, form.Txtnome, form.Txtsobrenome, form.Txtdata, form.Txtaltura);
            }
        }

        private void AddRows(string txdcid, bool rbativo, string txtnome, string txtsobrenome, string txtdata, string txtaltura)
        {
            dt_formulario.Rows.Add(txdcid, rbativo, txtnome, txtsobrenome, txtdata, txtaltura);
            dt_formulario.Update();
        }

        public void EditRow(int idx, bool rbativo, string txtnome, string txtsobrenome, string txtdata, string txtaltura)
        {
            dt_formulario.Rows[idx].Cells[1].Value = rbativo;
            dt_formulario.Rows[idx].Cells[2].Value = txtnome;
            dt_formulario.Rows[idx].Cells[3].Value = txtsobrenome;
            dt_formulario.Rows[idx].Cells[4].Value = txtdata;
            dt_formulario.Rows[idx].Cells[5].Value = txtaltura;

        }

        private void Lbl_titulo_Click(object sender, EventArgs e)
        {

        }

        private void dt_formulario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dt_formulario.Rows[e.RowIndex].IsNewRow)
            {
                frm_cadastro form = new frm_cadastro();

                form.Txdcid = dt_formulario.Rows[e.RowIndex].Cells[0].Value.ToString();

                form.Txtnome = dt_formulario.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.Txtsobrenome = dt_formulario.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.Txtdata = dt_formulario.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.Txtaltura = dt_formulario.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
