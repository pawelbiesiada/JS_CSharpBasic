using CommunityToolkit.Mvvm.Input;
using MyMAUIApp.Models;

namespace MyMAUIApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}