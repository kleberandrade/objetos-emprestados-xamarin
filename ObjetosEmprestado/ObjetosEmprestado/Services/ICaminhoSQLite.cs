using System;
using System.Collections.Generic;
using System.Text;

namespace ObjetosEmprestado.Services
{
    public interface ICaminhoSQLite
    {
        string GetCaminhoDB(string nomeDB);
    }
}
