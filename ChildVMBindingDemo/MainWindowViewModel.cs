using ChildVMBindingDemo.MVVM;
using System.Collections.ObjectModel;

namespace ChildVMBindingDemo
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Constructors
        public MainWindowViewModel()
        {
            MyItems = new ObservableCollection<MyItem>()
            {
                new MyItem() { Name = "One" },
                new MyItem() { Name = "Two" },
                new MyItem() { Name = "Thee" },
                new MyItem() { Name = "Four" },
            };
        }
        #endregion

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
                    System.Diagnostics.Debug.WriteLine($"Main View Model Selected Item Set: {SelectedMyItem?.Name}");
                }
            }
        }
        #endregion
    }
}
