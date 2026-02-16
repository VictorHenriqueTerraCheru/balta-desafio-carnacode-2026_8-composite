namespace Interfaces
{
    public interface IMenuComponent
    {
        string Title { get; set; }
        string Icon { get; set; }
        bool IsActive { get; set; }

        void Render(int indent = 0);
        int CountItems();
    }
}
