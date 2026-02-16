using Interfaces;

namespace Models
{
    public class MenuGroup : IMenuComponent
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        private List<IMenuComponent> _children;

        public MenuGroup(string title, string icon = "")
        {
            Title = title;
            Icon = icon;
            IsActive = true;
            _children = new List<IMenuComponent>();
        }
        public void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

            foreach (var item in _children)
                item.Render(indent + 1);
        }

        public int CountItems()
        {
            int count = 0;
            foreach (var child in _children)
                count += child.CountItems();
            return count;
        }

        public void DisableAllItems()
        {
            foreach (var item in _children)
                item.IsActive = false;
        }
        public void Add(IMenuComponent component) => _children.Add(component);
    }
}