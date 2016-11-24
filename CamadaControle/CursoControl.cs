using PIM_VII.VO;
using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Control
{
    public class CursoControl
    {
        public List<Curso> GetAllCursos()
        {
            return new CursoDAL().GetAll();
        }

        public static DataSet GetAllDataSetCurso()
        {
            throw new NotImplementedException();
        }
    }
}