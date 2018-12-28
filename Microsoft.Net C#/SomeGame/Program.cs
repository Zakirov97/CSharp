using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    interface IMoveable
    {
        void ChangePosition(int nextOx, int nextOy);
        void SetMovementSpeed(int speed);
        Tuple<int, int> GetCurrentPosition();
    }

    interface IAttackable
    {
        void Attack(int enemyId, int gunId, int ammoCount);
        void Rearm();
    }

    interface IGameObject
    {
        string SaveState();
        void LoadState(string path);
    }

    class Building : IMoveable
    {
        public void ChangePosition(int nextOx, int nextOy)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, int> GetCurrentPosition()
        {
            throw new NotImplementedException();
        }

        public void SetMovementSpeed(int speed)
        {
            throw new NotImplementedException();
        }
    }
    class Player : IGameObject, IAttackable, IMoveable
    {
        private int _hp;
        private int _mapPositionOx;
        private int _mapPositionOy;
        private int _damage;
        private int _ammoLeft;

        public void Attack(int enemyId, int gunId, int ammoCount)
        {
            _ammoLeft -= ammoCount;
        }

        public void ChangePosition(int nextOx, int nextOy)
        {
            _mapPositionOx += nextOx;
            _mapPositionOy += nextOy;
        }

        public void LoadState(string path)
        {
        }

        public void Rearm()
        {
            _ammoLeft = 31;
        }

        public string SaveState()
        {
            return "";
        }

        public void SetMovementSpeed(int speed)
        {
            // Some logic...
        }

        public Tuple<int, int> GetCurrentPosition()
        {
            return new Tuple<int, int>(_mapPositionOx, _mapPositionOy);
        }
    }

    class MapDrawer
    {
        public void DrawMap(IMoveable [] moveableItems)
        {
            foreach (var item in moveableItems)
            {
                item.GetCurrentPosition();
            }
        }
    }
    class GameLoader
    {
        public void LoadPlayers(IGameObject [] players)
        {
            foreach (var item in players)
            {
                item.LoadState("SomePathToDb...");
            }
        }
    }

    interface IPasswordGenerator
    {
        string GeneratePassword(int length);
    }

    class PasswordGenerator : IPasswordGenerator
    {
        private Random r = new Random();
        public string GeneratePassword(int length)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                sb.Append((char)r.Next(60, 90));
            }
            return sb.ToString();
        }
    }

    class VipPasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(int length)
        {
            return Guid.NewGuid().ToString();
        }
    }
    class RegistrationManager
    {
        private IPasswordGenerator _passwordGenerator;
        public string RegisterUser(string email)
        {
            return _passwordGenerator.GeneratePassword(10);
        }

        public RegistrationManager(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IPasswordGenerator passwordGenerator;
                string currentPolicy = ConfigurationManager.AppSettings["currentPasswordPolicy"];

                if (currentPolicy == "standard")
                {
                    passwordGenerator = new PasswordGenerator();
                }
                else
                {
                    passwordGenerator = new VipPasswordGenerator();
                }
                RegistrationManager manager = new RegistrationManager(passwordGenerator);

                Console.WriteLine(manager.RegisterUser("email"));

                Thread.Sleep(10000);
            }
        }
    }
}
