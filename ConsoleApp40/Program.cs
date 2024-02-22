using static ConsoleApp40.BrandServer;
using ConsoleApp40;
using System.Reflection.Emit;

Label:
string? option;
do {
    ShowMenu();
    Console.Write("Choose an option: ");
    option = Console.ReadLine();
    switch (option) {
        case "1":
            Console.WriteLine("Brand create");
            Console.Write("Enter brand name: ");
            string? name = Console.ReadLine();
            DateTime year;
            do {
                Console.Write("Enter brand year: ");
            } while (!DateTime.TryParse(Console.ReadLine(), out year));
            CreateBrand(name, year);
            break;
        case "2":
            Console.WriteLine("Brand delete");
            int id;
            do {
                Console.Write("Enter brand id: ");
            } while (!int.TryParse(Console.ReadLine(), out id));
            if (GetBrandById(id) == null) {
                Console.WriteLine("Data cannot be found");
                goto Label;
            }
            DeleteBrandById(id);
            break;
        case "3":
            Console.WriteLine("Brand get by id");
            Console.Write("Enter brand id: ");
            do {
                Console.Write("Enter brand id: ");
            } while (!int.TryParse(Console.ReadLine(), out id));
            Brand? brand = GetBrandById(id);
            Console.WriteLine(brand);
            break;
        case "4":
            Console.WriteLine("Get all brands");
            List<Brand?>? brands = GetAllBrands();
            if (brands != null)
            foreach (Brand? b in brands)
                Console.WriteLine(b);
            break;
        case "5":
            Console.WriteLine("Update brand");
            do {
                Console.Write("Enter brand id: ");
            } while (!int.TryParse(Console.ReadLine(), out id));
            if (GetBrandById(id) == null) {
                Console.WriteLine("Data cannot be found");
                goto Label;
            }
            Console.Write("Enter new brand name: ");
            string? newName = Console.ReadLine();
            DateTime newYear;
            do {
                Console.Write("Enter new brand year: ");
            } while (!DateTime.TryParse(Console.ReadLine(), out newYear));
            UpdateBrandById(id, newName, newYear);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
} while (option != "0");






static void ShowMenu() {
    Console.WriteLine("1. Brand create");
    Console.WriteLine("2. Brand delete");
    Console.WriteLine("3. Brand get by id");
    Console.WriteLine("4. Get all brands");
    Console.WriteLine("5. Update brand");
    Console.WriteLine("0. Exit");
}