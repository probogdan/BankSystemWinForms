using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace MyBak
{
    
    public partial class AuthorizationForm : Form
    {        
        public Form AdminPannel = new Form();
        public Form UserPannel = new Form();
        public Form DonateForm = new Form();
        public Form PayForm = new Form();
        public Form WithdrowForm = new Form();
        public Form AddUser = new Form();
        public Form ChangeInfo = new Form();
        public Form OpenPaymentForm = new Form();        
        public Guid User_ID = new Guid();
        public Button AddUserBut = new Button();
        public Button YourInfo = new Button();
        public Button PayButton = new Button();
        public Button ClosePaymentButton = new Button();
        public Button Changeinfo = new Button();
        public Button OpenPayment = new Button();
        public Button Exit = new Button();
        public Button showUsersPayments = new Button();
        public Button DeleteUser = new Button();
        public Button ViewUsers = new Button();
        public Button Clear = new Button();
        public Button OpenPaymentFinale = new Button();
        public Button Donate = new Button();
        public Button Withdrow = new Button();
        public Button WithdrowFinale = new Button();
        public Button DonateFinale = new Button();
        public Button PayButtonSec = new Button();
        public Button ViewMyPayments = new Button();
        public Label Login_lable = new Label();
        public TextBox Login_box = new TextBox();
        public Label ChangeName_lable = new Label();
        public TextBox ChangeName_box = new TextBox();
        public Label ChangeMiddleName_lable = new Label();
        public TextBox ChangeMiddleName_box = new TextBox();
        public Label ChangeLastName_lable = new Label();
        public TextBox ChangeLastName_box = new TextBox();
        public Label Password_lable = new Label();
        public TextBox Password_box = new TextBox();
        public Label Last_Name = new Label();
        public Label BanksLAble = new Label();
        public TextBox LastName = new TextBox();
        public TextBox DonateSumBox = new TextBox();
        public TextBox WithdrowBox = new TextBox();
        public Label PaymentsTips = new Label();
        public Button Add = new Button();
        public Button WatchLogs = new Button();
        public Button ShowUsersServices = new Button();
        public Button ChangeInfoBut = new Button();       
        public Button ShowServices = new Button();
        public ComboBox SpisokBankov = new ComboBox();
        public ComboBox SpisokPaymentTips = new ComboBox();
        public ComboBox SpisokFillials = new ComboBox();
        public ComboBox SpisokServices = new ComboBox();
        public Guid guid = System.Guid.NewGuid();
        DataGridView Showing = new DataGridView();
        public bool godmod = true;
        public bool testmod = true;
        SqlConnection sql;
        string conn = @"Data Source=BOGDAN\SQLEXPRESS;Initial Catalog=Bank1;Integrated Security=True";
        public AuthorizationForm()
        {
            InitializeComponent();            
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            sql = new SqlConnection(conn);
            string procedure = "authorizationAdmin";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter paramExists = command.Parameters.Add("@return", SqlDbType.Int);
                paramExists.Direction = ParameterDirection.ReturnValue;
                SqlParameter paramLogin = new SqlParameter();
                SqlParameter paramPassword = new SqlParameter();
                SqlParameter paramRole = new SqlParameter();
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@UserId";                
                paramId.SqlDbType = SqlDbType.UniqueIdentifier;
                paramId.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramId);
                paramLogin.ParameterName = "@Login";
                paramLogin.Value = Login.Text.ToString();
                paramLogin.SqlDbType = SqlDbType.NVarChar;               
                command.Parameters.Add(paramLogin);
                paramRole.ParameterName = "@Role";
                paramRole.SqlDbType = SqlDbType.Int;
                paramRole.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramRole);
                paramPassword.ParameterName = "@Password";
                paramPassword.SqlDbType = SqlDbType.NVarChar;
                paramPassword.Value = Password.Text.ToString();
                command.Parameters.Add(paramPassword);
                sql.Open();
                command.ExecuteNonQuery();             
                
                sql.Close();
               try 
                {
                    if ((int)command.Parameters["@Role"].Value == 0)
                    {
                        AdminForm(sender, e);
                        this.Hide();
                    }
                    else if ((int)command.Parameters["@Role"].Value == 1)
                    {
                        User_ID = (Guid)command.Parameters["@UserId"].Value;
                        UserForm(sender, e);
                        this.Hide();
                    }
                }
               catch
                {
                    Login.Text = "Логин не найден";
                    Password.Text = "Пароль не верен";
                }
            }
        }
        public void AdminForm(object sender, EventArgs e)
        {   //Параметры формы администратора         
            AdminPannel.Name = "AdminPannel";
            AdminPannel.Width = 1300;
            AdminPannel.Height = 750;
            AdminPannel.Text = "AdminPannel";
            AdminPannel.StartPosition = FormStartPosition.CenterScreen;

            //Параметры кнопки добавления пользователя
            AddUserBut.Text = "Добавить Пользователя";
            AddUserBut.Location = new Point(30, 10);
            AddUserBut.Width = 100;
            AddUserBut.Height = 25;
            AddUserBut.Click += new System.EventHandler(add_user);
            AdminPannel.Controls.Add(AddUserBut);
            //Параметры кнопки добавления пользователя
            WatchLogs.Text = "Логи";
            WatchLogs.Location = new Point(30, 45);
            WatchLogs.Width = 100;
            WatchLogs.Height = 25;
            WatchLogs.Click += new System.EventHandler(watch_logs);
            AdminPannel.Controls.Add(WatchLogs);
            //Параметры кнопки удаления пользователя
            DeleteUser.Location = new Point(180, 10);
            DeleteUser.Width = 100;
            DeleteUser.Height = 25;
            DeleteUser.Text = "Удалить пользователя";
            DeleteUser.Click += new System.EventHandler(delete_user);
            AdminPannel.Controls.Add(DeleteUser);

            //Параметры кнопки просмотра пользователей
            ViewUsers.Location = new Point(330, 10);
            ViewUsers.Width = 100;
            ViewUsers.Height = 25;
            ViewUsers.Text = "Просмотр пользователей";
            //DataGridView Showing = new DataGridView();
            ViewUsers.Click += new System.EventHandler(view_users);
            AdminPannel.Controls.Add(ViewUsers);

            

            //Параметры кноски очистки раб стола
            Clear.Location = new Point(480, 10);
            Clear.Width = 100;
            Clear.Height = 25;
            Clear.Text = "Очистить стол";
            //DataGridView Showing = new DataGridView();
            Clear.Click += new System.EventHandler(clear_panel);
            AdminPannel.Controls.Add(Clear);
            //Параметры кнопки выход
            showUsersPayments.Location = new Point(630, 10);
            showUsersPayments.Width = 100;
            showUsersPayments.Height = 25;
            showUsersPayments.Text = "Счета";
            showUsersPayments.Click += new System.EventHandler(show_users_payment_toadmin);
            AdminPannel.Controls.Add(showUsersPayments);

            //Параметры кнопки выход
            ShowUsersServices.Location = new Point(780, 10);
            ShowUsersServices.Width = 100;
            ShowUsersServices.Height = 25;
            ShowUsersServices.Text = "Просмотр оплат";
            ShowUsersServices.Click += new System.EventHandler(show_users_services_to_admin);
            AdminPannel.Controls.Add(ShowUsersServices);


            //Параметры кнопки выход
            Exit.Location = new Point(930,10);
            Exit.Width = 100;
            Exit.Height = 25;
            Exit.Text = "Выход";
            Exit.Click += new System.EventHandler(Exit_panel);
            AdminPannel.Controls.Add(Exit);
            //параметры панели DataGridView
            
            Showing.Name = "Showing";
            Showing.Location = new Point(30, 90);
            Showing.Width = 1200;
            Showing.Height = 550;
            //DataGridViewTextBoxColumn dgvAge = new DataGridViewTextBoxColumn();
            //dgvAge.Name = "dgvAge";
            //dgvAge.HeaderText = "Возраст";
            //dgvAge.Width = 100;
            //Showing.Columns.Add(dgvAge);
            //dgv.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvAge", HeaderText = "Возраст", Width = 100});
            /*Showing.*/
            //Добавление DataGridView к форме
            AdminPannel.Controls.Add(Showing);
            //AdminPannel.Click += new System.EventHandler(ad_met);
            //AdminPannel.FormClosed += new System.EventHandler(ad_met);
            //AdminPannel.FormClosed += new System.Windows.Forms.FormClosedEventHandler(AdminPannel.Closing);
            //Показ админ панели
            AdminPannel.Show();                    
        }

        public void watch_logs(object sender, EventArgs e)
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID", HeaderText = "Id пользователя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MiddleName", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Отчество", Width = 100 });            
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Date", HeaderText = "Дата смены", Width = 100 });           
            sql = new SqlConnection(conn);
            string procedure = "ShowLogs";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[5]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                    data[data.Count - 1][4] = read[4].ToString();                    
                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }
        }
        public void show_users_services_to_admin(object sender, EventArgs e)
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID", HeaderText = "Id пользователя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MiddleName", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Отчество", Width = 100 });           
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Payment_id", HeaderText = "Id счета", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Service", HeaderText = "Тип операции", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Date", HeaderText = "Дата оплаты", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Fillial", HeaderText = "Филиал", Width = 100 });            
            sql = new SqlConnection(conn);
            string procedure = "ShowUsersServicesToAdmin";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[8]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                    data[data.Count - 1][4] = read[4].ToString();
                    data[data.Count - 1][5] = read[5].ToString();
                    data[data.Count - 1][6] = read[6].ToString();
                    data[data.Count - 1][7] = read[7].ToString();
                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }

        }
        public void show_users_payment_toadmin(object sender, EventArgs e)
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ID", HeaderText = "Id пользователя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MiddleName", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Отчество", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Bank", HeaderText = "Банк", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Bank_id", HeaderText = "ID Банка", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "PaymentType", HeaderText = "Тип счета", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Payment_id", HeaderText = "Id счета", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Sum", HeaderText = "Баланс", Width = 100 });
            sql = new SqlConnection(conn);
            string procedure = "ShowUsersPaymentsToAdmin";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;                
                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[9]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                    data[data.Count - 1][4] = read[4].ToString();
                    data[data.Count - 1][5] = read[5].ToString();
                    data[data.Count - 1][6] = read[6].ToString();
                    data[data.Count - 1][7] = read[7].ToString();
                    data[data.Count - 1][8] = read[8].ToString();
                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }

        }
        public void UserForm(object sender, EventArgs e)
        {
            int pos = 30;
            int posy = 10;
            //Параметры формы пользователя         
            UserPannel.Name = "UserPannel";
            UserPannel.Width = 900;
            UserPannel.Height = 650;
            UserPannel.Text = "UserPannel";
            UserPannel.StartPosition = FormStartPosition.CenterScreen;
            

            //Параметры кнопки прсмотра данных пользователя
            YourInfo.Location = new Point(pos, posy);
            YourInfo.Width = 100;
            YourInfo.Height = 25;
            YourInfo.Text = "Информация";
            YourInfo.Click += new System.EventHandler(user_info);
            UserPannel.Controls.Add(YourInfo);

            //Параметры кнопки прсмотра данных пользователя
            Changeinfo.Location = new Point(pos+150, posy);
            Changeinfo.Width = 100;
            Changeinfo.Height = 25;
            Changeinfo.Text = "Изменить";
            Changeinfo.Click += new System.EventHandler(change_info);
            UserPannel.Controls.Add(Changeinfo);

            //Параметры кнопки прсмотра данных пользователя
            OpenPayment.Location = new Point(pos+150*2, posy);
            OpenPayment.Width = 100;
            OpenPayment.Height = 25;
            OpenPayment.Text = "Открыть счет";
            OpenPayment.Click += new System.EventHandler(open_payment);
            UserPannel.Controls.Add(OpenPayment);

            //Параметры кнопки прсмотра данных пользователя
            ViewMyPayments.Location = new Point(pos+150*3, posy);
            ViewMyPayments.Width = 100;
            ViewMyPayments.Height = 25;
            ViewMyPayments.Text = "Мои счета";
            ViewMyPayments.Click += new System.EventHandler(view_payments);
            UserPannel.Controls.Add(ViewMyPayments);

            ////Параметры кнопки выход
            ClosePaymentButton.Location = new Point(pos+150*4, posy);
            ClosePaymentButton.Width = 100;
            ClosePaymentButton.Height = 25;
            ClosePaymentButton.Text = "Зыкрыть счет";
            ClosePaymentButton.Click += new System.EventHandler(close_payment);
            UserPannel.Controls.Add(ClosePaymentButton);
           
            ////Параметры кнопки пополнить
            Donate.Location = new Point(pos, posy+45);
            Donate.Width = 100;
            Donate.Height = 25;
            Donate.Text = "Пополнить";
            Donate.Click += new System.EventHandler(donate_metod);
            UserPannel.Controls.Add(Donate);

            ////Параметры кнопки пополнить
            Withdrow.Location = new Point(pos+150, posy + 45);
            Withdrow.Width = 100;
            Withdrow.Height = 25;
            Withdrow.Text = "Вывести";
            Withdrow.Click += new System.EventHandler(withdrow_metod);
            UserPannel.Controls.Add(Withdrow);

            ////Параметры кнопки пополнить
            PayButton.Location = new Point(pos + 150*2, posy + 45);
            PayButton.Width = 100;
            PayButton.Height = 25;
            PayButton.Text = "Оплатить";
            PayButton.Click += new System.EventHandler(pay_metod);
            UserPannel.Controls.Add(PayButton);

            ////Параметры кнопки пополнить
            ShowServices.Location = new Point(pos + 150 * 3, posy + 45);
            ShowServices.Width = 100;
            ShowServices.Height = 25;
            ShowServices.Text = "Мои оплаты";
            ShowServices.Click += new System.EventHandler(show_me);
            UserPannel.Controls.Add(ShowServices);
            //
            Exit.Location = new Point(pos + 150 * 4, posy+45);
            Exit.Width = 100;
            Exit.Height = 25;
            Exit.Text = "Выход";
            Exit.Click += new System.EventHandler(Exit_panel);
            UserPannel.Controls.Add(Exit);
            //параметры панели DataGridView
            Showing.Name = "Showing";
            Showing.Location = new Point(50, posy+90);
            Showing.Width = 750;
            Showing.Height = 500;
            Showing.ScrollBars = ScrollBars.Both;
            //Добавление DataGridView к форме
            UserPannel.Controls.Add(Showing);           
            //Показ юзер панели
            UserPannel.Show();
        }
        private void close_payment(object sender, EventArgs e)
        {
            try
            {
                guid = Guid.Parse(Showing.CurrentCell.Value.ToString());
                ClosePayment(guid);
            }
            catch
            {
                MessageBox.Show(
            "Выберите ID Вашего счета",
            "Возникла Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            }        
        }
        private void show_me(object sender, EventArgs e)
        {
            List<string[]> data =  ShowMyServices();
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MiddleName", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Отчество", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Bank", HeaderText = "Банк", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", HeaderText = "Id счета", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Service", HeaderText = "Услуга", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Date", HeaderText = "Дата оплаты", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Fillial", HeaderText = "Филиал банка", Width = 100 });
            foreach (string[] s in data)
            {
                Showing.Rows.Add(s);
            }

        }
        private DataGridView MakingGrid()
        {
            DataGridView Showing = new DataGridView();
            Showing.Name = "Showing";
            Showing.Location = new Point(30, 50);
            Showing.Width = 1200;
            Showing.Height = 550;
            DataGridViewTextBoxColumn dgvAge = new DataGridViewTextBoxColumn();
            dgvAge.Name = "dgvAge";
            dgvAge.HeaderText = "Возраст";
            dgvAge.Width = 100;
            Showing.Columns.Add(dgvAge);
            return Showing;
        }
        //private void ad_met(object sender, System.Windows.Forms.FormClosedEventArgs e)
        //{
        //    //
        //}
        private void clear_panel(object sender, EventArgs e)
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
        }
        private List<string> selectpaymenttips()
        {
            sql = new SqlConnection(conn);
            string procedure = "selectpaymenttips";
            List<string> data = new List<string>();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    data.Add("");
                    data[data.Count - 1] = read[0].ToString();
                }
                read.Close();
                sql.Close();

            }
            return data;
        }
        private List<string> FindFillial(Guid id)
        {
            sql = new SqlConnection(conn);
            string procedure = "FindFillial";
            List<string> data = new List<string>();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = id;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    data.Add("");
                    data[data.Count - 1] = read[0].ToString();
                }
                read.Close();
                sql.Close();

            }
            return data;
        }
        private List<string> Services()
        {
            sql = new SqlConnection(conn);
            string procedure = "ServicesProce";
            List<string> data = new List<string>();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;               
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    data.Add("");
                    data[data.Count - 1] = read[0].ToString();
                }
                read.Close();
                sql.Close();

            }
            return data;
        }
        private List<string>selectbanks()
        {
            sql = new SqlConnection(conn);
            string procedure = "selectbanks";
            List<string> data = new List<string>();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = command.ExecuteReader();
                
                while (read.Read())                {
                    data.Add("");
                    data[data.Count - 1] = read[0].ToString();                    
                }
                read.Close();
                sql.Close();               

            }
            return data;
        }
        private void open_payment(object sender, EventArgs e)
        {

            OpenPaymentForm.Name = "Открытие Счета";
            OpenPaymentForm.Width = 500;
            OpenPaymentForm.Height = 300;
            OpenPaymentForm.Text = "Открытие Счета";
            OpenPaymentForm.StartPosition = FormStartPosition.CenterScreen;

           
            List<string> data = selectbanks();
            foreach (string s in data)
            {
                SpisokBankov.Items.Add(s);
            }           
                        
            BanksLAble.Location = new Point(110, 20);
            BanksLAble.Text = "Выберите Банк из списка";
            BanksLAble.Width = 200;
            BanksLAble.Height = 13;
            SpisokBankov.Location = new Point(110,36);

            List<string> data1 = selectpaymenttips();
            foreach (string s in data1)
            {
                SpisokPaymentTips.Items.Add(s);
            }

            
            PaymentsTips.Text = "Выберите тип счета из списка";
            PaymentsTips.Location =new Point(110, 60);
            PaymentsTips.Width = 200;
            PaymentsTips.Height = 13;
            SpisokPaymentTips.Location = new Point(110, 76);

            OpenPaymentFinale.Location = new Point(315, 71);
            OpenPaymentFinale.Text = "Готово";
            OpenPaymentFinale.Name = "OpenPayment";
            OpenPaymentFinale.Width = 75;
            OpenPaymentFinale.Height = 25;
            OpenPaymentFinale.Click += new System.EventHandler(OpenPaymenlFinale);


            OpenPaymentForm.Controls.Add(PaymentsTips);
            OpenPaymentForm.Controls.Add(BanksLAble);
            OpenPaymentForm.Controls.Add(OpenPaymentFinale);
            OpenPaymentForm.Controls.Add(SpisokPaymentTips);
            OpenPaymentForm.Controls.Add(SpisokBankov);

            OpenPaymentForm.Show();        
        }
        public Guid BankGuid(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "FindBankIdByName";
            Guid n = new Guid();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@ID";                
                param1.SqlDbType = SqlDbType.UniqueIdentifier;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = (Guid)command.Parameters["@ID"].Value;
                sql.Close();                
            }
            return n;
        }
        public Guid TypeGuid(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "FindTypeIdByName";
            Guid n = new Guid();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@ID";
                param1.SqlDbType = SqlDbType.UniqueIdentifier;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = (Guid)command.Parameters["@ID"].Value;
                sql.Close();
            }
            return n;
        }
        public Guid ServId(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "FindServId";
            Guid n = new Guid();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@id";
                param1.SqlDbType = SqlDbType.UniqueIdentifier;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = (Guid)command.Parameters["@id"].Value;
                sql.Close();
            }
            return n;
        }
        public Guid FindFillialId(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "FindFillialId";
            Guid n = new Guid();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@id";
                param1.SqlDbType = SqlDbType.UniqueIdentifier;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = (Guid)command.Parameters["@id"].Value;
                sql.Close();
            }
            return n;
        }
        public int ServiceCost(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "ServiceCost";
            int n = new int();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@Sum";
                param1.SqlDbType = SqlDbType.Int;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = Int32.Parse(command.Parameters["@Sum"].Value.ToString());
                sql.Close();
            }
            return n;
        }
        public void Pay(Guid ServiceId ,Guid PaymentId, Guid FillialId)
        {
            sql = new SqlConnection(conn);
            string procedure = "Pay";
            //Guid n = new Guid();
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ServiceId";
                param.Value = ServiceId;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@PaymentId";
                param1.SqlDbType = SqlDbType.UniqueIdentifier;
                param1.Value = PaymentId;
                command.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@FillialId";
                param2.SqlDbType = SqlDbType.UniqueIdentifier;
                param2.Value = FillialId;
                command.Parameters.Add(param2);

                command.ExecuteNonQuery();                
                sql.Close();
            }
        }
        public void pay_metod_fin(object sender, EventArgs e)
        {
            if (SpisokFillials.SelectedItem != null && SpisokServices.SelectedItem != null)
            {
                string fillial = SpisokFillials.SelectedItem.ToString();
                string service = SpisokServices.SelectedItem.ToString();
                SpisokFillials.SelectedIndex = -1;
                SpisokServices.SelectedIndex = -1;
                SpisokFillials.Items.Clear();
                SpisokServices.Items.Clear();
                int cost = ServiceCost(service);
                int summ = HowMuchIHave(guid);
                if (cost > summ)
                {
                    MessageBox.Show(
        "На данном счету недостаточно средств для проведения этой операции. Пополните счет и повторите попытку!",
        "Возникла Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    Guid serviseid = ServId(service);
                    Guid FillialGuid = FindFillialId(fillial);
                    Pay(serviseid,guid, FillialGuid);
                    sql = new SqlConnection(conn);
                    string procedure = "Donate";
                    using (SqlCommand command = new SqlCommand(procedure, sql))
                    {
                        sql.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@id";
                        param.Value = guid;
                        param.SqlDbType = SqlDbType.UniqueIdentifier;
                        command.Parameters.Add(param);
                        SqlParameter param2 = new SqlParameter();
                        param2.ParameterName = "@sum";
                        param2.Value = -cost;
                        param2.SqlDbType = SqlDbType.Int;
                        command.Parameters.Add(param2);
                        command.ExecuteNonQuery();
                        sql.Close();
                    }
                }
                //PayForm.Controls.Clear();
                PayForm.Close();                
            }
        }
        public void pay_metod(object sender, EventArgs e)
        {
            try
            {
                guid = Guid.Parse(Showing.CurrentCell.Value.ToString());
                //Guid.TryParse(Showing.CurrentCell.Value.ToString(), out guid);

                PayForm.Name = "Оплата услуг";
                PayForm.Width = 500;
                PayForm.Height = 300;
                PayForm.Text = "Оплата услуг";
                PayForm.StartPosition = FormStartPosition.CenterScreen;

                List<string> data = FindFillial(guid);
                foreach (string s in data)
                {
                    SpisokFillials.Items.Add(s);
                }
                Label Fillial = new Label();
                Fillial.Text = "Выберите филиал";
                Fillial.Width = 150;
                Fillial.Height = 15;
                Fillial.Location = new Point(150, 60);
                SpisokFillials.Location = new Point(150, 76);

                List<string> data2 = Services();
                foreach (string s in data2)
                {
                    SpisokServices.Items.Add(s);
                }

                Label Service = new Label();
                Service.Text = "Выберите услугу";
                Service.Width = 150;
                Service.Height = 15;
                Service.Location = new Point(150, 110);
                SpisokServices.Location = new Point(150, 126);
                //Параметры кнопки оплаты
                PayButtonSec.Location = new Point(315, 71);
                PayButtonSec.Text = "Оплатить";
                PayButtonSec.Name = "Pay";
                PayButtonSec.Width = 75;
                PayButtonSec.Height = 25;
                PayButtonSec.Click += new System.EventHandler(pay_metod_fin);

                PayForm.Controls.Add(Service);
                PayForm.Controls.Add(Fillial);
                PayForm.Controls.Add(SpisokFillials);
                PayForm.Controls.Add(SpisokServices);
                PayForm.Controls.Add(PayButtonSec);
                PayForm.ShowDialog();

            }
            catch
            {
                MessageBox.Show(
        "Выберите ID Вашего счета",
        "Возникла Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public void donate_metod(object sender, EventArgs e)
        {
            try
            {
                guid = Guid.Parse(Showing.CurrentCell.Value.ToString());
                //Guid.TryParse(Showing.CurrentCell.Value.ToString(), out guid);
                DonateForm.Name = "Пополнение счета";
                DonateForm.Width = 500;
                DonateForm.Height = 300;
                DonateForm.Text = "Пополнение счета";
                DonateForm.StartPosition = FormStartPosition.CenterScreen;
                Label Summa = new Label();
                Summa.Text = "Сумма пополнения";
                Summa.Width = 150;
                Summa.Height = 15;
                Summa.Location = new Point(150,50);

                DonateSumBox.Height = 20;
                DonateSumBox.Width = 150;
                DonateSumBox.Location = new Point(150, 71);
                DonateSumBox.Name = "DonateSumBox";
                //Параметры кнопки удаления
                DonateFinale.Location = new Point(315, 71);
                DonateFinale.Text = "Пополнить";
                DonateFinale.Name = "Donate";
                DonateFinale.Width = 75;
                DonateFinale.Height = 25;
                DonateFinale.Click += new System.EventHandler(donate_metod_fin);
                
                DonateForm.Controls.Add(Summa);
                DonateForm.Controls.Add(DonateFinale);
                DonateForm.Controls.Add(DonateSumBox);
                DonateForm.ShowDialog();


            }
            catch
            {
                    MessageBox.Show(
            "Выберите ID Вашего счета",
            "Возникла Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            }                     
        }
        public void donate_metod_fin(object sender, EventArgs e)
        {
            int sum = new int();
            Int32.TryParse( DonateSumBox.Text,out sum);
            DonateSumBox.Text = "";
            sql = new SqlConnection(conn);
            string procedure = "Donate";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = guid;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@sum";
                param2.Value = sum;
                param2.SqlDbType = SqlDbType.Int;
                command.Parameters.Add(param2);
                command.ExecuteNonQuery();
                sql.Close();
            }
            DonateForm.Close();
            // DeleteUserForm.Hide();

        }
        public int HowMuchIHave(Guid id)
        {
            int count = 0;
            sql = new SqlConnection(conn);
            string procedure = "HowMuchIHave";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = guid;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@sum";                
                param2.SqlDbType = SqlDbType.Int;
                param2.Direction = ParameterDirection.Output;
                command.Parameters.Add(param2);
                command.ExecuteNonQuery();
                sql.Close();

                count = (int)command.Parameters["@sum"].Value;

            }

            return count;
        }
        public void withdrow_metod_fin(object sender, EventArgs e)
        {
            int summa = HowMuchIHave(guid);
            int sum = new int();
            Int32.TryParse(WithdrowBox.Text, out sum);
            WithdrowBox.Text = "";
            if (sum > summa)
            {
                MessageBox.Show(
            "На вашем счету недостаточно средств!",
            "Возникла Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {

                sql = new SqlConnection(conn);
                string procedure = "Donate";
                using (SqlCommand command = new SqlCommand(procedure, sql))
                {
                    sql.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@id";
                    param.Value = guid;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    command.Parameters.Add(param);
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@sum";
                    param2.Value = -sum;
                    param2.SqlDbType = SqlDbType.Int;
                    command.Parameters.Add(param2);
                    command.ExecuteNonQuery();
                    sql.Close();
                }
            }
            WithdrowForm.Close();
        }
        public void withdrow_metod(object sender, EventArgs e)
        {
            try
            {
                guid = Guid.Parse(Showing.CurrentCell.Value.ToString());                

                WithdrowForm.Name = "Снятие наличных с счета";
                WithdrowForm.Width = 500;
                WithdrowForm.Height = 300;
                WithdrowForm.Text = "Снятие наличных с счета";
                WithdrowForm.StartPosition = FormStartPosition.CenterScreen;

                Label Summa = new Label();
                Summa.Text = "Сумма вывода";
                Summa.Width = 150;
                Summa.Height = 15;
                Summa.Location = new Point(150, 50);

                WithdrowBox.Height = 20;
                WithdrowBox.Width = 150;
                WithdrowBox.Location = new Point(150, 71);
                WithdrowBox.Name = "WithdrowBox";
                //Параметры кнопки удаления
                WithdrowFinale.Location = new Point(315, 71);
                WithdrowFinale.Text = "Вывести";
                WithdrowFinale.Name = "Withdriow";
                WithdrowFinale.Width = 75;
                WithdrowFinale.Height = 25;
                WithdrowFinale.Click += new System.EventHandler(withdrow_metod_fin);

                WithdrowForm.Controls.Add(Summa);
                WithdrowForm.Controls.Add(WithdrowBox);
                WithdrowForm.Controls.Add(WithdrowFinale);
                WithdrowForm.ShowDialog();
            }
            catch
            {
                MessageBox.Show(
        "Выберите ID Вашего счета",
        "Возникла Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public void OpenPaymenlFinale(object sender, EventArgs e)
        {
                       
            if (SpisokPaymentTips.SelectedItem != null && SpisokBankov.SelectedItem != null)
            {
                string type = SpisokPaymentTips.SelectedItem.ToString();
                string bank = SpisokBankov.SelectedItem.ToString();
                Guid n = BankGuid(bank);
                Guid n1 = TypeGuid(type);
                sql = new SqlConnection(conn);
                string procedure = "CreatePayment";
                using (SqlCommand command = new SqlCommand(procedure, sql))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramText = new SqlParameter();
                    SqlParameter paramPaymentId = new SqlParameter();
                    SqlParameter paramSum = new SqlParameter();
                    SqlParameter paramUserId = new SqlParameter();
                    SqlParameter paramBankId = new SqlParameter();

                    paramText.ParameterName = "@Text";
                    paramText.Value = "Description";
                    paramText.SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.Add(paramText);

                    paramPaymentId.ParameterName = "@Paymentid";
                    paramPaymentId.Value = n1;
                    paramPaymentId.SqlDbType = SqlDbType.UniqueIdentifier;
                    command.Parameters.Add(paramPaymentId);

                    paramSum.ParameterName = "@Sum";
                    paramSum.SqlDbType = SqlDbType.Int;
                    paramSum.Value = 0;
                    command.Parameters.Add(paramSum);

                    paramUserId.ParameterName = "@Userid";
                    paramUserId.SqlDbType = SqlDbType.UniqueIdentifier;
                    paramUserId.Value = User_ID;
                    command.Parameters.Add(paramUserId);

                    paramBankId.ParameterName = "@Bankid";
                    paramBankId.SqlDbType = SqlDbType.UniqueIdentifier;
                    paramBankId.Value = n;
                    command.Parameters.Add(paramBankId);

                    sql.Open();
                    command.ExecuteNonQuery();

                    sql.Close();
                }
            }
            SpisokBankov.SelectedIndex = -1;
            SpisokPaymentTips.SelectedIndex = -1;
            SpisokPaymentTips.Items.Clear();
            SpisokBankov.Items.Clear();
            OpenPaymentForm.Hide();
           }
        public void user_info(object sender, EventArgs e)
        {   
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "MiddleName", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Отчество", Width = 100 });            
            sql = new SqlConnection(conn);
            string procedure = "selectuserinfo";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@UserId";
                param.Value = User_ID;
                param.SqlDbType = SqlDbType.UniqueIdentifier;                
                command.Parameters.Add(param);
                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();                    
                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }
        }
        public void Copy()
        {
            sql = new SqlConnection(conn);
            string procedure = "Copy";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@id";
                param4.Value = User_ID;
                param4.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param4);
                command.ExecuteNonQuery();
                sql.Close();
            }
        }
        public void change_info(object sender, EventArgs e)
        {            
            ChangeInfo.Name = "ChangeInfo";
            ChangeInfo.Width = 500;
            ChangeInfo.Height = 300;
            ChangeInfo.Text = "Изменение данных";
            ChangeInfo.StartPosition = FormStartPosition.CenterScreen;

            ChangeName_lable.Width = 150;
            ChangeName_lable.Height = 13;
            ChangeName_lable.Text = "Сменить Имя";
            ChangeName_lable.Name = "Change_lable";
            ChangeName_lable.Location = new Point(150, 20);

            ChangeName_box.Height = 20;
            ChangeName_box.Width = 150;
            ChangeName_box.Location = new Point(150, 36);
            ChangeName_box.Name = "Change_box";

            ChangeMiddleName_lable.Width = 150;
            ChangeMiddleName_lable.Height = 13;
            ChangeMiddleName_lable.Text = "Сменить Фамилию";
            ChangeMiddleName_lable.Name = "ChangeMiddleName_lable";
            ChangeMiddleName_lable.Location = new Point(150, 60);

            ChangeMiddleName_box.Height = 20;
            ChangeMiddleName_box.Width = 150;
            ChangeMiddleName_box.Location = new Point(150, 76);
            ChangeMiddleName_box.Name = "ChangeMiddleName_box";

            ChangeLastName_lable.Width = 150;
            ChangeLastName_lable.Height = 13;
            ChangeLastName_lable.Text = "Сменить Отчество";
            ChangeLastName_lable.Name = "ChangeLastName_lable";
            ChangeLastName_lable.Location = new Point(150, 100);

            ChangeLastName_box.Height = 20;
            ChangeLastName_box.Width = 150;
            ChangeLastName_box.Location = new Point(150, 116);
            ChangeLastName_box.Name = "ChangeLastName_box";


            ChangeInfoBut.Location = new Point(315, 71);
            ChangeInfoBut.Text = "Подтвердить";
            ChangeInfoBut.Name = "ChangeInfoBut";
            ChangeInfoBut.Width = 100;
            ChangeInfoBut.Height = 25;
            ChangeInfoBut.Click += new System.EventHandler(change_info_end);

            ChangeInfo.Controls.Add(ChangeName_lable);
            ChangeInfo.Controls.Add(ChangeName_box);
            ChangeInfo.Controls.Add(ChangeMiddleName_lable);
            ChangeInfo.Controls.Add(ChangeMiddleName_box);
            ChangeInfo.Controls.Add(ChangeLastName_lable);
            ChangeInfo.Controls.Add(ChangeLastName_box);
            ChangeInfo.Controls.Add(ChangeInfoBut);

            ChangeInfo.ShowDialog();

        }
        public void add_user(object sender, EventArgs e)
        {
            //Showing.Rows.Clear();
            //Showing.Columns.Clear();
            
            AddUser.Name = "Добавление пользователя";
            AddUser.Width = 500;
            AddUser.Height = 300;
            AddUser.Text = "Добавление";
            AddUser.StartPosition = FormStartPosition.CenterScreen;

            
            Login_lable.Width = 100;
            Login_lable.Height = 13;
            Login_lable.Text = "Логин";
            Login_lable.Name = "Login_lable";
            Login_lable.Location = new Point(150, 20);
            
            Login_box.Height = 20;
            Login_box.Width = 150;
            Login_box.Location = new Point(150, 36);
            Login_box.Name = "Login_box";

            
            Password_lable.Width = 100;
            Password_lable.Height = 13;
            Password_lable.Text = "Пароль";
            Password_lable.Name = "Password_lable";
            Password_lable.Location = new Point(150, 60);
            
            Password_box.Height = 20;
            Password_box.Width = 150;
            Password_box.Location = new Point(150, 76);
            Password_box.Name = "Password_box";

            Add.Location = new Point(315,71);
            Add.Text = "Готово";
            Add.Name = "Add";
            Add.Width = 75;
            Add.Height = 25;
            Add.Click += new System.EventHandler(add_user_end);

            AddUser.Controls.Add(Password_lable);
            AddUser.Controls.Add(Password_box);           
            AddUser.Controls.Add(Login_lable);
            AddUser.Controls.Add(Login_box);
            AddUser.Controls.Add(Add);

            AddUser.ShowDialog();
        }
        public void delete_user(object sender, EventArgs e)
        {            
                try
                {
                    guid = Guid.Parse(Showing.CurrentCell.Value.ToString());
                    int role =  CheckRole(guid);
                if (role == -1)
                { throw new Exception(); }
                else if (role == 0)
                { throw new Exception(); }
                else
                {
                    List<string[]> data = new List<string[]>();
                    sql = new SqlConnection(conn);
                    string procedure = "ShowPayment";
                    using (SqlCommand command = new SqlCommand(procedure, sql))
                    {
                        sql.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@id";
                        param.Value = guid;
                        param.SqlDbType = SqlDbType.UniqueIdentifier;
                        command.Parameters.Add(param);

                        SqlDataReader read = command.ExecuteReader();

                        while (read.Read())
                        {
                            data.Add(new string[7]);
                            data[data.Count - 1][0] = read[0].ToString();
                            data[data.Count - 1][1] = read[1].ToString();
                            data[data.Count - 1][2] = read[2].ToString();
                            data[data.Count - 1][3] = read[3].ToString();
                            data[data.Count - 1][4] = read[4].ToString();
                            data[data.Count - 1][5] = read[5].ToString();
                            data[data.Count - 1][6] = read[6].ToString();

                        }
                        read.Close();
                        sql.Close();
                    }
                    foreach (string[] s in data)
                    {

                        Guid guid_Payment = new Guid();
                        guid_Payment = Guid.Parse(s[6]);
                        ClosePayment(guid_Payment);
                    }
                    DeleteUserMetod(guid);
                }
             }
                catch {
                    MessageBox.Show(
        "Выберите ID Пользователя",
        "Возникла Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);
                }                      
        }
        public void DeleteUserMetod(Guid user_id)
        {
            sql = new SqlConnection(conn);
            string procedure = "deletion";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = user_id;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
                sql.Close();
            }
        }
        private void change_info_end(object sender, EventArgs e)
        {

            //string id = DeleteUserTextbox.Text;
            //DeleteUserTextbox.Text = "";
            if (ChangeName_box.Text != "" && ChangeMiddleName_box.Text != "" && ChangeLastName_box.Text != "")
            {
                Copy();
                sql = new SqlConnection(conn);
                string procedure = "changeinfo";
                using (SqlCommand command = new SqlCommand(procedure, sql))
                {
                    sql.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Name";
                    param.Value = ChangeName_box.Text.ToString();
                    param.SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@SerName";
                    param2.Value = ChangeMiddleName_box.Text.ToString();
                    param2.SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.Add(param2);

                    SqlParameter param3 = new SqlParameter();
                    param3.ParameterName = "@LastName";
                    param3.Value = ChangeLastName_box.Text.ToString();
                    param3.SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.Add(param3);

                    SqlParameter param4 = new SqlParameter();
                    param4.ParameterName = "@id";
                    param4.Value = User_ID;
                    param4.SqlDbType = SqlDbType.UniqueIdentifier;
                    command.Parameters.Add(param4);

                    command.ExecuteNonQuery();
                    sql.Close();
                }
            }
                ChangeName_box.Text = "";
                ChangeMiddleName_box.Text = "";
                ChangeLastName_box.Text = "";
            
            ChangeInfo.Close();
            // DeleteUserForm.Hide();
        }        
        private void Exit_panel(object sender, EventArgs e)
        {
            this.Close();
        }
        private void add_user_end(object sender, EventArgs e)
        {
            string Login = Login_box.Text;
            string password = Password_box.Text;
            //string lastname = LastName.Text;
            Login_box.Text = "";
            Password_box.Text = "";
            LastName.Text = "";
            if (Login != "" & password != "" )
            {
                int bol = CheckUser(Login);
                if (bol == 1)
                {
                    sql = new SqlConnection(conn);
                    string procedure = "inserting";
                    using (SqlCommand command = new SqlCommand(procedure, sql))
                    {
                        sql.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@Login";
                        param.Value = Login.ToString();
                        param.SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.Add(param);
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@Password";
                        param1.Value = password.ToString();
                        param1.SqlDbType = SqlDbType.NVarChar;
                        command.Parameters.Add(param1);
                        //SqlParameter param2 = new SqlParameter();
                        //param2.ParameterName = "@LastName";
                        //param2.Value = lastname.ToString();
                        //param2.SqlDbType = SqlDbType.NVarChar;
                        //command.Parameters.Add(param2);
                        command.ExecuteNonQuery();
                        sql.Close();
                    }
                }
                else
                {
                    MessageBox.Show(
            "Логин уже есть в системе",
            "Возникла Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            //AddUser.Controls.Clear();
            AddUser.Close();
            //AddUser.Hide();
        }
        private void view_users(object sender, EventArgs e )
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Login", HeaderText = "Логин", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Password", HeaderText = "Пароль", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "id", HeaderText = "id", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Role", HeaderText = "Роль", Width = 100 });
            sql = new SqlConnection(conn);
            string procedure = "selection";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[4]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }
        }
        private void view_payments(object sender, EventArgs e)
        {
            Showing.Rows.Clear();
            Showing.Columns.Clear();
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Login", HeaderText = "Имя", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Password", HeaderText = "Фамилия", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "id", HeaderText = "Отчество", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Bank", HeaderText = "Банк", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Type", HeaderText = "Тип счета", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Sum", HeaderText = "Сумма", Width = 100 });
            Showing.Columns.Add(new DataGridViewTextBoxColumn() { Name = "idPayment", HeaderText = "Id счета", Width = 100 });
            sql = new SqlConnection(conn);
            string procedure = "ShowPayment";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = User_ID;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);

                SqlDataReader read = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (read.Read())
                {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                    data[data.Count - 1][4] = read[4].ToString();
                    data[data.Count - 1][5] = read[5].ToString();
                    data[data.Count - 1][6] = read[6].ToString();

                }
                read.Close();
                sql.Close();

                foreach (string[] s in data)
                {
                    Showing.Rows.Add(s);
                }

            }
        }
        private void AdminPannel_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public List<string[]> ShowMyServices()
        {
            List<string[]> data = new List<string[]>();
            sql = new SqlConnection(conn);
            string procedure = "ShowMyServices";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = User_ID;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);
                SqlDataReader read = command.ExecuteReader();
                
                while (read.Read())
                {
                    data.Add(new string[8]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                    data[data.Count - 1][3] = read[3].ToString();
                    data[data.Count - 1][4] = read[4].ToString();
                    data[data.Count - 1][5] = read[5].ToString();
                    data[data.Count - 1][6] = read[6].ToString();
                    data[data.Count - 1][7] = read[7].ToString();
                }
                read.Close();
                sql.Close();

            }
            return data;
        }
        public int CheckUser(string name)
        {
            sql = new SqlConnection(conn);
            string procedure = "CheckUser";
            int n = -1;
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@name";
                param.Value = name;
                param.SqlDbType = SqlDbType.NVarChar;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@res";
                param1.SqlDbType = SqlDbType.Int;
                param1.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(param1);

                command.ExecuteNonQuery();
                n = Int32.Parse(command.Parameters["@res"].Value.ToString());
                sql.Close();
            }
            return n;           
        }
        public void ClosePayment (Guid id)
        {
            sql = new SqlConnection(conn);
            string procedure = "ClosePayment";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = id;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);                
                command.ExecuteNonQuery();
                sql.Close();
            }
        }
        public int CheckRole(Guid User_id)
        {
            int result = -1;
            sql = new SqlConnection(conn);
            string procedure = "ReturnRole";
            using (SqlCommand command = new SqlCommand(procedure, sql))
            {
                sql.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = User_id;
                param.SqlDbType = SqlDbType.UniqueIdentifier;
                command.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@role";
                param1.Value = result;
                param1.SqlDbType = SqlDbType.Int;
                param1.Direction = ParameterDirection.Output;
                command.Parameters.Add(param1);
                command.ExecuteNonQuery();
                result = Int32.Parse(command.Parameters["@role"].Value.ToString());
                sql.Close();
            }
            return result;
        }
        
    }
}
