using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;
using PIM_VIII.Model;

namespace PIM_VIII.Control
{
    public class CronogramaControl
    {
        public List<Cronograma> GetAllCronogramas()
        {
            return new CronogramaDAL().GetAll();
        }

        public Cronograma getCronogramaById(int id)
        {
            return new CronogramaDAL().GetById(id);
        }
    }
}
