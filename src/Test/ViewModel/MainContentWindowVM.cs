using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace TestApp.ViewModel
{
    public class MainContentWindowVM : CommonBase
    {
        FlowDirection _flowDirection;

        public ICommand ChangeSource { get; set; }

        public ICommand Logout { get; set; }
        
        ObservableCollection<Model.Items.Item> AllItems { get; set; }

        public MainContentWindowVM()
        {
            FlowDirection = CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            LoadCommands();

            using (var db = new DataContext())
            {
                AllItems = new ObservableCollection<Model.Items.Item>(db.Items);
            }
        }

        public void LoadCommands()
        {
        }

        public FlowDirection FlowDirection
        {
            get { return _flowDirection; }
            set
            {
                if (_flowDirection != value)
                {
                    _flowDirection = value;
                    RaisePropertyChanged(nameof(FlowDirection));
                }
            }
        }
       
        
    }
}