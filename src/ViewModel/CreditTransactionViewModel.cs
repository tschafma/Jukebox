using Jukebox.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Jukebox.ViewModel
{
    public class CreditTransactionViewModel : ViewModelBase
    {
        private int _currentCredits;
        private int _selectedCredits;
        private string _paymentMethod;

        private ObservableCollection<string> _paymentOptions;

        private UserRepository _userRepo;

        private User _user;

        private ICommand _transactCreditsCommand;
        private ICommand _closeCreditTransactionViewCommand;

        public CreditTransactionViewModel(User user)
        {
            User = user;
            CurrentCredits = user.Credits;
            _userRepo = new UserRepository();
            PaymentOptions = new ObservableCollection<string>();
            PaymentOptions.Add("Credit Card");
            PaymentOptions.Add("PayPal");
            PaymentOptions.Add("Cash");

            TransactCreditsCommand = new RelayCommand(new Action<object>(TransactCredits));
            CloseCreditTransactionViewCommand = new RelayCommand(new Action<object>(CloseCreditTransactionView));
        }

        private void TransactCredits(object obj)
        {
            if (SelectedCredits <= 0)
                return;
            User.Credits += SelectedCredits;
            _userRepo.SaveUser(User);
            CloseCreditTransactionView(true);
        }

        private void CloseCreditTransactionView(object obj = null)
        {
            bool click;
            if (obj == null)
            {
                click = false;
            }
            else
            {
                click = (bool)obj;
            }

            Messenger.Default.Send<bool>(true, "NoCredits");
            Messenger.Default.Send<bool>(click, "CloseCreditTransactionView");
        }

        #region Properties
        public string CurrentCreditsHeader
        {
            get { return "Your Credits: " + CurrentCredits.ToString(); }
        }

        public int CurrentCredits
        {
            get { return _currentCredits; }
            set { _currentCredits = value; }
        }

        public int SelectedCredits
        {
            get { return _selectedCredits; }
            set { _selectedCredits = value; }
        }

        public ObservableCollection<string> PaymentOptions
        {
            get { return _paymentOptions; }
            set { _paymentOptions = value; }
        }

        public string PaymentMethod
        {
            get
            {
                return _paymentMethod;
            }

            set
            {
                if (_paymentMethod == value)
                    return;
                _paymentMethod = value;
                OnPropertyChanged("PaymentMethod");
            }
        }

        public bool FiveCredits
        {
            get
            {
                if (SelectedCredits == 5)
                    return true;
                return false;
            }
            set
            {
                SelectedCredits = 5;
                OnPropertyChanged("FiveCredits");
                OnPropertyChanged("TenCredits");
                OnPropertyChanged("FifteenCredits");
            }
        }

        public bool TenCredits
        {
            get
            {
                if (SelectedCredits == 10)
                    return true;
                return false;
            }
            set
            {
                SelectedCredits = 10;
                OnPropertyChanged("FiveCredits");
                OnPropertyChanged("TenCredits");
                OnPropertyChanged("FifteenCredits");
            }
        }

        public bool FifteenCredits
        {
            get
            {
                if (SelectedCredits == 15)
                    return true;
                return false;
            }
            set
            {
                SelectedCredits = 15;
                OnPropertyChanged("FiveCredits");
                OnPropertyChanged("TenCredits");
                OnPropertyChanged("FifteenCredits");
            }
        }

        public User User
        {
            get
            {
                if (_user == null)
                    _user = new User();
                return _user;
            }
            set { _user = value; }
        }

        public ICommand TransactCreditsCommand
        {
            get { return _transactCreditsCommand; }
            set { _transactCreditsCommand = value; }
        }

        public ICommand CloseCreditTransactionViewCommand
        {
            get { return _closeCreditTransactionViewCommand; }
            set { _closeCreditTransactionViewCommand = value; }
        } 
        #endregion
    }
}
