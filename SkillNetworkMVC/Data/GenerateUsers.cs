using SkillNetworkMVC.Models.Users;
using System.Collections.Generic;
using System;

namespace SkillNetworkMVC.Data
{
    public class GenerateUsers
    {
        public readonly string[] maleNames = new string[] { "Пьетро", "Аслан", "Виталик", "Иннокентий", "Давид", "Серго", "Юджин", "Билли", "Джордж", "Евлампий" };
        public readonly string[] femaleNames = new string[] { "Панам", "Джуди", "Сандра", "Маша" };
        public readonly string[] lastNames = new string[] { "Тестов", "Титушкин", "Габдурахманов", "Нурмангалиев", "Иванов" };

        public List<User> Populate(int count)
        {
            var users = new List<User>();
            for (int i = 1; i < count; i++)
            {
                string firstName;
                var rand = new Random();

                var male = rand.Next(1, 2) == 1;

                var lastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rand.Next(0, maleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "a";
                    firstName = femaleNames[rand.Next(0, femaleNames.Length - 1)];
                }

                var item = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = DateTime.Now.AddDays(-rand.Next(1, (DateTime.Now - DateTime.Now.AddYears(-25)).Days)),
                    Email = "test" + rand.Next(0, 1204) + "@test.com",
                };

                item.UserName = item.Email;
                item.Image = "https://thispersondoesnotexist.com/image";

                users.Add(item);
            }

            return users;
        }
    }
}
