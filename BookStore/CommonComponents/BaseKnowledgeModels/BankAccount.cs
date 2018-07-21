using System;

namespace CommonComponents.BaseKnowledgeModels
{
    public class BankAccount
    {


        int _sum; // Переменная для хранения суммы

        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler _del;

        //public void RegisterHandler(AccountStateHandler del)
        //{
        //    _del = del;
        //}
        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            Delegate mainDel = System.Delegate.Combine(del, _del);
            _del = mainDel as AccountStateHandler;
        }
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            Delegate mainDel = System.Delegate.Remove(_del, del);
            _del = mainDel as AccountStateHandler;
        }

        public BankAccount(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                _del?.Invoke($"Сумма {sum} снята со счета");
            }
            else
            {
                _del?.Invoke("Недостаточно денег на счете");
            }
            
        }
    }
}
