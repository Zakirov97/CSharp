using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class A
    {

    }

    abstract class B : A
    {
        public virtual void BehaviorB1()
        {
            Console.WriteLine("BehaviorB1");
        }
    }

    class C : B
    {
        public override void BehaviorB1()
        {
            Console.WriteLine("Override B1...");
        }
    }

    sealed class D : C
    {

    }
    abstract class GameObject : Object
    {
        public int InnerGameId;
        public int[,,] Body3D;

        public GameObject()
        {
            Body3D = new int[256,256,256];
        }
    }
    class Hero : GameObject
    {
        public int Hp;
        public decimal LocationOx;
        public decimal LocationOy;
        public int BaseDamage;
        public int BaseArmor;

        public override string ToString()
        {
            string info = $"Hp = {Hp}, Location OX = {LocationOx}, Location OY = {LocationOy}";
            return info + base.ToString();
        }

        public override bool Equals(object obj)
        {
            bool isHero = obj is Hero;
            if (isHero)
            {
                Hero hero = obj as Hero;
                if(hero.Hp == this.Hp &&
                    hero.LocationOx == this.LocationOx &&
                    hero.LocationOy == this.LocationOy)
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Wizard : Hero
    {
        public decimal Mana;
        public override string ToString()
        {
            //object o = this as object;

            return $"Mana = {Mana}" + " " + base.ToString();
        }
    }

    sealed class FlyableWizard : Wizard
    {
        public decimal LocationOz;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //B b = new D();

            //StoreableObject user = new User() { Name = "Iskander", Password = "12345" };

            Car c = new Car(new StorableJsonObject()) { GovernmentalNumber = "AX232", EngineVolume = 4 };

            Console.WriteLine(c.ToString());

            //Hero h = new Hero() { Hp = 100 };
            //Wizard h2 = new Wizard() { Hp = 100 };

            //Console.WriteLine(h2.ToString());

            ////Int32 integer = 100;
            ////SqlConnection sql = new SqlConnection();
            ////DateTime dateTime = new DateTime(1999, 12, 12);
            ////String str = new string(new char[] { 'b', 'c', 'd' });

            ////Console.WriteLine(sql.ToString());
            ////Console.WriteLine(h.ToString());
            ////Console.WriteLine(integer.ToString());
            ////Console.WriteLine(dateTime.ToString());
            ////Console.WriteLine(str.ToString());

            Console.ReadLine();
        }
    }
}
