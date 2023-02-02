using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class CheckInOut : Form
    {
        public CheckInOut()
        {
            InitializeComponent();
        }

       

        private void CheckInOut_Load(object sender, EventArgs e)
        {
            timerCheck.Start();
            ThemeColor.LoadColos(this, false);
        }

        CheckIn diemDanh = new CheckIn();
        public int CheckThu()       // Check Thứ Now để lấy cột của thứ Now để lấy ca ra và tính Time đúng của ca làm.
        {
            int cot = 0;
            int yy = Convert.ToInt32(DateTime.Now.Year.ToString());
            int dd = Convert.ToInt32(DateTime.Now.Month.ToString());
            int kk = Convert.ToInt32(DateTime.Now.Day.ToString());
            DateTime dt = new DateTime(yy, dd, kk);
            string thu = dt.DayOfWeek.ToString().Trim();

            if (thu == "Monday")
                cot = 1;
            if (thu == "Tuesday")
                cot = 2;
            if (thu == "Wednesday")
                cot = 3;
            if (thu == "Thursday")
                cot = 4;
            if (thu == "Friday")
                cot = 5;
            if (thu == "Saturday")
                cot = 6;
            if (thu == "Sunday")
                cot = 7;
            return cot;
        }



        int flag = 0;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Global.GlobalUserId;
                SqlCommand command = new SqlCommand(" SELECT * FROM ChiaCa WHERE Id = '" + name + "'");
                DataTable tablec = diemDanh.getdata(command);
                string test = tablec.Rows[0][CheckThu()].ToString().Trim();   // Lấy số mã hóa ca ra, nếu số 1 là làm ca 2 và 3

                int HourInt = Convert.ToInt32(DateTime.Now.Hour.ToString());
                if (test == "2" || test == "-2")
                {
                    if (radioButtonSang.Checked == true)
                    {
                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeStartCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                    if (radioButtonTrua.Checked == true)
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    if (radioButtonToi.Checked == true)
                    {
                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeStartCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                }
                if (test == "1" || test == "-1")
                {
                    if (radioButtonSang.Checked == true)
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    if (radioButtonTrua.Checked == true)
                    {
                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeStartCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                    if (radioButtonToi.Checked == true)
                    {
                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeStartCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                }
                if (test == "3" || test == "-3")
                {
                    if (radioButtonSang.Checked == true)
                    {
                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeStartCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }

                    if (radioButtonTrua.Checked == true)
                    {
                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeStartCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                    if (radioButtonToi.Checked == true)
                    {
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    }
                }
                else
                {
                    if (radioButtonSang.Checked == true)
                    {
                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeStartCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }

                    if (radioButtonTrua.Checked == true)
                    {
                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeStartCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                    if (radioButtonToi.Checked == true)
                    {
                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeStartCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Bat dau tinh thoi gian ca lam.");
                            this.flag = 1;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bạn chưa được chia ca");
            }
        }



        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                string name = Global.GlobalUserId;
                SqlCommand command = new SqlCommand(" SELECT * FROM ChiaCa WHERE Id = '" + name + "'");
                DataTable tablec = diemDanh.getdata(command);

                string test = tablec.Rows[0][CheckThu()].ToString().Trim();   // Lấy số mã hóa ca ra, nếu số 1 là làm ca 2 và 3
                int HourInt = Convert.ToInt32(DateTime.Now.Hour.ToString());


                if (test == "2" || Text == "-2")
                {
                    if (radioButtonSang.Checked == true)
                    {

                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                    else if (radioButtonTrua.Checked == true)
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    else 
                    {


                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                }
                if (test == "1" || test == "-1")
                {
                    if (radioButtonSang.Checked == true)
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    else if (radioButtonTrua.Checked == true)
                    {

                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                    else 
                    {

                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                }
                if (test == "3" || test == "-3")
                {

               
                    if (radioButtonSang.Checked == true)
                    {

                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                    else if (radioButtonTrua.Checked == true)
                    {

                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                    else
                    {
                        MessageBox.Show("Khong phai ca lam cua ban.");
                    }
                }

                if (test == "0")
                {
                    if (radioButtonSang.Checked == true)
                    {

                        if (HourInt >= 7 && HourInt <= 11)
                        {
                            diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;
                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                    else if (radioButtonTrua.Checked == true)
                    {
                        if (HourInt >= 13 && HourInt < 17)
                        {
                            diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                    }
                    else
                    {


                        if (HourInt >= 18 && HourInt < 22)
                        {
                            diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                            MessageBox.Show("Stop tinh thoi gian ca lam.");
                            this.flag = 0;

                        }
                        else
                            MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa bắt đầu tính giờ làm");
            }
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour.ToString() == "22")
            {
                timerCheck.Stop();
               if (this.flag == 1)
                {
                    string name = Global.GlobalUserId;
                    SqlCommand command = new SqlCommand(" SELECT * FROM ChiaCa WHERE Id = '" + name + "'");
                    DataTable tablec = diemDanh.getdata(command);

                    string test = tablec.Rows[0][CheckThu()].ToString().Trim();   // Lấy số mã hóa ca ra, nếu số 1 là làm ca 2 và 3
                    int HourInt = Convert.ToInt32(DateTime.Now.Hour.ToString());

                    if (test == "2" || Text == "-2")
                    {
                        if (radioButtonSang.Checked == true)
                        {

                            if (HourInt >= 7 && HourInt <= 11)
                            {
                                diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;
                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                        else if (radioButtonTrua.Checked == true)
                            MessageBox.Show("Khong phai ca lam cua ban.");
                        else
                        {


                            if (HourInt >= 18 && HourInt < 22)
                            {
                                diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                    }
                    if (test == "1" || test == "-1")
                    {
                        if (radioButtonSang.Checked == true)
                            MessageBox.Show("Khong phai ca lam cua ban.");
                        else if (radioButtonTrua.Checked == true)
                        {

                            if (HourInt >= 11 && HourInt < 15)
                            {
                                diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                        else
                        {

                            if (HourInt >= 18 && HourInt < 22)
                            {
                                diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                    }
                    if (test == "3" || test == "-3")
                    {
                        if (radioButtonSang.Checked == true)
                        {

                            if (HourInt >= 7 && HourInt <= 11)
                            {
                                diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                        else if (radioButtonTrua.Checked == true)
                        {

                            if (HourInt >= 11 && HourInt < 15)
                            {
                                diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                        else
                        {
                            MessageBox.Show("Khong phai ca lam cua ban.");
                        }
                    }

                    if (test == "0")
                    {
                        if (radioButtonSang.Checked == true)
                        {

                            if (HourInt >= 7 && HourInt <= 11)
                            {
                                diemDanh.updateTimeEndCa1(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;
                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                        else if (radioButtonTrua.Checked == true)
                        {
                            if (HourInt >= 11 && HourInt < 15)
                            {
                                diemDanh.updateTimeEndCa2(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");
                        }
                        else
                        {


                            if (HourInt >= 18 && HourInt < 22)
                            {
                                diemDanh.updateTimeEndCa3(name, Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")));
                                MessageBox.Show("Stop tinh thoi gian ca lam.");
                                this.flag = 0;

                            }
                            else
                                MessageBox.Show("Khong phai thoi gian bat dau ca lam.");

                        }
                    }
                }

            }
        }
    }
}
