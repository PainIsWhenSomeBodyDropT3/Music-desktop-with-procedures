using Music.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Music.command
{
    class Error : ICommand
    {
        public object Execute(object request)
        {
            MessageBox.Show("Wrong Command");
            return null;
        }
    }
}
