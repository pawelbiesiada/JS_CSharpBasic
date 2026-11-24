using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class AppConfiguration
    {        
        private string _path;

        public CultureInfo Language { get; private set; }

        public AppConfiguration(string path) 
        {
            _path = path;
            Init(_path);
        }

        private void Init(string path)
        {
            //odczytac plik z  sciezki path
            // ustawic Language na podstawie pliku
            Language = new CultureInfo("pl-pl");
        }

        public void Reload(string path = null)
        {
            if(path != null) 
                _path = path;
            Init(_path);
        }
    }
}
