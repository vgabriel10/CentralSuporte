

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CentralSuporte.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string nomePropriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }


        //protected void SetField<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        //{
        //    if (!EqualityComparer<T>.Default.Equals(field, value))
        //    {
        //        field = value;
        //        RaisePropertyChanged(propertyName);
        //    }
        //}
        //protected void RaisePropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        //}





    }
}
