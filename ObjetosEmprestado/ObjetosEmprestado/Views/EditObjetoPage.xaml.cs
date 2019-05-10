using ObjetosEmprestado.Models;
using ObjetosEmprestado.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjetosEmprestado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditObjetoPage : ContentPage
	{
        private ObjetoEmprestado objetoEmprestado;

		public EditObjetoPage (ObjetoEmprestado objetoEmprestado)
		{
			InitializeComponent ();
            if (objetoEmprestado != null)   // Editar / Excluir
            {
                this.objetoEmprestado = objetoEmprestado;
                DescricaoEntry.Text = objetoEmprestado.Descricao;
                NomeEntry.Text = objetoEmprestado.Nome;
                DataDatePicker.Date = objetoEmprestado.Data;
                Title = "Editar objeto emprestado";
                SalvarButton.IsVisible = false;
                AtualizarButton.IsVisible = true;
                ExcluirButton.IsVisible = true;
            }
            else // Novo
            {
                DataDatePicker.Date = DateTime.Now;
                Title = "Novo objeto emprestado";
            }
           
        }

        private void OnSalvar(object sender, EventArgs e)
        {
            ObjetoEmprestado objeto = new ObjetoEmprestado();
            objeto.Descricao = DescricaoEntry.Text;
            objeto.Nome = NomeEntry.Text;
            objeto.Data = DataDatePicker.Date;

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Inserir(objeto);

            Navigation.PopAsync();
        }

        private void OnAtualizar(object sender, EventArgs e)
        {
            objetoEmprestado.Descricao = DescricaoEntry.Text;
            objetoEmprestado.Nome = NomeEntry.Text;
            objetoEmprestado.Data = DataDatePicker.Date;

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Atualizar(objetoEmprestado);

            Navigation.PopAsync();
        }

        private void OnExcluir(object sender, EventArgs e)
        {
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.ExcluirPorId(objetoEmprestado.Id);
            Navigation.PopAsync();
        }
    }
}