using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChildVMBindingDemo.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INPC Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        #endregion
    }
}
