using ChildVMBindingDemo.MVVM;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChildVMBindingDemo
{
    public class MyListBoxControlViewModel : ViewModelBase
    {
        #region INPC Properties
        private ObservableCollection<MyItem> _myItems;
        public ObservableCollection<MyItem> MyItems
        {
            get => _myItems;
            set => Set(ref _myItems, value);
        }

        private MyItem _selectedMyItem;
        public MyItem SelectedMyItem
        {
            get => _selectedMyItem;
            set
            {
                if (Set(ref _selectedMyItem, value))
                {
                    System.Diagnostics.Debug.WriteLine($"Child View Model Selected Item Set: {SelectedMyItem?.Name}");
                }
            }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        #endregion

        #region Commands
        private ICommand _prevCommand;
        public ICommand PrevCommand => _prevCommand ?? (_prevCommand = new RelayCommand((param) => Prev(), (param) => CanPrev()));
        public bool CanPrev() => SelectedIndex > 0;
        private void Prev()
        {
            SelectedIndex--;
        }

        private ICommand _nextCommand;
        public ICommand NextCommand => _nextCommand ?? (_nextCommand = new RelayCommand((param) => Next(), (param) => CanNext()));
        public bool CanNext() => MyItems != null ? SelectedIndex < (MyItems.Count - 1) : false;
        private void Next()
        {
            SelectedIndex++;
        }
        #endregion
    }
}
