using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace EJ03_WindowsForm
{
    public partial class FormularioAlumno : Form
    {
        Alumno nalumno = new Alumno();

        public FormularioAlumno()
        {
            InitializeComponent();
        }

        private void FormularioAlumno_load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string jsonAlumno = ParseJSON(Convert.ToInt32(txtID.Text), txtNombre.Text, txtApellidos.Text, txtDNI.Text);

            bool res = Add(jsonAlumno);

        }

        public string ParseJSON(int id, string nombre, string apellidos, string dni)
        {
            nalumno.ID = id;
            nalumno.Nombre = nombre;
            nalumno.Apellidos = apellidos;
            nalumno.DNI = dni;

            string jsonAlumno = JsonConvert.SerializeObject(nalumno);
            return jsonAlumno;
        }

        public bool Add(string jsonAlumno)
        {
            string path = @"C:\Users\G1\source\repos\EJ03_WindowsForm\alumno.Json";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter Fichero = new StreamWriter(path))
                {
                    Fichero.Write(jsonAlumno);  
                }

            }
            else if (File.Exists(path))
            {
                using (TextWriter Fichero = new StreamWriter(path))
                {
                    Fichero.Write(jsonAlumno);
                }

            }

            string textFichero = File.ReadAllText(path);
            bool comparar = String.Equals(textFichero, jsonAlumno);

            return comparar;
        }
    }
}
