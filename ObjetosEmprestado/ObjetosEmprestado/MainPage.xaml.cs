using System.Collections.Generic;
using Xamarin.Forms;

using ObjetosEmprestado.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ObjetosEmprestado.Views;
using ObjetosEmprestado.Services;

namespace ObjetosEmprestado
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ObjetoEmprestado> objetosEmprestados;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            objetosEmprestados = GetTodosObjetosEmprestados();
            ObjetoListView.ItemsSource = objetosEmprestados;
            base.OnAppearing();
        }

        public ObservableCollection<ObjetoEmprestado> GetTodosObjetosEmprestados()
        {
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            return new ObservableCollection<ObjetoEmprestado>(dao.GetTodos());
        }

        private void OnAdicionarObjetoEmprestado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditObjetoPage(null));
        }

        private void OnObjetoProcurado(object sender, TextChangedEventArgs e)
        {
            string texto = ObjetoSearchBar.Text;
            ObjetoListView.ItemsSource = objetosEmprestados.Where(
                x => x.Descricao.ToLowerInvariant().Contains(texto.ToLowerInvariant())
            );
        }

        private void OnObjetoSelecionado(object sender, SelectedItemChangedEventArgs e)
        {
            ObjetoEmprestado objetoEmprestado = e.SelectedItem as ObjetoEmprestado;
            Navigation.PushAsync(new EditObjetoPage(objetoEmprestado));
        }

    }
}
