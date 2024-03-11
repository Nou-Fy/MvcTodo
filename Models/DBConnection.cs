using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcTodo.Models
{
    
    public class DBConnection
    {
        public static NpgsqlConnection connectionstring = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        public static void InsererUtilisateur(Utilisateur utilisateur)
        {
            var req = $"INSERT INTO public.\"Utilisateur\"(\"NomUtilisateur\", password) VALUES ('{utilisateur.Name}','{utilisateur.Password}');";
            try
            {
                connectionstring.Open();
                var cmd = new NpgsqlCommand(req, connectionstring);
                cmd.ExecuteNonQuery();
                connectionstring.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}