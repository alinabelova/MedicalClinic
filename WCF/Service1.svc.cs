using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

using MedicalClinic.Model;
using Microsoft.Practices.ServiceLocation;
using Mita.DataAccess;

namespace WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }

        public Employee MakeLogin(string login)
        {
            Employee user;
            var repositoryProvider = ServiceLocator.Current.GetInstance<IRepositoryProvider>();
            using (repositoryProvider)
            {
                user = repositoryProvider.GetRepository<Employee>().GetAll()
                    .FirstOrDefault(u => u.Login == login);
            }

            return user;
        }
    }
}
