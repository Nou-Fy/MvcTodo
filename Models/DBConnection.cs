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

        public static List<Tache> listetache(string username)
        {
            var req = $"SELECT * FROM public.\"tache\" WHERE username = '{username}'";
            var taches = new List<Tache>();
            try
            {
                connectionstring.Open();
                var cmd = new NpgsqlCommand(req, connectionstring);
                var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var tache = new Tache(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetBoolean(3));
                    taches.Add(tache);
                }
                connectionstring.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return taches;
        }

        public static void AjoutTache(Tache tache)
        {
            var req = $"INSERT INTO public.tache(username, description, state)VALUES( '{tache.Username}', '{tache.Desription}', '{tache.State}'); ";
            try
            {
                connectionstring.Open();
                var cmd = new NpgsqlCommand(req, connectionstring);
                cmd.ExecuteNonQuery();
                connectionstring.Close();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static void ModifierTache(int idTache, Tache tache)
        {
            var req = "UPDATE public.tache SET description= '" + tache.Desription + "' , state= '" + tache.State + "'  WHERE idtache = '" + idTache + "'";

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

        public static void SuppresionTache(int tacheid)
        {
            var req = $"DELETE FROM public.tache WHERE tacheid = '{tacheid}' ";
            try
            {
                connectionstring.Open();
                var cmd = new NpgsqlCommand(req, connectionstring);
                cmd.ExecuteNonQuery();
                connectionstring.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}