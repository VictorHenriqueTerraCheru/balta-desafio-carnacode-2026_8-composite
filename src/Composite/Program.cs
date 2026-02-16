using Models;
using Services;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Composite Pattern - Sistema de Menus ===\n");

        TestBasicMenu();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        TestNestedMenu();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        TestOperations();
        Console.WriteLine("\n" + new string('-', 60) + "\n");

        ShowBenefits();
    }

    static void TestBasicMenu()
    {
        Console.WriteLine(">>> TESTE 1: Menu Simples\n");

        var manager = new MenuManager();

        manager.Add(new MenuItem("Home", "/", "🏠"));
        manager.Add(new MenuItem("Sobre", "/sobre", "ℹ️"));
        manager.Add(new MenuItem("Contato", "/contato", "📧"));

        manager.RenderMenu();
        Console.WriteLine($"\nTotal de itens: {manager.GetTotalItems()}");
    }

    static void TestNestedMenu()
    {
        Console.WriteLine(">>> TESTE 2: Menu com Hierarquia\n");

        var manager = new MenuManager();

        manager.Add(new MenuItem("Home", "/", "🏠"));

        var productsMenu = new MenuGroup("Produtos", "📦");
        productsMenu.Add(new MenuItem("Todos", "/produtos", "📋"));
        productsMenu.Add(new MenuItem("Ofertas", "/ofertas", "🏷️"));

        var clothingMenu = new MenuGroup("Roupas", "👕");
        clothingMenu.Add(new MenuItem("Camisetas", "/roupas/camisetas"));
        clothingMenu.Add(new MenuItem("Calças", "/roupas/calcas"));
        clothingMenu.Add(new MenuItem("Jaquetas", "/roupas/jaquetas"));

        productsMenu.Add(clothingMenu);

        var electronicsMenu = new MenuGroup("Eletrônicos", "💻");
        electronicsMenu.Add(new MenuItem("Notebooks", "/eletro/notebooks"));
        electronicsMenu.Add(new MenuItem("Celulares", "/eletro/celulares"));

        productsMenu.Add(electronicsMenu);

        manager.Add(productsMenu);

        var adminMenu = new MenuGroup("Admin", "⚙️");
        adminMenu.Add(new MenuItem("Usuários", "/admin/users"));
        adminMenu.Add(new MenuItem("Config", "/admin/config"));

        manager.Add(adminMenu);

        manager.RenderMenu();
        Console.WriteLine($"\nTotal de itens: {manager.GetTotalItems()}");
    }

    static void TestOperations()
    {
        Console.WriteLine(">>> TESTE 3: Operações em Lote\n");

        var menu = new MenuGroup("Menu Principal", "📂");
        menu.Add(new MenuItem("Item 1", "/1"));
        menu.Add(new MenuItem("Item 2", "/2"));

        var subMenu = new MenuGroup("SubMenu", "📁");
        subMenu.Add(new MenuItem("Item 3", "/3"));
        subMenu.Add(new MenuItem("Item 4", "/4"));

        menu.Add(subMenu);

        Console.WriteLine("ANTES de desabilitar:");
        menu.Render();

        Console.WriteLine("\nDesabilitando todos os itens...\n");
        menu.DisableAllItems();

        Console.WriteLine("DEPOIS de desabilitar:");
        menu.Render();
    }

    static void ShowBenefits()
    {
        Console.WriteLine(">>> BENEFÍCIOS DO COMPOSITE PATTERN\n");

        Console.WriteLine("MenuItem e MenuGroup tratados uniformemente");
        Console.WriteLine("Operações recursivas simplificadas");
        Console.WriteLine("Cliente não precisa saber se é item ou grupo");
        Console.WriteLine("Adicionar nova operação = método na interface");
        Console.WriteLine("Interface uniforme para toda hierarquia");
        Console.WriteLine();
    }
}