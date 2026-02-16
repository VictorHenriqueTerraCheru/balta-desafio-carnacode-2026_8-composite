using Interfaces;

namespace Services
{
    public class MenuManager
    {
        private List<IMenuComponent> _components;

        public MenuManager() => _components = new List<IMenuComponent>();

        public void Add(IMenuComponent component) => _components.Add(component);

        public void RenderMenu()
        {
            Console.WriteLine("=== Menu Principal ===\n");
            foreach (var component in _components)
                component.Render();
        }

        public int GetTotalItems()
        {
            int count = 0;
            foreach (var component in _components)
                count += component.CountItems();
            return count;
        }
    }
}