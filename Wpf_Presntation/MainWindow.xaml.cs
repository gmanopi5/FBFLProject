using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using DataObjects;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user = null;
        private PlayerManager _playerManager = new PlayerManager();
        private List<Quarterback> _quarterBacks = null;
        private List<Runningback> _runningBacks = null;
        private List<WideReceiver> _wideReceivers = null;
        private List<TideEnd> _tideEnd = null;
        private List<Kicker> _kicker = null;
        private List<DefensiveLinemen> _defensiveLinemen = null;
        private List<Linebacker> _linebacker = null;
        private List<Defense> _defense = null;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Log Out")
            {
                _user = null;
                // stuff to do for logout
                updateUIforLogout();
                return;
            }
            UserManager userManager = new UserManager();

            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (email.Length < 6)
            {
                MessageBox.Show("Invalid email address.");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            if (password == "")
            {
                MessageBox.Show("You must enter a password.");
                txtPassword.Focus();
                return;
            }

            try
            {
                _user = userManager.LoginUser(email, password);
                //MessageBox.Show("Welcome " + _user.GivenName + "\n" +
                //    "You are logged in as " + _user.Roles[0]);

                showTabsForUser();

                updateUIforUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            updateUIforLogout();
        }

        private void hideAllUserTabs()
        {
            foreach (var tab in tabsetMain.Items)
            {
                ((TabItem)tab).Visibility = Visibility.Collapsed;
            }
        }

        private void updateUIforUser()
        {
            string rolesList = "";

            for (int i = 0; i < _user.Roles.Count; i++)
            {
                rolesList += " " + _user.Roles[i];
                if (i == _user.Roles.Count - 2)
                {
                    if (_user.Roles.Count > 2)
                    {
                        rolesList += ",";
                    }
                    rolesList += " and";
                }
                else if (i < _user.Roles.Count - 2)
                {
                    rolesList += ",";
                }
            }
            lblGreeting.Content = "Welcome " + _user.Name + ". You are logged in as" + rolesList;

            statMessage.Content = "Logged in on " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToShortTimeString()
                + ". Please remember to log out before you leave.";

            btnLogin.Content = "Log Out";
            btnLogin.IsDefault = false;
         

            txtEmail.Text = "";
            txtPassword.Password = "";
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPlassword.Visibility = Visibility.Hidden;
        }

        private void updateUIforLogout()
        {
            hideAllUserTabs();
            tabsetPanel.Visibility = Visibility.Hidden;
            btnLogin.IsDefault = true;

            txtEmail.Text = "";
            txtPassword.Password = "";
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPlassword.Visibility = Visibility.Visible;

            lblGreeting.Content = "You are not logged in";
            statMessage.Content = "Welcome please login to continue";

            btnLogin.Content = "Login";
            btnLogin.IsDefault = true;

            txtEmail.Focus();

        }

        private void showTabsForUser()
        {
            foreach (var role in _user.Roles)
            {    
                tabTeams.Visibility = Visibility.Visible;
                tabTeams.IsSelected = true;
                tabTeams.Focus();
                        
                tabQuarterBack.Visibility = Visibility.Visible;
                        
                tabRunningBack.Visibility = Visibility.Visible;
                        
                tabWideReceiver.Visibility = Visibility.Visible;
                        
                tabTideEnd.Visibility = Visibility.Visible;
                        
                tabKicker.Visibility = Visibility.Visible;
                    
                tabDefensiveLinemen.Visibility = Visibility.Visible;
                        
                tabLinebacker.Visibility = Visibility.Visible;
                        
                tabDefense.Visibility = Visibility.Visible;
            }
            tabsetPanel.Visibility = Visibility.Visible;
        }

        private void tabQuarterBack_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_quarterBacks == null)
            {
                try
                {
                    _quarterBacks = _playerManager.RetrieveQuarterBacks();
                    datQB.ItemsSource = _quarterBacks;

                    datQB.Columns[0].Header = "Quarterback ID";
                    datQB.Columns[1].Header = "Quarterback Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabRunningBack_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_runningBacks == null)
            {
                try
                {
                    _runningBacks = _playerManager.RetrieveRunningBacks();
                    datRB.ItemsSource = _runningBacks;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabWideReceiver_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_wideReceivers == null)
            {
                try
                {
                    _wideReceivers = _playerManager.RetrieveWideRecivers();
                    datWR.ItemsSource = _wideReceivers;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabTideEnd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_tideEnd == null)
            {
                try
                {
                    _tideEnd = _playerManager.RetrieveTideEnds();
                    datTE.ItemsSource = _tideEnd;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabKicker_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_kicker == null)
            {
                try
                {
                    _kicker = _playerManager.RetrieveKickers();
                    datK.ItemsSource = _kicker;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabDefensiveLinemen_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_defensiveLinemen == null)
            {
                try
                {
                    _defensiveLinemen = _playerManager.RetrieveDefensiveLinemen();
                    datDL.ItemsSource = _defensiveLinemen;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabLinebacker_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_linebacker == null)
            {
                try
                {
                    _linebacker = _playerManager.RetrieveLinebackers();
                    datLB.ItemsSource = _linebacker;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void tabDefense_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_defense == null)
            {
                try
                {
                    _defense = _playerManager.RetrieveDefense();
                    datDE.ItemsSource = _defense;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }
    }
}
