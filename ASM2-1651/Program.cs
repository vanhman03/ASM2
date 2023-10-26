

namespace ASM_1651
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Restaurant restaurant = new Restaurant();
            Customer customer = null;
            Order order = null;

            int choice;
            do
            {
                Console.WriteLine("------ Restaurant Management ------");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Display All Employees");
                Console.WriteLine("4. Add Menu Item");
                Console.WriteLine("5. Remove Menu Item");
                Console.WriteLine("6. Display All Menus");
                Console.WriteLine("7. Place Order");
                Console.WriteLine("8. Generate Bill");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            AddEmployee(restaurant);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case 2:
                        RemoveEmployee(restaurant);
                        break;
                    case 3:
                        DisplayAllEmployees(restaurant);
                        break;
                    case 4:
                        try
                        {
                            AddMenuItem(restaurant);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                    case 5:
                        RemoveMenuItem(restaurant);
                        break;
                    case 6:
                        DisplayAllMenuItems(restaurant);
                        break;
                    case 7:
                        PlaceOrder(restaurant, ref customer, ref order);
                        break;
                    case 8:
                        GenerateBill(customer, order);
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }

        static void AddEmployee(Restaurant restaurant)
        {
            Console.WriteLine("Enter employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Position: ");
            string position = Console.ReadLine();
            Console.WriteLine("Employee type:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            Console.Write("Enter employee type: ");
            int employeeType = Convert.ToInt32(Console.ReadLine());

            switch (employeeType)
            {
                case 1:
                    Console.Write("Years of experience: ");
                    int yearsOfExperience = Convert.ToInt32(Console.ReadLine());
                    Manager manager = new Manager(name, age, position, yearsOfExperience);
                    restaurant.AddEmployee(manager);
                    Console.WriteLine("Manager added successfully.");
                    break;
                case 2:
                    Console.Write("Shift: ");
                    string shift = Console.ReadLine();
                    Waiter waiter = new Waiter(name, age, position, shift);
                    restaurant.AddEmployee(waiter);
                    Console.WriteLine("Waiter added successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid employee type. Employee not added.");
                    break;
            }
        }

        static void RemoveEmployee(Restaurant restaurant)
        {
            Console.WriteLine("Enter the name of the employee to remove:");
            string name = Console.ReadLine();
            Employee employeeToRemove = null;

            foreach (var employee in restaurant.GetEmployees())
            {
                if (employee.Name == name)
                {
                    employeeToRemove = employee;
                    break;
                }
            }

            if (employeeToRemove != null)
            {
                restaurant.RemoveEmployee(employeeToRemove);
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DisplayAllEmployees(Restaurant restaurant)
        {
            Console.WriteLine("All employees:");
            restaurant.DisplayAllEmployees();
        }
        static void AddMenuItem(Restaurant restaurant)
        {
            Console.WriteLine("Enter menu item details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            MenuItem menuItem = new MenuItem(name, price);
            restaurant.menu.AddMenuItem(menuItem);
            Console.WriteLine("Menu item added successfully.");
        }

        static void RemoveMenuItem(Restaurant restaurant)
        {
            Console.WriteLine("Enter the name of the menu item to remove:");
            string name = Console.ReadLine();

            if (restaurant.menu != null)
            {
                MenuItem itemToRemove = null;
                foreach (var item in restaurant.menu.GetItems())
                {
                    if (item.Name == name)
                    {
                        itemToRemove = item;
                        break;
                    }
                }

                if (itemToRemove != null)
                {
                    restaurant.menu.RemoveMenuItem(itemToRemove);
                    Console.WriteLine("Menu item removed successfully.");
                }
                else
                {
                    Console.WriteLine("Menu item not found.");
                }
            }
            else
            {
                Console.WriteLine("No menu items found.");
            }
        }

        static void DisplayAllMenuItems(Restaurant restaurant)
        {
            Menu menu = restaurant.menu;
            MenuItem item1 = new MenuItem("Pizza", 8.99m);
            MenuItem item2 = new MenuItem("Burger", 6.99m);
            MenuItem item3 = new MenuItem("Salad", 4.99m);
            if (!menu.GetItems().Any(item => item.Name == item1.Name))
                restaurant.menu.AddMenuItem(item1);
            if (!menu.GetItems().Any(item => item.Name == item2.Name))
                restaurant.menu.AddMenuItem(item2);
            if (!menu.GetItems().Any(item => item.Name == item3.Name))
                restaurant.menu.AddMenuItem(item3);
            if (menu != null)
            {
                Console.WriteLine("All menu items:");
                restaurant.menu.DisplayMenu();
            }
            else
            {
                Console.WriteLine("No menu items found.");
            }

        }
        static void PlaceOrder(Restaurant restaurant, ref Customer customer, ref Order order)
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());

            customer = new Customer(name, age, phoneNumber);
            order = new Order();

            List<MenuItem> menuItems = restaurant.menu.GetItems();

            string choice;
            do
            {
                Console.WriteLine("------ Place Order ------");

                for (int i = 0; i < menuItems.Count; i++)
                {
                    MenuItem menuItem = menuItems[i];
                    Console.WriteLine($"{i + 1}. {menuItem.Name} - {menuItem.Price}");
                }

                Console.WriteLine("0. Finish order");
                Console.Write("Enter the name of the menu item to add to the order (0 to finish): ");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }

                MenuItem selectedItem = menuItems.FirstOrDefault(item => item.Name.ToLower() == choice.ToLower());
                if (selectedItem != null)
                {
                    order.AddItem(selectedItem);
                    Console.WriteLine("Menu item added to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid menu item name. Please enter a valid menu item name.");
                }

                Console.WriteLine();
            } while (true);
        }



        static void GenerateBill(Customer customer, Order order)
        {
            Console.WriteLine("------ Bill ------");
            Console.WriteLine("Customer: " + customer.Name);
            Console.WriteLine("Age: " + customer.Age);
            Console.WriteLine("Phone Number: " + customer.PhoneNum);
            Console.WriteLine();

            Console.WriteLine("Items:");
            foreach (var item in order.GetItems())
            {
                Console.WriteLine(" - " + item.Name + ": $" + item.Price);
            }
            Console.WriteLine();

            decimal total = order.CalculateTotal();
            Console.WriteLine("Total: $" + total);
            Console.WriteLine();
            Console.WriteLine("---------------");
        }
    }
}