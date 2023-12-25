using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListSportingGoodsApp
{
    public partial class MyForm : Form
    {
        // поле, связывающие логику и интерфейс
        private SportGoodManager manager = new SportGoodManager();
        // Списки со спорттоварами
        string[] WinterSports = new string[]
            {
                "Беговые лыжи",
                "Горные лыжи",
                "Туристические лыжи",
                "Хокейные коньки",
                "Клюшки",
                "Коньки для фигурного катания",
                "Лыжероллеры",
                "Сноуборды"
            };
        string[] BallGames = new string[] {
            "Мяч для регби",
            "Баскетбольный мяч",
            "Баскетбольное кольцо",
            "Бита бейсбольная",
            "Мяч бейсбольный",
            "Мяч волейбольный",
            "Мяч футбольный"
        };
        string[] SummerSports = new string[] {
            "Ракетки",
            "Воланы",
            "Велосипед горный",
            "Велосипед городской",
            "Мячи тенисные",
            "Ласты",
            "Маски и трубки для подводного плавания",
            "Ролики",
            "Самокаты"
        };
        string[] MartialArts = new string[]
        {
            "Перчатки",
            "Защита",
            "Груши и мешки"
        };

        public MyForm()
        {
            InitializeComponent();
            comboBox1.Text = "Виды спорта";            
        }

        // метод отображения списка дел в интерфейсе
        private void ViewSportGoodList()
        {
            // удалить старый контент
            sportListBox.Items.Clear();
            
            // записать обновленную версию
            List<SportGood> todos = manager.GetAll();
            for (int i = 0; i < todos.Count; i++)
            {
                sportListBox.Items.Add($"{i + 1} " +
                    $"{todos[i].Description}");
            }
        }
        // Кнопка выхода из приложения
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Выход
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Выход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        // Показать список
        private void showButton_Click(object sender, EventArgs e)
        {
            if (manager != null)
            {
                manager.Clear();
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    foreach (string s in WinterSports)
                    {
                        manager.AddSportGood(s);
                    }
                    break;
                case 1:
                    foreach (string s in BallGames)
                    {
                        manager.AddSportGood(s);
                    }
                    break;
                case 2:
                    foreach (string s in SummerSports)
                    {
                        manager.AddSportGood(s);
                    }
                    break;
                case 3:
                    foreach (string s in MartialArts)
                    {
                        manager.AddSportGood(s);
                    }
                    break;
            }
            ViewSportGoodList();
        }
        // Добавить позицию
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // вызываем логику
                string description = textBox1.Text;                
                manager.AddSportGood(description);
                ViewSportGoodList();
                textBox1.Text = null;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    $"Некорректный ввод: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Что-то пошло не так: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        // Удалить выбранную позицию
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (sportListBox.SelectedIndex != -1)
            {
                manager.RemoveAt(sportListBox.SelectedIndex);
                textBox1.Text = null;
                ViewSportGoodList();
            }
            else
            {
                MessageBox.Show(
                    $"Элемент не выбран",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        // Выделение позиции
        private void sportListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sportListBox.SelectedIndex != -1)
            {
                SportGood selected = manager.At(sportListBox.SelectedIndex);
                textBox1.Text = selected.Description;                
            }
        }
        // Редактировать
        private void editButton_Click(object sender, EventArgs e)
        {
            if (sportListBox.SelectedIndex != -1)
            {
                string description = textBox1.Text;                
                manager.UpdateSportGood(description, sportListBox.SelectedIndex);
                textBox1.Text = null;
                ViewSportGoodList();
            }
            else
            {
                MessageBox.Show(
                    $"Элемент не выбран",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        // Удалить выведенный список
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            sportListBox.Items.Clear();
        }
    }
}
