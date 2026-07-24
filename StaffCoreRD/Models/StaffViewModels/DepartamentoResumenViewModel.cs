namespace StaffCoreRD.Models.StaffViewModels
{
    public class DepartamentoResumenViewModel
    {
        public string Departamento { get; set; } = string.Empty;
        public int TotalEmpleados { get; set; }
        public decimal TotalNomina { get; set; }
    }
}