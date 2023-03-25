using Chipsoft.Assignments.EPDConsole.Classes;
using Chipsoft.Assignments.EPDConsole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Services
{
    public class AppointmentService : BaseService<Appointment>
    {
        public AppointmentService() : base(new AppointmentRepository())
        {
        }
    }
}
