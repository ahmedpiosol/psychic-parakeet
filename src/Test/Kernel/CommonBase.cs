using System.ComponentModel;

namespace TestApp
{
    public class CommonBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Tell the UI Thread about changed property when data binding
        /// </summary>
        /// <param name="propertyName">The Property Name that has been changed</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}