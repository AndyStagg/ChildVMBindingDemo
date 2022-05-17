using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ChildVMBindingDemo
{
    /// <summary>
    /// Interaction logic for MyListBoxControl.xaml
    /// </summary>
    public partial class MyListBoxControl : UserControl
    {
        private readonly MyListBoxControlViewModel _viewModel;

        public MyListBoxControl()
        {
            InitializeComponent();

            _viewModel = new MyListBoxControlViewModel();
            this.DataContext = _viewModel;
        }

        public static readonly DependencyProperty MyItemsProperty =
            DependencyProperty.Register("MyItems", typeof(ObservableCollection<MyItem>), typeof(MyListBoxControl),
                new FrameworkPropertyMetadata(null, MyItemsChangedCallback));

        public ObservableCollection<MyItem> MyItems
        {
            get => (ObservableCollection<MyItem>)GetValue(MyItemsProperty);
            set
            {
                SetValue(MyItemsProperty, value);
                _viewModel.MyItems = MyItems;
            }
        }

        private static void MyItemsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyListBoxControl myListBoxControl)
            {
                myListBoxControl.MyItems = (ObservableCollection<MyItem>)e.NewValue;
            }
        }

        public static readonly DependencyProperty SelectedMyItemProperty =
            DependencyProperty.Register(nameof(SelectedMyItem), typeof(MyItem), typeof(MyListBoxControl),
                new FrameworkPropertyMetadata(null, SelectedMyItemChangedCallback)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

        public MyItem SelectedMyItem
        {
            get => (MyItem)GetValue(SelectedMyItemProperty);
            set
            {
                SetValue(SelectedMyItemProperty, value);
                _viewModel.SelectedMyItem = SelectedMyItem;
            }
        }

        private static void SelectedMyItemChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MyListBoxControl myListBoxControl)
            {
                myListBoxControl.SelectedMyItem = (MyItem)e.NewValue;
            }
        }
    }
}
