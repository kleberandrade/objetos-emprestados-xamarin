using ObjetosEmprestado.Droid.Services;
using ObjetosEmprestado.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoSQLite))]
namespace ObjetosEmprestado.Droid.Services
{
    public class CaminhoSQLite : ICaminhoSQLite
    {
        public string GetCaminhoDB(string nomeDB)
        {
            string caminho = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, nomeDB);
        }
    }
}