using GFTApplication.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication
{
    delegate void menuDel(ShapesContainer container);
    struct Menu
    {
        public Menu(string menuTitle, menuDel menuFunction)
        {
            this.menuTitle = menuTitle;
            this.menuFunction = menuFunction;
        }
        public string menuTitle { get; set; }
        public menuDel menuFunction { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapesContainer container = new ShapesContainer();
            List<Menu> menuItems = GenerateMenu();
            int selector = 0;
            bool good = false;
            while (selector != menuItems.Count - 1)
            {
                Console.Clear();
                DrawTitle();
                DrawMenu(menuItems);
                good = int.TryParse(Console.ReadLine(), out selector);
                selector--;
                if (good)
                {
                    if (selector > menuItems.Count-1 || selector < 0)
                    {
                        ErrorMessage();
                    }else
                    {
                        menuItems.ElementAt(selector).menuFunction(container);
                    }
                }
                else
                {
                    ErrorMessage();
                }
                Console.ReadKey();
            }
        }
        private static void ErrorMessage()
        {
            Console.WriteLine("Typing error, press key to continue.");
        }
        private static void DrawStarLine()
        {
            Console.WriteLine("********************************");
        }
        private static void DrawTitle()
        {
            DrawStarLine();
            Console.WriteLine("+++   GFT Application test   +++");
            DrawStarLine();
        }
        private static void DrawMenu(List<Menu> menuItems)
        {
            DrawStarLine();

            for(int i = 0; i < menuItems.Count(); i++)
            {
                var item = menuItems.ElementAt(i);
                Console.WriteLine(String.Concat(i + 1, ". ", item.menuTitle));
            }

            DrawStarLine();
            Console.WriteLine("Make your choice: type 1, 2,... or {0} for exit", menuItems.Count);
            DrawStarLine();
        }

        private static List<Menu> GenerateMenu()
        {
            List<Menu> menu = new List<Menu>();

            menu.Add(new Menu("Enter a new Shape",
                    delegate (ShapesContainer container)
                    {
                        Console.WriteLine("Enter a new Shape");
                        string input = Console.ReadLine();
                        try
                        {
                            Console.WriteLine(container.AddShape(TokenReader.ReadToken(input)));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }));

            menu.Add(new Menu("Load shapes from file", delegate (ShapesContainer container) {
                Console.WriteLine("Enter the file complete path");
                string input = Console.ReadLine();
                if (!System.IO.File.Exists(input))
                {
                    Console.WriteLine(String.Format("The file {0} does not exists.", input));
                    return;
                }
                string[] lines = System.IO.File.ReadAllLines(input);

                foreach(string shape in lines)
                {
                    if(shape.Trim() != "")
                    {
                        try
                        {
                            Console.WriteLine(container.AddShape(TokenReader.ReadToken(shape.Trim())));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }));

            menu.Add(new Menu("Delete a Shape",
                    delegate (ShapesContainer container)
                    {
                        Console.WriteLine("Enter the shape id");
                        string input = Console.ReadLine();
                        try
                        {
                            Console.WriteLine(container.deleteShape(TokenReader.ReadId(input)));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }));

            menu.Add(new Menu("Find shapes that includes point",
                    delegate (ShapesContainer container)
                    {
                        Console.WriteLine("Find shapes that includes point x y");
                        try
                        {
                            string input = Console.ReadLine();
                            var point = TokenReader.ReadPoint(input);
                            foreach (string sh in container.FindInPoint(point[0], point[1]))
                            {
                                Console.WriteLine(sh);
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }));

            menu.Add(new Menu("List all the shapes",
                    delegate (ShapesContainer container) {
                        Console.WriteLine("List all the shapes");
                        foreach (string sh in container.GetShapeList())
                        {
                            Console.WriteLine(sh);
                        }
                    }));

            menu.Add(new Menu("Help", delegate (ShapesContainer container) {
                Console.WriteLine("Help for shapes manager: ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Enter a new Shap: ");
                Console.WriteLine("  This command allows you to enter a new shape with the format: shapename pointx pointy [list of points]  ");
                Console.WriteLine("  Each shape change lightly the params they need to be created ");
                Console.WriteLine("  Circle: circle x y radius ");
                Console.WriteLine("  Square: square x y side ");
                Console.WriteLine("  Rectangle: rectangle x y side1 side2 ");
                Console.WriteLine("  Triangle: triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3 ");
                Console.WriteLine("  Donut: donut x y radius1 radius2 ");
                Console.WriteLine("  Ellipse: ellipse x y radiusMin radiusMax ");
                Console.WriteLine("  ** If the format or number of the params are incorrect, the application will show an error. ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Load shapes from file: ");
                Console.WriteLine("  This will load a list of shapes (with the correct format) from a file  ");
                Console.WriteLine("  ** If file does not exists, the application will show an error. ");
                Console.WriteLine("  ** If one of the shapes have a wrong format, the application will show the line error and will continue with the rest shapes. ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Delete a Shape: ");
                Console.WriteLine("  Deletes a shape with the id specified  ");
                Console.WriteLine("  The id should be an integer number  ");
                Console.WriteLine("  ** If the shape with the specified id does not exists, the application will show an error.  ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Find shapes that includes point: ");
                Console.WriteLine("  This will scan all the shapes and list the ones that will contain the point within its area  ");
                Console.WriteLine("  The point form with 2 floating numbers separate by one space  ");
                Console.WriteLine("  ** If the point is not format correctly the application will show an error  ");
                Console.WriteLine("  ** If non shape is containing the point, the application will show 0 results  ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- List all the shapes: ");
                Console.WriteLine("  This option will print all the shapes  ");
                Console.WriteLine("  ** If there are no shapes, no error will be printed  ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Help: ");
                Console.WriteLine("  Shows this help  ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("- Exit: ");
                Console.WriteLine("  Exits the application  ");
                Console.WriteLine("  ** The application does not persist any data, all the shapes that where added will be lost when exits the application  ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("--------------------------------");
            }));

            menu.Add(new Menu("Exit", delegate (ShapesContainer container) {
                    Environment.Exit(0);
                }));

            return menu;
        }
    }
}
