using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTodo.Models
{
    public class Tache
    {
        private int _tacheid;
        private string _username;
        private string _desription;
        private bool _state;


        public string Username { get => _username; set => _username = value; }
        public string Desription { get => _desription; set => _desription = value; }
        public bool State { get => _state; set => _state = value; }
        public int Tacheid { get => _tacheid; set => _tacheid = value; }

        public Tache(string username, string desription, bool state)
        {
            _username = username;
            _desription = desription;
            _state = state;
        }

        public Tache(int tacheid, string username, string desription, bool state)
        {
            _tacheid = tacheid;
            _username = username;
            _desription = desription;
            _state = state;
        }

        public Tache()
        {
        }
    }
}