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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using _3ISP919_Naliv_LoginReg.DB;
using _3ISP919_Naliv_LoginReg.Windows;
using _3ISP919_Naliv_LoginReg.ClassHelper;

namespace _3ISP919_Naliv_LoginReg.Windows
{
    public partial class AddEditUserWindow : Window
    {
        private string pathImageUser = null;
        private bool isEditUser = false;
        private Client editUser;

        public AddEditUserWindow()
        {
            // конструктор для добавления
            InitializeComponent();

            isEditUser = false;
        }

        public AddEditUserWindow(Client client)
        {
            // конструктор для редактирования

            InitializeComponent();


            // Изменения заголовка и текста кнопки
            TblockTitle.Text = "Редактирование пользователя";
            BtnAddEditService.Content = "Сохранить изменения";

            // Заполнение текстовых полей 
            TbSurname.Text = client.Surname.ToString();
            TbName.Text = client.Name.ToString();
            TbPatronymic.Text = client.Patronymic.ToString();

            // вывод изображения

            if (client.PhotoPath != null)
            {
                ImgService.Source = new BitmapImage(new Uri(client.PhotoPath));
            }


            isEditUser = true;
            editUser = client;

        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // выбор фото 

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog.ShowDialog() == true)
            {
                ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImageUser = openFileDialog.FileName;
            }
        }

        private void BtnAddEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (isEditUser == true)
            {
                // изменение
                editUser.Surname = TbSurname.Text;
                editUser.Name = TbName.Text;
                editUser.Patronymic = TbPatronymic.Text;
                if (pathImageUser != null)
                {
                    editUser.PhotoPath = pathImageUser;
                }

                EFClass.context.SaveChanges();
                this.Close();
                MessageBox.Show("Пользователь успешно измененен");

            }
            else
            {
                // добавление
                Client client = new Client();
                client.Surname = TbSurname.Text;
                client.Name = TbName.Text;
                client.Patronymic = TbPatronymic.Text;
                if (pathImageUser != null)
                {
                    client.PhotoPath = pathImageUser;
                }

                EFClass.context.Client.Add(client);
                EFClass.context.SaveChanges();
                this.Close();
                MessageBox.Show("Пользователь успешно добавлен");
            }
        }
    }
}