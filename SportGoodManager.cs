using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ListSportingGoodsApp
{
    internal class SportGoodManager
    {
        // список дел
        private List<SportGood> sports;

        // конструктор по умолчанию
        public SportGoodManager()
        {
            sports = new List<SportGood>();
        }

        // методы для работы со списком дел

        // 1. добавить дело в список
        public void AddSportGood(string description)
        {
            ValidateSportGood(description);
            sports.Add(new SportGood(description, DateTime.Now));
        }

        // 2. получить список дел
        public List<SportGood> GetAll()
        {
            return new List<SportGood>(sports);
        }

        // 3. удаление дела
        public void RemoveAt(int index)
        {
            sports.RemoveAt(index);
        }        

        // 4. получить дело по индексу
        public SportGood At(int index)
        {
            return sports[index];
        }

        // 5. обновить дело по индексу
        public void UpdateSportGood(string description, int index)
        {
            ValidateSportGood(description);
            sports[index] = new SportGood(description, DateTime.Now);
        }

        // 6. Очистка списка
        public void Clear()
        {
            sports.Clear();
        }

        // Поиск по названию
        public List<SportGood> FilterSportGood(string descriptionPattern)
        {
            descriptionPattern = descriptionPattern.ToLower();
            List<SportGood> newSportList = sports
                .Where(todo => todo.Description.ToLower()
                .Contains(descriptionPattern))
                .ToList();
            return newSportList;
        }
        private void ValidateSportGood(string description)
        {
            if (description == null || description == string.Empty)
            {
                throw new ArgumentException("описание не может быть пустым");
            }            
        }
    }
}
