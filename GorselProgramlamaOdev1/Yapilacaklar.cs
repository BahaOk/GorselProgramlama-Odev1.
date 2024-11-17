using System.Collections.ObjectModel;
namespace GorselProgramlamaOdev1;

public partial class Yapilacaklar : ContentPage
{
    public ObservableCollection<TaskItem> Tasks { get; set; }

    public Yapilacaklar()
    {
        InitializeComponent();
        Tasks = new ObservableCollection<TaskItem>();
        TasksListView.ItemsSource = Tasks;
    }

    private void GorevEkleme(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
        {
            Tasks.Add(new TaskItem { Task = TaskEntry.Text, IsCompleted = false });
            TaskEntry.Text = string.Empty; 
        }
    }

    private void GorevSil(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    private void GorevDuzenle(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            TaskEntry.Text = task.Task;
            Tasks.Remove(task);
        }
    }
}
public class TaskItem
{
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}