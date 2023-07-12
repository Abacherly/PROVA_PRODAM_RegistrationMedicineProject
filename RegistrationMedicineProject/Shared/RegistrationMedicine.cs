using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationMedicineProject.Shared
{
    public class RegistrationMedicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Administration { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public Retention Retention { get; set; }
        public int RetentionId { get; set; }
    }
}
