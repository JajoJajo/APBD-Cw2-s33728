using APBD_Cw2_s33728.Models;
using APBD_Cw2_s33728.Service.EquipmentService;
using APBD_Cw2_s33728.Service.RentService;
using APBD_Cw2_s33728.Service.ReportService;
using APBD_Cw2_s33728.Service.UserService;


namespace APBD_Cw2_s33728
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Equipment rental system.\n");
            
            //Services
            
            IEquipmentService equipmentService = new EquipmentService();
            IUserService userService = new UserService();
            IRentService rentService = new RentService();
            IReportService reportService = new ReportService(equipmentService, rentService);
            
            
            //Creating equipment

            var laptop = new Laptop("Lenovo ThinkPad", 1024, "i7-12095");
            var projector = new Projector("GoodProjector x1", 3000, true);
            var camera = new Camera("Canon g7x", 20, false);

            //Adding equipment
            
            equipmentService.Add(laptop);
            equipmentService.Add(projector);
            equipmentService.Add(camera);
            
            
            //Marking as unavailable projector
            
            equipmentService.MarkUnavailable(projector.Id);
            
            //Creating Users
            
            var student = new Student("Jan", "Kowalski");
            var employee = new Employee("Anna", "Nowak");

            //Adding equipment
            
            userService.Add(student);
            userService.Add(employee);
            
            //Show all equipment
            
            Console.WriteLine("All equipment:");
            foreach (var eq in equipmentService.GetAll())
            {
                Console.WriteLine($"{eq.Name} | Available: {eq.IsAvailable}");
            }
            
            // Rent available equipment
            
            Console.WriteLine("Rent laptop:");
            rentService.Rent(student, laptop, 3);
            Console.WriteLine("Laptop rented successfully.");
            
            //Try to rent unavailable equipment

            try
            {
                Console.WriteLine("Attempt to rent unavailable projector:");
                rentService.Rent(student, projector, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            //Exceed rent limit

            try
            {
                var extra1 = new Laptop("Dell 1", 512, "i7-12095");
                var extra2 = new Laptop("HP", 64, "i3-1205");
                
                equipmentService.Add(extra1);
                equipmentService.Add(extra2);
                
                rentService.Rent(student, extra1, 1);
                rentService.Rent(student, extra2, 1); //Here exceeding limit of 2 rents
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            //Show active rents
            
            Console.WriteLine("Active rents for student: ");
            var rents = rentService.GetUserRents(student);

            foreach (var r in rents)
            {
                Console.WriteLine($"{r.Equipment.Name} | Due: {r.DueDate}");
            }

            //Return on time
            
            Console.WriteLine("Return equipment on time:");

            var rentToReturn = rents[0];
            var penalty = rentService.Return(rentToReturn.Id);
            
            Console.WriteLine($"Returned. Penalty: {penalty}");
            
            //Late return
            
            Console.WriteLine("Simulate late return:");

            var lateEquipment = new Camera ("Test", 2, true);
            equipmentService.Add(lateEquipment);

            rentService.Rent(employee, lateEquipment, 1);

            var lateRent = rentService.GetUserRents(employee)[0];

            // Simulation of late return

            var latePenalty = rentService.ForceReturnWithAdditionalDays(lateRent.Id, 10);

            Console.WriteLine($"Late return penalty: {latePenalty}");
            

            //Final report
            var finalReport = reportService.GenerateSummary();
            
            Console.WriteLine(finalReport);

        }
    }
}