using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCProject.View;
using MVCProject.Model;

namespace MVCProject.Controller
{
    class AppController
    {
        private static AppController instance = null;
        public static AppController Instantiate()
        {
            if (AppController.instance == null)
            {
                AppController.instance = new AppController();
            }

            return AppController.instance;
        }

        public int Loop()
        {
            string userCommand;
            bool isEnableEcho = true;
            while (true)
            { 
                userCommand = ViaConsole.ReadCommand().ToLower();

                switch (userCommand)
                {
                    case "select": 
                        {
                            if (isEnableEcho)
                            {
                                ViaConsole.WriteResponse(AppModel.DBrequest("SELECT * FROM users"), false);
                                break;
                            }
                            else
                            {
                                ViaConsole.WriteResponse("Запрос невозможен - эхо сервис выключен", false);
                                break;
                            }
                        } 
                    case "insert": 
                        {
                            if (isEnableEcho)
                            {
                                ViaConsole.WriteResponse("Введите логин:", true);
                                string login = userCommand = ViaConsole.ReadCommand().ToLower();
                                ViaConsole.WriteResponse("Введите пароль:", true);
                                string password = userCommand = ViaConsole.ReadCommand().ToLower();
                                ViaConsole.WriteResponse("Введите имя:", true);
                                string firstname = userCommand = ViaConsole.ReadCommand().ToLower();
                                ViaConsole.WriteResponse("Введите фамилию:", true);
                                string lastname = userCommand = ViaConsole.ReadCommand().ToLower();
                                ViaConsole.WriteResponse("Введите страну:", true);
                                string position = userCommand = ViaConsole.ReadCommand().ToLower();
                                ViaConsole.WriteResponse(AppModel.DBrequest(string
                                    .Format("INSERT INTO users ('login', 'password', 'firstname', 'lastname', 'position')" + 
                                    "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", login, password, firstname, lastname, position)), false);
                                ViaConsole.WriteResponse("Запись успешно добавилась в базу данных", false);
                                break;
                            }
                            else
                            {
                                ViaConsole.WriteResponse("Запрос невозможен - эхо сервис выключен", false);
                                break;
                            }
                        } 
                    case "help": this.HelpCommand(); break;
                    case "disable echo":
                        {
                            if (isEnableEcho == false)
                            {
                                ViaConsole.WriteResponse("Эхо сервис уже выключен.", false);
                                break;
                            }
                            else isEnableEcho = false;
                            break;
                        }
                    case "enable echo":
                        {
                            if (isEnableEcho)
                            {
                                ViaConsole.WriteResponse("Эхо сервис уже включен.", false);
                                break;
                            }
                            else isEnableEcho = true;
                            break;
                        }
                    case "print":
                        {
                            if (isEnableEcho)
                            {
                                ViaConsole.WriteResponse("Введите текст, который необходимо напечатать: ", true);
                                userCommand = ViaConsole.ReadCommand();
                                ViaConsole.WriteResponse(string.Format("Успешно напечатано: {0}", userCommand), false);
                                break;
                            }
                            else
                            {
                                ViaConsole.WriteResponse("Печать невозможна - эхо сервис выключен", false);
                                break;
                            }
                        }
                    case "exit": return 0;
                    case "quit":
                        {
                            ViaConsole.WriteResponse("Выйти из программы? Y - да; N - нет:", true);
                            userCommand = ViaConsole.ReadCommand();

                            if (userCommand.ToUpper() == "Y")
                            {
                                return 0;
                            }
                            else if (userCommand.ToUpper() == "N")
                            {
                                break;
                            }
                            else 
                            {
                                ViaConsole.WriteResponse("Некорректный ввод.", false);
                                goto case "quit";
                            } 
                        }
                    default:
                        {
                            ViaConsole.WriteResponse("Такой команды не существует", false);
                            this.HelpCommand();
                            break;
                        } 
                }    
            }
        }
        void HelpCommand()
        {
            ViaConsole.WriteResponse(
@"exit - выход без подтверждения
quit- выход с подтверждением
print - напечатать следующий текст
enable echo - включить эхо сервис
disable echo - выключить эхо сервис
select - прочитать последнюю запись в базе данных в таблице Users
insert - добавить новую запись в таблицу Users", false);        
        }

    }
}
