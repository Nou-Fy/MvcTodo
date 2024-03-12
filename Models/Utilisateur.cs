using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTodo.Models
{
    public class Utilisateur
    {
        private int _id;
        private string _name;
        private string _password;

        public Utilisateur()
        {
        }

        public Utilisateur(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public Utilisateur(int id, string name, string password)
        {
            _id = id;
            _name = name;
            _password = password;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }

        public override bool Equals(object obj)
        {
            return obj is Utilisateur utilisateur &&
                   _name == utilisateur._name &&
                   _password == utilisateur._password;
        }

        public override int GetHashCode()
        {
            int hashCode = 1534016392;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_password);
            return hashCode;
        }
    }
}