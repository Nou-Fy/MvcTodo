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
            var req = $"INSERT INTO public.\"Utilisateur\"(\"name\", password) VALUES ('{utilisateur.Name}','{utilisateur.Password}');";
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

        public static bool Logutilisateur(Utilisateur utilisateur)
        {
            var req = $"SELECT * FROM public.\"Utilisateur\" WHERE name = '{utilisateur.Name}' AND \"password\"='{utilisateur.Password}';";
            var hasUser = false;

            try
            {
                connectionstring.Open();
                var cmd = new NpgsqlCommand(req, connectionstring);
                var reader = cmd.ExecuteReader();
                hasUser = reader.HasRows;
                connectionstring.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return hasUser;
        }
    }
}