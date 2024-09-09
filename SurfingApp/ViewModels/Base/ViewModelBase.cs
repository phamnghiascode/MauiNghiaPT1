using CommunityToolkit.Mvvm.ComponentModel;

namespace SurfingApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}