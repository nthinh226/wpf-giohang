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

namespace giohang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SanPham> listSanPham = new List<SanPham>();
        public MainWindow()
        {
            InitializeComponent();
            dataCart.SelectionChanged += new SelectionChangedEventHandler(dataCart_SelectionChanged);
        }

        private void AddToCart_Clicked(object sender, RoutedEventArgs e)
        {
            if (listSanPham.Count == 0)
            {
                if (txtmasp.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã sản phẩm!!");
                    txtmasp.Focus();
                }
                else if (txttensp.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm!!");
                    txttensp.Focus();
                }
                else if (int.Parse(txtslsp.Text) == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng sản phẩm!!");
                    txtslsp.Focus();
                }
                else if (int.Parse(txtdongia.Text) == 0)
                {
                    MessageBox.Show("Vui lòng nhập đơn giá sản phẩm!!");
                    txtdongia.Focus();
                }
                else
                {
                    SanPham tempSanPham = new SanPham();
                    tempSanPham.maSP = txtmasp.Text;
                    tempSanPham.tenSP = txttensp.Text;
                    tempSanPham.soLuong = int.Parse(txtslsp.Text);
                    tempSanPham.donGia = double.Parse(txtdongia.Text);
                    listSanPham.Add(tempSanPham);
                    resetInfo();
                }
            }
            else
            {
                for (int i = listSanPham.Count - 1; i >= 0; i--)
                {
                    if (listSanPham[i].maSP == txtmasp.Text)
                    {
                        listSanPham[i].soLuong += int.Parse(txtslsp.Text);
                        resetInfo();
                        break;
                    }
                    else
                    {
                        SanPham tempSanPham = new SanPham();
                        if (txtmasp.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã sản phẩm!!");
                            txtmasp.Focus();
                        }
                        else if (txttensp.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên sản phẩm!!");
                            txttensp.Focus();
                        }
                        else if (int.Parse(txtslsp.Text) == 0)
                        {
                            MessageBox.Show("Vui lòng nhập số lượng sản phẩm!!");
                            txtslsp.Focus();
                        }
                        else if (int.Parse(txtdongia.Text) == 0)
                        {
                            MessageBox.Show("Vui lòng nhập đơn giá sản phẩm!!");
                            txtdongia.Focus();
                        }
                        else
                        {
                            tempSanPham.maSP = txtmasp.Text;
                            tempSanPham.tenSP = txttensp.Text;
                            tempSanPham.soLuong = int.Parse(txtslsp.Text);
                            tempSanPham.donGia = double.Parse(txtdongia.Text);
                            listSanPham.Add(tempSanPham);
                            resetInfo();
                            break;
                        }
                    }
                }
            }
            dataCart.ItemsSource = null;
            dataCart.ItemsSource = listSanPham;

        }
        private void resetInfo()
        {
            txtmasp.Text = string.Empty;
            txttensp.Text = string.Empty;
            txtslsp.Text = "0";
            txtdongia.Text = "0";
        }

        private void dataCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                foreach (SanPham item in dataCart.SelectedItems)
                {
                    txtmasp.Text = item.maSP;
                    txttensp.Text = item.tenSP;
                    txtslsp.Text = item.soLuong.ToString();
                    txtdongia.Text = item.donGia.ToString();
                }
                btnDel.IsEnabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void removeItemCart_Clicked(object sender, RoutedEventArgs e)
        {
            for (int i = listSanPham.Count - 1; i >= 0; i--)
            {
                if (listSanPham[i].maSP == txtmasp.Text)
                {
                    listSanPham.RemoveAt(i);
                    MessageBox.Show("Xoá thành công!");
                    btnDel.IsEnabled = false;
                    resetInfo();
                    break;
                }
            }

            dataCart.ItemsSource = null;
            dataCart.ItemsSource = listSanPham;

            dataCart.SelectedIndex = -1;
            dataCart.SelectionChanged +=
                new SelectionChangedEventHandler(dataCart_SelectionChanged);
        }
    }
    public class SanPham
    {
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public int soLuong { get; set; }
        public double donGia { get; set; }
    }
}
