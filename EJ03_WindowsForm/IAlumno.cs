using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03_WindowsForm
{
    public interface IAlumno
    {
        string ParseJSON(int id, string nombre, string apellido, string dni);

        bool Add(string nalumno);
    }
}
